let allSolutions = [];
let filteredSolutions = [];
let allTags = new Set();

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

// Load solutions data
async function loadSolutions() {
    try {
        const response = await fetch('solutions.json');
        const data = await response.json();
        allSolutions = data.solutions;

        // Collect all unique tags
        allSolutions.forEach(solution => {
            solution.tags.forEach(tag => allTags.add(tag));
        });

        // Populate tag filter
        populateTagFilter();

        // Update stats
        updateStats(data.stats);

        // Initial display
        filteredSolutions = [...allSolutions];
        displaySolutions(filteredSolutions);
    } catch (error) {
        console.error('Error loading solutions:', error);
        document.getElementById('solutionsContainer').innerHTML =
            '<div class="error">Failed to load solutions. Please try again later.</div>';
    }
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
function updateStats(stats) {
    document.getElementById('totalSolutions').textContent = stats.totalSolutions;
    document.getElementById('languageCount').textContent = stats.languages.length;
    document.getElementById('filteredCount').textContent = filteredSolutions.length;
}

// Search and filter solutions
function filterSolutions() {
    const searchTerm = document.getElementById('searchInput').value.toLowerCase();
    const selectedLanguage = document.getElementById('languageFilter').value;
    const selectedDifficulty = document.getElementById('difficultyFilter').value;
    const selectedTag = document.getElementById('tagFilter').value;

    filteredSolutions = allSolutions.filter(solution => {
        // Search filter
        const matchesSearch = !searchTerm ||
            solution.problemNumber.includes(searchTerm) ||
            solution.title.toLowerCase().includes(searchTerm) ||
            solution.tags.some(tag => tag.toLowerCase().includes(searchTerm)) ||
            solution.approach.toLowerCase().includes(searchTerm);

        // Language filter
        const matchesLanguage = !selectedLanguage || solution.language === selectedLanguage;

        // Difficulty filter
        const matchesDifficulty = !selectedDifficulty || solution.difficulty === selectedDifficulty;

        // Tag filter
        const matchesTag = !selectedTag || solution.tags.includes(selectedTag);

        return matchesSearch && matchesLanguage && matchesDifficulty && matchesTag;
    });

    document.getElementById('filteredCount').textContent = filteredSolutions.length;
    displaySolutions(filteredSolutions);
}

// Display solutions as cards
function displaySolutions(solutions) {
    const container = document.getElementById('solutionsContainer');

    if (solutions.length === 0) {
        container.innerHTML = '<div class="no-results">No solutions found. Try adjusting your filters.</div>';
        return;
    }

    container.innerHTML = solutions.map(solution => createSolutionCard(solution)).join('');

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

// Create individual solution card HTML
function createSolutionCard(solution) {
    const langClass = LANG_MAP[solution.language] || 'plaintext';
    const titleSlug = solution.title.toLowerCase()
        .replace(/[^a-z0-9\s-]/g, '')
        .replace(/\s+/g, '-')
        .replace(/-+/g, '-')
        .trim();
    const langSlug = solution.language.toLowerCase().replace('#', 'sharp').replace(/\s+/g, '-');
    const solutionUrl = `solutions/${solution.problemNumber}-${titleSlug}-${langSlug}.html`;
    const tagsHtml = solution.tags.map(tag => `<span class="tag">${tag}</span>`).join('');
    const stepsHtml = solution.steps.length > 0
        ? `<div class="steps"><strong>Algorithm:</strong><ol>${solution.steps.map(step => `<li>${step.replace(/^\d+\)\s*/, '')}</li>`).join('')}</ol></div>`
        : '';

    return `
        <article class="solution-card" id="solution-${solution.problemNumber}-${solution.language.replace('#', 'sharp')}">
            <div class="solution-header">
                <div class="solution-title">
                    <h2><a href="${solutionUrl}" class="solution-link">${solution.problemNumber}. ${solution.title}</a></h2>
                    <span class="language-badge">${solution.language}</span>
                    ${solution.difficulty && solution.difficulty !== 'Unknown' ? `<span class="difficulty-badge difficulty-${solution.difficulty.toLowerCase()}">${solution.difficulty}</span>` : ''}
                </div>
                <div class="solution-meta">
                    ${solution.solutionLink ? `<a href="${solution.solutionLink}" target="_blank" rel="noopener" class="btn-link">Solution on LeetCode</a>` : ''}
                    <a href="${solution.githubUrl}" target="_blank" rel="noopener" class="btn-link">GitHub</a>
                </div>
            </div>

            ${solution.approach ? `<div class="approach"><strong>Approach:</strong> ${solution.approach}</div>` : ''}

            ${solution.tags.length > 0 ? `<div class="tags">${tagsHtml}</div>` : ''}

            ${stepsHtml}

            <div class="complexity">
                ${solution.timeComplexity ? `<div><strong>Time:</strong> ${solution.timeComplexity}</div>` : ''}
                ${solution.spaceComplexity ? `<div><strong>Space:</strong> ${solution.spaceComplexity}</div>` : ''}
            </div>

            <details class="code-section">
                <summary>View Code</summary>
                <pre><code class="${langClass}">${escapeHtml(solution.code)}</code></pre>
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

// Deep linking support - scroll to specific solution if URL hash exists
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
