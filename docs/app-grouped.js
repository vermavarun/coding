let allProblems = [];
let filteredProblems = [];
let allTags = new Set();
let allLanguages = new Set();

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

// Theme management
function initTheme() {
    const savedTheme = localStorage.getItem('theme') || 'light';
    setTheme(savedTheme);
}

function setTheme(theme) {
    document.body.setAttribute('data-theme', theme);
    localStorage.setItem('theme', theme);

    // Update highlight.js theme
    const lightTheme = document.getElementById('hljs-light');
    const darkTheme = document.getElementById('hljs-dark');

    if (theme === 'light' || (theme === 'auto' && !window.matchMedia('(prefers-color-scheme: dark)').matches)) {
        lightTheme.disabled = false;
        darkTheme.disabled = true;
    } else {
        lightTheme.disabled = true;
        darkTheme.disabled = false;
    }

    // Update theme icon
    const themeIcon = document.querySelector('.theme-icon');
    if (themeIcon) {
        themeIcon.textContent = theme === 'dark' ? '🌙' : '☀️';
    }

    // Re-highlight code blocks if they exist
    if (typeof hljs !== 'undefined') {
        document.querySelectorAll('pre code').forEach(block => {
            hljs.highlightElement(block);
        });
    }
}

function toggleTheme() {
    const currentTheme = document.body.getAttribute('data-theme') || 'light';
    const newTheme = currentTheme === 'light' ? 'dark' : 'light';
    setTheme(newTheme);
}

// Generate slug from problem number and title
function generateSlug(problemNumber, title) {
    const titleSlug = title.toLowerCase()
        .replace(/[^a-z0-9\s-]/g, '')
        .replace(/\s+/g, '-')
        .replace(/-+/g, '-')
        .trim();
    return `${problemNumber}-${titleSlug}`;
}

// Load solutions data
async function loadSolutions() {
    try {
        const response = await fetch('solutions.json');
        const data = await response.json();

        // Check if problemGroups exist, if not create them from solutions
        if (data.problemGroups) {
            allProblems = data.problemGroups;
        } else {
            // Group solutions by problem number
            allProblems = groupSolutionsByProblem(data.solutions);
        }

        // Collect all unique tags and languages
        allProblems.forEach(problem => {
            problem.tags.forEach(tag => allTags.add(tag));
            problem.solutions.forEach(solution => {
                allLanguages.add(solution.language);
            });
        });

        // Populate filters
        populateTagFilter();

        // Update stats
        updateStats(data.stats, allProblems.length);

        // Initial display
        filteredProblems = [...allProblems];
        displaySolutions(filteredProblems);
    } catch (error) {
        console.error('Error loading solutions:', error);
        document.getElementById('solutionsContainer').innerHTML =
            '<div class="error">Failed to load solutions. Please try again later.</div>';
    }
}

// Group solutions by problem number if not already grouped
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

    return Object.values(grouped);
}

// Populate tag filter dropdown
function populateTagFilter() {
    const tagFilter = document.getElementById('tagFilter');
    const sortedTags = Array.from(allTags).sort();

    sortedTags.forEach(tag => {
        const option = document.createElement('option');
        option.value = tag;
        option.textContent = tag;
        tagFilter.appendChild(option);
    });
}

// Update statistics
function updateStats(stats, uniqueProblems) {
    document.getElementById('totalSolutions').textContent = stats.totalSolutions;
    document.getElementById('languageCount').textContent = stats.languages.length;
    document.getElementById('filteredCount').textContent = filteredProblems.length;
}

// Search and filter solutions
function filterSolutions() {
    const searchTerm = document.getElementById('searchInput').value.toLowerCase();
    const selectedLanguage = document.getElementById('languageFilter').value;
    const selectedDifficulty = document.getElementById('difficultyFilter').value;
    const selectedTag = document.getElementById('tagFilter').value;

    filteredProblems = allProblems.filter(problem => {
        // Search filter
        const matchesSearch = !searchTerm ||
            problem.problemNumber.includes(searchTerm) ||
            problem.title.toLowerCase().includes(searchTerm) ||
            problem.tags.some(tag => tag.toLowerCase().includes(searchTerm)) ||
            problem.solutions.some(s => s.approach && s.approach.toLowerCase().includes(searchTerm));

        // Language filter - check if any solution has the language
        const matchesLanguage = !selectedLanguage ||
            problem.solutions.some(s => s.language === selectedLanguage);

        // Difficulty filter
        const matchesDifficulty = !selectedDifficulty || problem.difficulty === selectedDifficulty;

        // Tag filter
        const matchesTag = !selectedTag || problem.tags.includes(selectedTag);

        return matchesSearch && matchesLanguage && matchesDifficulty && matchesTag;
    });

    document.getElementById('filteredCount').textContent = filteredProblems.length;
    displaySolutions(filteredProblems);
}

// Display solutions as cards
function displaySolutions(problems) {
    const container = document.getElementById('solutionsContainer');

    if (problems.length === 0) {
        container.innerHTML = '<div class="no-results">No solutions found. Try adjusting your filters.</div>';
        return;
    }

    container.innerHTML = problems.map(problem => createProblemCard(problem)).join('');

    // Apply syntax highlighting to all code blocks
    document.querySelectorAll('pre code').forEach(block => {
        hljs.highlightElement(block);
    });

    // Add copy buttons to all code blocks
    addCopyButtons();
}

// Add copy buttons to code blocks
function addCopyButtons() {
    document.querySelectorAll('.code-section').forEach(section => {
        const pre = section.querySelector('pre');
        if (pre && !pre.querySelector('.copy-btn')) {
            const copyBtn = document.createElement('button');
            copyBtn.className = 'copy-btn';
            copyBtn.innerHTML = '📋 Copy';
            copyBtn.setAttribute('aria-label', 'Copy code to clipboard');

            copyBtn.addEventListener('click', async (e) => {
                e.stopPropagation();
                const code = pre.querySelector('code').textContent;

                try {
                    await navigator.clipboard.writeText(code);
                    copyBtn.innerHTML = '✓ Copied!';
                    copyBtn.classList.add('copied');

                    setTimeout(() => {
                        copyBtn.innerHTML = '📋 Copy';
                        copyBtn.classList.remove('copied');
                    }, 2000);
                } catch (err) {
                    console.error('Failed to copy:', err);
                    copyBtn.innerHTML = '✗ Failed';
                    setTimeout(() => {
                        copyBtn.innerHTML = '📋 Copy';
                    }, 2000);
                }
            });

            pre.style.position = 'relative';
            pre.appendChild(copyBtn);
        }
    });
}

// Create individual problem card HTML
function createProblemCard(problem) {
    const slug = generateSlug(problem.problemNumber, problem.title);
    const solutionUrl = `solutions/${slug}.html`;
    const tagsHtml = problem.tags.map(tag => `<span class="tag">${tag}</span>`).join('');

    // Get languages available
    const languagesHtml = problem.solutions.map(s =>
        `<span class="language-badge">${s.language}</span>`
    ).join('');

    // Use the first solution for preview
    const firstSolution = problem.solutions[0];
    const langClass = LANG_MAP[firstSolution.language] || 'plaintext';
    const stepsHtml = firstSolution.steps && firstSolution.steps.length > 0
        ? `<div class="steps"><strong>Algorithm:</strong><ol>${firstSolution.steps.map(step => `<li>${step.replace(/^\d+\)\s*/, '')}</li>`).join('')}</ol></div>`
        : '';

    return `
        <article class="solution-card" id="problem-${problem.problemNumber}">
            <div class="solution-header">
                <div class="solution-title">
                    <h2><a href="${solutionUrl}" class="solution-link">${problem.problemNumber}. ${problem.title}</a></h2>
                    <div class="language-badges">
                        ${languagesHtml}
                    </div>
                    ${problem.difficulty && problem.difficulty !== 'Unknown' ? `<span class="difficulty-badge difficulty-${problem.difficulty.toLowerCase()}">${problem.difficulty}</span>` : ''}
                </div>
                <div class="solution-meta">
                    ${firstSolution.solutionLink ? `<a href="${firstSolution.solutionLink}" target="_blank" rel="noopener" class="btn-link">LeetCode</a>` : ''}
                    <a href="${solutionUrl}" class="btn-link">View Solutions</a>
                </div>
            </div>

            ${firstSolution.approach ? `<div class="approach"><strong>Approach:</strong> ${firstSolution.approach}</div>` : ''}

            ${problem.tags.length > 0 ? `<div class="tags">${tagsHtml}</div>` : ''}

            ${stepsHtml}

            <div class="complexity">
                ${firstSolution.timeComplexity ? `<div><strong>Time:</strong> ${firstSolution.timeComplexity}</div>` : ''}
                ${firstSolution.spaceComplexity ? `<div><strong>Space:</strong> ${firstSolution.spaceComplexity}</div>` : ''}
            </div>

            <details class="code-section">
                <summary>Preview Code (${firstSolution.language})</summary>
                <pre><code class="${langClass}">${escapeHtml(firstSolution.code)}</code></pre>
            </details>
        </article>
    `;
}

// Escape HTML to prevent XSS
function escapeHtml(text) {
    const div = document.createElement('div');
    div.textContent = text;
    return div.innerHTML;
}

// Clear all filters
function clearFilters() {
    document.getElementById('searchInput').value = '';
    document.getElementById('languageFilter').value = '';
    document.getElementById('difficultyFilter').value = '';
    document.getElementById('tagFilter').value = '';
    filterSolutions();
}

// Event listeners
document.addEventListener('DOMContentLoaded', () => {
    initTheme();
    loadSolutions();

    document.getElementById('searchInput').addEventListener('input', filterSolutions);
    document.getElementById('searchBtn').addEventListener('click', filterSolutions);
    document.getElementById('languageFilter').addEventListener('change', filterSolutions);
    document.getElementById('difficultyFilter').addEventListener('change', filterSolutions);
    document.getElementById('tagFilter').addEventListener('change', filterSolutions);
    document.getElementById('clearFilters').addEventListener('click', clearFilters);
    document.getElementById('themeToggle').addEventListener('click', toggleTheme);

    // Enable search on Enter key
    document.getElementById('searchInput').addEventListener('keypress', (e) => {
        if (e.key === 'Enter') {
            filterSolutions();
        }
    });

    // Watch for system theme changes when using auto theme
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', (e) => {
        const currentTheme = localStorage.getItem('theme');
        if (currentTheme === 'auto') {
            setTheme('auto');
        }
    });
});

// Deep linking support - scroll to specific problem if URL hash exists
window.addEventListener('load', () => {
    if (window.location.hash) {
        const element = document.querySelector(window.location.hash);
        if (element) {
            setTimeout(() => {
                element.scrollIntoView({ behavior: 'smooth', block: 'start' });
                element.classList.add('highlight');
            }, 500);
        }
    }
});
