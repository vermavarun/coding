# Auto-Generated Solution Pages

This directory contains automatically generated HTML pages for LeetCode solutions.

**⚠️ DO NOT MANUALLY EDIT FILES HERE**

These files are:
- Generated automatically by GitHub Actions workflow
- Created from source code in `LeetCode/` directory
- Regenerated on every push to main branch
- Deployed to GitHub Pages

## Generation Process

1. Push code to `LeetCode/` directory
2. GitHub Actions runs `generate-solutions.js` to create `solutions.json`
3. `generate-pages-grouped.js` creates HTML pages with tabbed language support
4. `generate-sitemap.xml` creates the sitemap
5. Files are deployed to GitHub Pages

## Local Development

To preview locally:
```bash
npm run generate
# or manually:
node scripts/generate-solutions.js
node scripts/generate-pages-grouped.js
node scripts/generate-sitemap.js
```

Then open `docs/index.html` in your browser.

## File Naming Convention

Format: `{problemNumber}-{title-slug}.html`

Example: `0001-two-sum.html` (contains all languages: C#, Python, Java, etc.)

Each page includes tabbed navigation for different programming language implementations.
