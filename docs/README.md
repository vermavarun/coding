# LeetCode Solutions Website

A dynamic web application that displays all LeetCode solutions from this repository. The site is automatically built and deployed to GitHub Pages.

## 🌐 Live Site

Visit: [https://vermavarun.github.io/coding/](https://vermavarun.github.io/coding/)

## ✨ Features

- **Dynamic Search**: Search solutions by problem number, title, or tags
- **Advanced Filters**: Filter by programming language, difficulty, and tags
- **Syntax Highlighting**: Beautiful code highlighting for all supported languages
- **SEO Optimized**: Each solution is searchable by Google with proper meta tags and sitemap
- **Responsive Design**: Works seamlessly on desktop, tablet, and mobile devices
- **Dark Theme**: Professional dark mode for comfortable reading
- **Deep Linking**: Share direct links to specific solutions

## 🛠️ Supported Languages

- C#
- JavaScript
- Python
- Java
- Go
- SQL
- Bash

## 📁 Project Structure

```
coding/
├── LeetCode/                    # Source code for all solutions
│   ├── C#/
│   ├── JavaScript/
│   ├── Python/
│   ├── Java/
│   ├── Go/
│   ├── SQL/
│   └── Bash/
├── docs/                        # GitHub Pages website
│   ├── index.html              # Main HTML page
│   ├── app.js                  # JavaScript for dynamic rendering
│   ├── styles.css              # CSS styling
│   ├── solutions.json          # Generated data (auto-generated)
│   ├── sitemap.xml             # SEO sitemap (auto-generated)
│   └── robots.txt              # Search engine instructions
├── scripts/                     # Build scripts
│   ├── generate-solutions.js   # Parses LeetCode files and generates JSON
│   └── generate-sitemap.js     # Generates sitemap.xml
└── .github/workflows/
    └── deploy-leetcode-site.yml # GitHub Actions workflow
```

## 🚀 How It Works

1. **Automated Parsing**: The `generate-solutions.js` script scans all files in the `LeetCode/` folder
2. **Metadata Extraction**: Extracts problem numbers, titles, approaches, tags, complexity, and code
3. **JSON Generation**: Creates `solutions.json` with all solution data
4. **Sitemap Creation**: Generates `sitemap.xml` for search engine indexing
5. **GitHub Pages Deploy**: Workflow automatically deploys to GitHub Pages on every push

## 🔄 Automatic Deployment

The site automatically rebuilds and deploys when:
- Changes are pushed to `main` branch in `LeetCode/` folder
- Changes are made to scripts or docs
- Manually triggered via GitHub Actions

## 📝 Solution Format

Solutions are parsed from comments in this format:

```
/*
Title: 1. Two Sum
Solution: https://leetcode.com/problems/problem-name/
Difficulty: Easy
Approach: Your approach description
Tags: Tag1, Tag2, Tag3
1) Step 1 description
2) Step 2 description
3) Step 3 description

Time Complexity: O(n)
Space Complexity: O(1)
*/
```

### Comment Format by Language:

- **C#, JavaScript, Java, Go**: Use `/* ... */` block comments
- **Python**: Use `"""..."""` or `'''...'''` docstrings
- **SQL**: Use `-- ` line comments (each line starts with `--`)
- **Bash**: Use `#` line comments (each line starts with `#`)

**Required Fields**:
- `Title`: Problem number and name (e.g., "1. Two Sum")

**Recommended Fields**:
- `Solution`: LeetCode problem URL
- `Difficulty`: Easy, Medium, or Hard
- `Approach`: Brief description of the solution approach
- `Tags`: Comma-separated list of relevant topics
- `1) 2) 3)...`: Step-by-step algorithm explanation
- `Time Complexity`: Big O notation for time
- `Space Complexity`: Big O notation for space

📚 **For detailed metadata format guide, see [METADATA_FORMAT.md](METADATA_FORMAT.md)**

## 🔧 Local Development

To test the build scripts locally:

```bash
# Generate solutions.json
node scripts/generate-solutions.js

# Generate individual solution pages
node scripts/generate-pages.js

# Generate grouped solution pages (recommended)
node scripts/generate-pages-grouped.js

# Generate sitemap.xml
node scripts/generate-sitemap.js

# Open docs/index.html in a browser (use a local server for best results)
cd docs
python -m http.server 8000
# Visit http://localhost:8000
```

## 🔍 SEO Features

- **Meta Tags**: Comprehensive meta tags for social media sharing
- **Sitemap**: XML sitemap for search engine crawling
- **Robots.txt**: Proper search engine instructions
- **Semantic HTML**: Proper HTML5 structure
- **Deep Links**: Each solution has a unique URL anchor

## 📊 Statistics

The site displays:
- Total number of solutions
- Number of programming languages
- Real-time filtered results count

## 🎨 Design Features

- Professional dark theme
- Syntax highlighting with highlight.js
- Responsive grid layout
- Smooth animations and transitions
- Collapsible code sections
- Tag-based categorization

## 🔗 Direct Links

Share specific solutions using URL anchors:
```
https://vermavarun.github.io/coding/#solution-383-csharp
https://vermavarun.github.io/coding/#solution-1-javascript
```

## 📄 License

See the main repository LICENSE file.
