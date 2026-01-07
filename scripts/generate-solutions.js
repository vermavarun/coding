const fs = require('fs');
const path = require('path');

const LEETCODE_DIR = path.join(__dirname, '..', 'LeetCode');
const OUTPUT_FILE = path.join(__dirname, '..', 'docs', 'solutions.json');

// Language file extensions mapping
const LANG_EXTENSIONS = {
    'C#': '.cs',
    'JavaScript': '.js',
    'Python': '.py',
    'Java': '.java',
    'Go': '.go',
    'SQL': '.sql',
    'Bash': '.sh'
};

// Parse problem number and title from filename
function parseFilename(filename) {
    const match = filename.match(/^(\d+)-(.+)\.(cs|js|py|java|go|sql|sh)$/);
    if (!match) return null;

    const problemNumber = match[1];
    const titleRaw = match[2];
    const extension = match[3];

    // Convert filename to readable title (handle special cases)
    const title = titleRaw
        .replace(/([A-Z])/g, ' $1')
        .replace(/II/g, ' II')
        .replace(/III/g, ' III')
        .trim();

    return { problemNumber, title, extension };
}

// Extract metadata from file content
function parseFileContent(content, language) {
    const metadata = {
        title: '',
        approach: '',
        tags: [],
        steps: [],
        timeComplexity: '',
        spaceComplexity: '',
        solutionLink: '',
        tip: ''
    };

    // Different comment styles for different languages
    let commentBlock = '';
    if (language === 'Bash') {
        const lines = content.split('\n');
        let inComment = false;
        for (const line of lines) {
            if (line.startsWith('#')) {
                commentBlock += line + '\n';
            } else if (commentBlock) {
                break;
            }
        }
    } else if (language === 'SQL') {
        const lines = content.split('\n');
        for (const line of lines) {
            if (line.trim().startsWith('--')) {
                commentBlock += line + '\n';
            } else if (commentBlock) {
                break;
            }
        }
    } else {
        // C#, JavaScript, Java, Go, Python use /* */ or """
        const blockMatch = content.match(/^\/\*[\s\S]*?\*\//m) ||
                          content.match(/^"""[\s\S]*?"""/m) ||
                          content.match(/^'''[\s\S]*?'''/m);
        if (blockMatch) {
            commentBlock = blockMatch[0];
        }
    }

    if (commentBlock) {
        // Extract title (e.g., "Title: 1. Two Sum")
        const titleMatch = commentBlock.match(/Title:\s*(.+?)(?:\n|$)/i);
        if (titleMatch) {
            metadata.title = titleMatch[1].trim();
        }

        // Extract solution link
        const linkMatch = commentBlock.match(/Solution:\s*(https:\/\/[^\s]+)/i);
        if (linkMatch) {
            metadata.solutionLink = linkMatch[1];
        }

        // Extract approach
        const approachMatch = commentBlock.match(/Approach:\s*(.+?)(?:\n|Tags:)/i);
        if (approachMatch) {
            metadata.approach = approachMatch[1].trim();
        }

        // Extract tags
        const tagsMatch = commentBlock.match(/Tags?:\s*(.+?)(?:\n\d+\)|Time|Space|\n\n)/i);
        if (tagsMatch) {
            metadata.tags = tagsMatch[1]
                .split(',')
                .map(tag => tag.trim())
                .filter(tag => tag.length > 0);
        }

        // Extract algorithm steps
        const stepMatches = commentBlock.match(/^\d+\).+$/gm);
        if (stepMatches) {
            metadata.steps = stepMatches.map(step => step.trim());
        }

        // Extract time complexity
        const timeMatch = commentBlock.match(/Time Complexity:\s*(.+?)(?:\n|$)/i);
        if (timeMatch) {
            metadata.timeComplexity = timeMatch[1].trim();
        }

        // Extract space complexity
        const spaceMatch = commentBlock.match(/Space Complexity:\s*(.+?)(?:\n|$)/i);
        if (spaceMatch) {
            metadata.spaceComplexity = spaceMatch[1].trim();
        }

        // Extract difficulty
        const difficultyMatch = commentBlock.match(/Difficulty:\s*(Easy|Medium|Hard)/i);
        if (difficultyMatch) {
            metadata.difficulty = difficultyMatch[1].charAt(0).toUpperCase() + difficultyMatch[1].slice(1).toLowerCase();
        }

        // Extract tip
        const tipMatch = commentBlock.match(/Tip:\s*(.+?)(?:\n\n|\*\/|$)/is);
        if (tipMatch) {
            metadata.tip = tipMatch[1].trim();
        }
    }

    return metadata;
}

// Get language from directory name
function getLanguageFromPath(filePath) {
    for (const [lang, ext] of Object.entries(LANG_EXTENSIONS)) {
        if (filePath.includes(path.sep + lang + path.sep)) {
            return lang;
        }
    }
    return 'Unknown';
}

// Recursively scan directory for solution files
function scanDirectory(dir, solutions = []) {
    const items = fs.readdirSync(dir);

    for (const item of items) {
        const fullPath = path.join(dir, item);
        const stat = fs.statSync(fullPath);

        if (stat.isDirectory() && !item.startsWith('.')) {
            scanDirectory(fullPath, solutions);
        } else if (stat.isFile()) {
            const parsed = parseFilename(item);
            if (parsed) {
                const language = getLanguageFromPath(fullPath);
                const content = fs.readFileSync(fullPath, 'utf-8');
                const metadata = parseFileContent(content, language);

                // Get relative path and encode for URL (C# -> C%23)
                const relativePath = path.relative(path.join(__dirname, '..'), fullPath);
                const encodedPath = relativePath.split(path.sep).map(encodeURIComponent).join('/');

                // Extract problem number and title
                let problemNumber = parsed.problemNumber;
                let title = parsed.title;

                if (metadata.title) {
                    // Extract problem number from metadata title (e.g., "1. Two Sum" -> "1")
                    const match = metadata.title.match(/^(\d+)\.\s*(.+)$/);
                    if (match) {
                        problemNumber = match[1];
                        title = match[2].trim(); // Extract just the title part without number
                    } else {
                        // If title doesn't have number prefix, use it as is
                        title = metadata.title;
                    }
                }

                solutions.push({
                    problemNumber: problemNumber,
                    title: title,
                    language: language,
                    difficulty: metadata.difficulty || 'Unknown',
                    filename: item,
                    path: relativePath,
                    githubUrl: `https://github.com/vermavarun/coding/blob/main/${encodedPath}`,
                    approach: metadata.approach,
                    tags: metadata.tags,
                    steps: metadata.steps,
                    timeComplexity: metadata.timeComplexity,
                    spaceComplexity: metadata.spaceComplexity,
                    solutionLink: metadata.solutionLink,
                    tip: metadata.tip,
                    code: content
                });
            }
        }
    }

    return solutions;
}

// Generate solutions.json
function generateSolutionsJson() {
    console.log('Scanning LeetCode directory...');
    const solutions = scanDirectory(LEETCODE_DIR);

    // Sort by problem number
    solutions.sort((a, b) => {
        const numA = parseInt(a.problemNumber);
        const numB = parseInt(b.problemNumber);
        return numA - numB;
    });

    console.log(`Found ${solutions.length} solutions`);

    // Create stats
    const stats = {
        totalSolutions: solutions.length,
        languages: [...new Set(solutions.map(s => s.language))],
        tags: [...new Set(solutions.flatMap(s => s.tags))].sort(),
        lastUpdated: new Date().toISOString()
    };

    const output = {
        stats,
        solutions
    };

    // Write to file
    const outputDir = path.dirname(OUTPUT_FILE);
    if (!fs.existsSync(outputDir)) {
        fs.mkdirSync(outputDir, { recursive: true });
    }

    fs.writeFileSync(OUTPUT_FILE, JSON.stringify(output, null, 2));
    console.log(`Generated ${OUTPUT_FILE}`);
    console.log(`Languages: ${stats.languages.join(', ')}`);
    console.log(`Unique tags: ${stats.tags.length}`);
}

// Run the generator
try {
    generateSolutionsJson();
} catch (error) {
    console.error('Error generating solutions.json:', error);
    process.exit(1);
}
