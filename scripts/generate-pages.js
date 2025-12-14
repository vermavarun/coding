const fs = require('fs');
const path = require('path');

const SOLUTIONS_FILE = path.join(__dirname, '..', 'docs', 'solutions.json');
const SOLUTIONS_DIR = path.join(__dirname, '..', 'docs', 'solutions');
const TEMPLATE_FILE = path.join(__dirname, 'solution-template.html');

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

// Generate slug from problem number, title, and language
function generateSlug(problemNumber, title, language) {
    const titleSlug = title.toLowerCase()
        .replace(/[^a-z0-9\s-]/g, '') // Remove special characters
        .replace(/\s+/g, '-')          // Replace spaces with hyphens
        .replace(/-+/g, '-')           // Replace multiple hyphens with single
        .trim();
    const langSlug = language.toLowerCase().replace('#', 'sharp').replace(/\s+/g, '-');
    return `${problemNumber}-${titleSlug}-${langSlug}`;
}

// Create solution HTML page
function createSolutionPage(solution, template) {
    const langClass = LANG_MAP[solution.language] || 'plaintext';
    const slug = generateSlug(solution.problemNumber, solution.title, solution.language);
    const tagsHtml = solution.tags.map(tag => `<span class="tag">${escapeHtml(tag)}</span>`).join('');
    const stepsHtml = solution.steps.length > 0
        ? `<div class="steps"><strong>Algorithm:</strong><ol>${solution.steps.map(step => `<li>${escapeHtml(step.replace(/^\d+\)\s*/, ''))}</li>`).join('')}</ol></div>`
        : '';

    const hlTheme = '<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.9.0/styles/github.min.css" id="hljs-light">\n    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.9.0/styles/github-dark.min.css" id="hljs-dark" disabled>';

    const title = `${solution.problemNumber}. ${escapeHtml(solution.title)} - ${solution.language}`;
    const description = `${escapeHtml(solution.title)} solution in ${solution.language} with ${solution.approach || 'detailed explanation'}`;

    let html = template;
    html = html.replace(/\{\{TITLE\}\}/g, title);
    html = html.replace(/\{\{DESCRIPTION\}\}/g, description);
    html = html.replace('{{KEYWORDS}}', `LeetCode ${solution.problemNumber}, ${escapeHtml(solution.title)}, ${solution.language}, ${solution.tags.join(', ')}`);
    html = html.replace('{{SLUG}}', slug);
    html = html.replace('{{PROBLEM_NUMBER}}', solution.problemNumber);
    html = html.replace('{{PROBLEM_TITLE}}', escapeHtml(solution.title));
    html = html.replace('{{LANGUAGE}}', solution.language);
    html = html.replace('{{LANGUAGE_BADGE}}', solution.language);
    html = html.replace('{{APPROACH}}', solution.approach ? `<div class="approach"><strong>Approach:</strong> ${escapeHtml(solution.approach)}</div>` : '');
    html = html.replace('{{TAGS}}', solution.tags.length > 0 ? `<div class="tags">${tagsHtml}</div>` : '');
    html = html.replace('{{STEPS}}', stepsHtml);
    html = html.replace('{{TIME_COMPLEXITY}}', solution.timeComplexity ? `<div><strong>Time:</strong> ${escapeHtml(solution.timeComplexity)}</div>` : '');
    html = html.replace('{{SPACE_COMPLEXITY}}', solution.spaceComplexity ? `<div><strong>Space:</strong> ${escapeHtml(solution.spaceComplexity)}</div>` : '');
    html = html.replace('{{LEETCODE_LINK}}', solution.solutionLink ? `<a href="${solution.solutionLink}" target="_blank" rel="noopener" class="btn-link">LeetCode</a>` : '');
    html = html.replace('{{GITHUB_LINK}}', solution.githubUrl);
    html = html.replace('{{LANG_CLASS}}', langClass);
    html = html.replace('{{CODE}}', escapeHtml(solution.code));
    html = html.replace('{{HL_THEME}}', hlTheme);

    return html;
}

// Generate all solution pages
function generateSolutionPages() {
    console.log('Loading solutions...');
    const data = JSON.parse(fs.readFileSync(SOLUTIONS_FILE, 'utf-8'));
    const solutions = data.solutions;

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

    console.log(`Generating ${solutions.length} solution pages...`);

    solutions.forEach((solution, index) => {
        const slug = generateSlug(solution.problemNumber, solution.title, solution.language);
        const filename = `${slug}.html`;
        const filepath = path.join(SOLUTIONS_DIR, filename);

        const html = createSolutionPage(solution, template);
        fs.writeFileSync(filepath, html);

        if ((index + 1) % 50 === 0) {
            console.log(`  Generated ${index + 1}/${solutions.length} pages...`);
        }
    });

    console.log(`✓ Generated ${solutions.length} solution pages in ${SOLUTIONS_DIR}`);
}

// Run the generator
try {
    generateSolutionPages();
} catch (error) {
    console.error('Error generating solution pages:', error);
    process.exit(1);
}
