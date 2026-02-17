const fs = require('fs');
const path = require('path');

const SOLUTIONS_FILE = path.join(__dirname, '..', 'docs', 'solutions.json');
const SOLUTIONS_DIR = path.join(__dirname, '..', 'docs', 'solutions');
const TEMPLATE_FILE = path.join(__dirname, 'solution-template-grouped.html');

// Language to highlight.js language mapping
const LANG_MAP = {
    'C#': 'csharp',
    'JavaScript': 'javascript',
    'Python': 'python',
    'Java': 'java',
    'Go': 'go',
    'SQL': 'sql',
    'Bash': 'bash'
};

// Escape HTML
function escapeHtml(text) {
    return text
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#039;');
}

// Generate slug from problem number and title (no language)
function generateSlug(problemNumber, title) {
    const titleSlug = title.toLowerCase()
        .replace(/[^a-z0-9\s-]/g, '') // Remove special characters
        .replace(/\s+/g, '-')          // Replace spaces with hyphens
        .replace(/-+/g, '-')           // Replace multiple hyphens with single
        .trim();
    return `${problemNumber}-${titleSlug}`;
}

// Group solutions by problem number
function groupSolutionsByProblem(solutions) {
    const grouped = {};

    solutions.forEach(solution => {
        const key = solution.problemNumber;
        if (!grouped[key]) {
            grouped[key] = {
                problemNumber: solution.problemNumber,
                title: solution.title,
                difficulty: solution.difficulty || 'Unknown',
                tags: solution.tags || [],
                solutions: []
            };
        }
        grouped[key].solutions.push(solution);
    });

    // Sort by problem number
    return Object.values(grouped).sort((a, b) => {
        const numA = parseInt(a.problemNumber);
        const numB = parseInt(b.problemNumber);
        return numA - numB;
    });
}

// Create solution HTML page with tabs for multiple languages
function createSolutionPage(problemGroup, template) {
    const slug = generateSlug(problemGroup.problemNumber, problemGroup.title);
    const tagsHtml = problemGroup.tags.map(tag => `<span class="tag">${escapeHtml(tag)}</span>`).join('');

    const hlTheme = '<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.9.0/styles/github.min.css" id="hljs-light">\n    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.9.0/styles/github-dark.min.css" id="hljs-dark" disabled>';

    const title = `${problemGroup.problemNumber}. ${escapeHtml(problemGroup.title)} - LeetCode Solution`;
    const languages = problemGroup.solutions.map(s => s.language).join(', ');
    const description = `${escapeHtml(problemGroup.title)} solution in ${languages}`;

    // Generate language tabs HTML
    const languageTabs = problemGroup.solutions.map((solution, index) => {
        const isActive = index === 0 ? 'active' : '';
        return `<button class="tab-btn ${isActive}" data-lang="${escapeHtml(solution.language)}">${escapeHtml(solution.language)}</button>`;
    }).join('');

    // Generate tab content for each language
    const tabContents = problemGroup.solutions.map((solution, index) => {
        const isActive = index === 0 ? 'active' : '';
        const langClass = LANG_MAP[solution.language] || 'plaintext';
        const stepsHtml = solution.steps && solution.steps.length > 0
            ? `<div class="steps"><strong>Algorithm:</strong><ol>${solution.steps.map(step => `<li>${escapeHtml(step.replace(/^\d+\)\s*/, ''))}</li>`).join('')}</ol></div>`
            : '';

        return `
            <div class="tab-content ${isActive}" data-lang="${escapeHtml(solution.language)}">
                ${solution.approach ? `<div class="section"><h3>Approach</h3><div class="approach">${escapeHtml(solution.approach)}</div></div>` : ''}

                ${stepsHtml ? `<div class="section"><h3>Algorithm Steps</h3>${stepsHtml}</div>` : ''}

                <div class="section">
                    <h3>Complexity Analysis</h3>
                    <div class="complexity">
                        ${solution.timeComplexity ? `<div><strong>Time:</strong> ${escapeHtml(solution.timeComplexity)}</div>` : '<div><strong>Time:</strong> Not specified</div>'}
                        ${solution.spaceComplexity ? `<div><strong>Space:</strong> ${escapeHtml(solution.spaceComplexity)}</div>` : '<div><strong>Space:</strong> Not specified</div>'}
                    </div>
                    ${solution.tip ? `<div class="tip"><strong>💡 Tip:</strong> ${escapeHtml(solution.tip)}</div>` : ''}
                    ${solution.similarProblems ? `<div class="similar-problems"><strong>🔗 Similar Problems:</strong><div class="similar-tags">${solution.similarProblems.split(',').map(p => `<span class="similar-tag">${escapeHtml(p.trim())}</span>`).join('')}</div></div>` : ''}
                </div>

                <div class="section">
                    <h3>Solution Code</h3>
                    <div class="code-section">
                        <button class="copy-btn" onclick="copyCode(this)">Copy</button>
                        <pre><code class="language-${langClass}">${escapeHtml(solution.code)}</code></pre>
                    </div>
                </div>

                <div class="links">
                    <div class="links-left">
                        ${solution.solutionLink ? `<a href="${solution.solutionLink}" target="_blank" rel="noopener" class="btn-link">Solution on LeetCode</a>` : ''}
                        <a href="${solution.githubUrl}" target="_blank" rel="noopener" class="btn-link">View on GitHub</a>
                    </div>
                </div>
            </div>
        `;
    }).join('');

    let html = template;
    html = html.replace(/\{\{TITLE\}\}/g, title);
    html = html.replace(/\{\{DESCRIPTION\}\}/g, description);
    html = html.replace('{{KEYWORDS}}', `LeetCode ${problemGroup.problemNumber}, ${escapeHtml(problemGroup.title)}, ${languages}, ${problemGroup.tags.join(', ')}`);
    html = html.replace(/{{SLUG}}/g, slug);
    html = html.replace(/{{SLUG_FINAL}}/g, slug);
    html = html.replace(/{{PROBLEM_NUMBER}}/g, problemGroup.problemNumber);
    html = html.replace(/{{PROBLEM_TITLE}}/g, escapeHtml(problemGroup.title));
    html = html.replace(/{{PROBLEM_TITLE_PLAIN}}/g, problemGroup.title);
    html = html.replace('{{DIFFICULTY_BADGE}}', problemGroup.difficulty && problemGroup.difficulty !== 'Unknown' ? `<span class="difficulty-badge difficulty-${problemGroup.difficulty.toLowerCase()}">${problemGroup.difficulty}</span>` : '');
    html = html.replace(/{{TAGS}}/g, problemGroup.tags.length > 0 ? problemGroup.tags.map(tag => `${escapeHtml(tag)}`).join(', ') : '');
    html = html.replace('{{LANGUAGE_TABS}}', languageTabs);
    html = html.replace('{{TAB_CONTENTS}}', tabContents);
    html = html.replace('{{HL_THEME}}', hlTheme);

    // SEO: Add dates for structured data
    const currentDate = new Date().toISOString();
    html = html.replace('{{DATE_PUBLISHED}}', currentDate);
    html = html.replace('{{DATE_MODIFIED}}', currentDate);
    html = html.replace('{{DIFFICULTY}}', problemGroup.difficulty || 'Medium');

    // SEO: Add problem description if available
    const problemDescription = problemGroup.description || `Solve ${escapeHtml(problemGroup.title)} - LeetCode problem #${problemGroup.problemNumber}. This ${problemGroup.difficulty || 'coding'} problem involves ${problemGroup.tags.slice(0, 3).join(', ')} concepts.`;
    const descriptionHtml = `
        <section class="problem-description">
            <h2>Problem Description</h2>
            <p>${problemDescription}</p>
            ${problemGroup.solutionLink ? `<p><a href="${problemGroup.solutionLink}" target="_blank" rel="noopener" class="btn-link">View Problem on LeetCode →</a></p>` : ''}
        </section>
    `;
    html = html.replace('{{PROBLEM_DESCRIPTION}}', descriptionHtml);

    return html;
}

// Generate all solution pages
function generateSolutionPages() {
    console.log('Loading solutions...');
    const data = JSON.parse(fs.readFileSync(SOLUTIONS_FILE, 'utf-8'));
    const solutions = data.solutions;

    // Group solutions by problem number
    console.log('Grouping solutions by problem...');
    const problemGroups = groupSolutionsByProblem(solutions);
    console.log(`Found ${problemGroups.length} unique problems`);

    // Read template
    console.log('Loading template...');
    const template = fs.readFileSync(TEMPLATE_FILE, 'utf-8');

    // Create solutions directory
    if (!fs.existsSync(SOLUTIONS_DIR)) {
        fs.mkdirSync(SOLUTIONS_DIR, { recursive: true });
    } else {
        // Clear existing solution pages
        const files = fs.readdirSync(SOLUTIONS_DIR);
        files.forEach(file => {
            if (file.endsWith('.html')) {
                fs.unlinkSync(path.join(SOLUTIONS_DIR, file));
            }
        });
    }

    console.log(`Generating ${problemGroups.length} solution pages...`);

    problemGroups.forEach((problemGroup, index) => {
        const slug = generateSlug(problemGroup.problemNumber, problemGroup.title);
        const filename = `${slug}.html`;
        const filepath = path.join(SOLUTIONS_DIR, filename);

        const html = createSolutionPage(problemGroup, template);
        fs.writeFileSync(filepath, html);

        if ((index + 1) % 50 === 0) {
            console.log(`  Generated ${index + 1}/${problemGroups.length} pages...`);
        }
    });

    console.log(`✓ Generated ${problemGroups.length} solution pages in ${SOLUTIONS_DIR}`);

    // Update solutions.json with grouped data for index page
    console.log('Updating solutions.json with grouped data...');
    data.problemGroups = problemGroups;
    data.stats.uniqueProblems = problemGroups.length;
    fs.writeFileSync(SOLUTIONS_FILE, JSON.stringify(data, null, 2));
    console.log('✓ Updated solutions.json');
}

// Run the generator
try {
    generateSolutionPages();
} catch (error) {
    console.error('Error generating solution pages:', error);
    process.exit(1);
}
