# Setup Guide for LeetCode Solutions Site

This guide will help you set up and deploy the LeetCode solutions website with server-side rendering for optimal SEO.

## Prerequisites

- Node.js 20 or higher
- npm (comes with Node.js)
- Git

## Quick Start

### 1. Install Dependencies

```bash
cd app
npm install
```

### 2. Generate Solutions Data

```bash
npm run generate
```

This will run the `scripts/generate-solutions.js` script to create the `docs/solutions.json` file from your LeetCode solutions.

### 3. Run Development Server

```bash
npm run dev
```

Open [http://localhost:3000](http://localhost:3000) to view the site locally.

### 4. Build for Production

```bash
npm run build
```

The static site will be exported to the `app/out` directory.

## Project Structure

```
coding/
├── LeetCode/                 # Your LeetCode solutions (source of truth)
│   ├── C#/
│   ├── Java/
│   ├── Python/
│   ├── JavaScript/
│   ├── Go/
│   ├── SQL/
│   └── Bash/
├── scripts/                  # Build scripts
│   ├── generate-solutions.js # Parses LeetCode files → solutions.json
│   ├── generate-pages-grouped.js
│   ├── generate-sitemap.js
│   └── generate-solutions.js
├── docs/                     # Legacy static site (being replaced)
│   └── solutions.json        # Generated data file (read by Next.js app)
└── app/                      # Next.js application (NEW)
    ├── app/
    │   ├── layout.tsx        # Root layout with SEO metadata
    │   ├── page.tsx          # Home page (all problems)
    │   ├── loading.tsx       # Loading UI
    │   ├── not-found.tsx     # 404 page
    │   ├── robots.ts         # Robots.txt (dynamic)
    │   ├── sitemap.ts        # Sitemap (dynamic)
    │   └── problems/
    │       └── [problemNumber]/
    │           ├── page.tsx  # Individual problem page (SSG)
    │           └── not-found.tsx
    ├── components/
    │   ├── CodeBlock.tsx
    │   ├── FilterBar.tsx
    │   ├── ProblemsClient.tsx
    │   └── SolutionCard.tsx
    ├── lib/
    │   └── solutions.ts      # Data fetching utilities
    ├── scripts/
    │   └── postbuild.js      # Post-build script (.nojekyll)
    ├── next.config.ts        # Next.js configuration
    └── package.json
```

## How It Works

### 1. Data Flow

```
LeetCode Solutions (*.cs, *.java, *.py, etc.)
          ↓
  generate-solutions.js
          ↓
    solutions.json
          ↓
   Next.js App (reads at build time)
          ↓
  Static HTML pages (app/out/)
          ↓
   GitHub Pages Deployment
```

### 2. Build Process

1. **Generate Data**: `generate-solutions.js` scans all files in the `LeetCode/` folder
2. **Parse Metadata**: Extracts problem number, title, difficulty, approach, tags, code, etc.
3. **Create JSON**: Outputs structured data to `docs/solutions.json`
4. **Build Next.js**: Next.js reads `solutions.json` and generates static HTML pages
5. **Static Export**: All pages are pre-rendered and exported to `app/out/`
6. **Deploy**: GitHub Actions deploys the `app/out/` directory to GitHub Pages

### 3. SEO Features

The new Next.js app includes:

✅ **Server-Side Rendering (SSR)** - Content is pre-rendered at build time
✅ **Static Generation** - All 296+ problem pages are generated upfront
✅ **Dynamic Sitemap** - Auto-generated from solutions data
✅ **Dynamic Robots.txt** - Configured for optimal crawling
✅ **Rich Metadata** - Title, description, keywords for each page
✅ **Open Graph Tags** - For social media sharing
✅ **Semantic HTML** - Proper heading structure, landmarks
✅ **Mobile Responsive** - Works on all devices
✅ **Fast Loading** - Optimized static files

## Deployment

### GitHub Pages (Automatic)

The site automatically deploys when you push to the `main` branch:

1. GitHub Actions triggers on push
2. Runs `generate-solutions.js`
3. Installs Next.js dependencies
4. Builds Next.js app (`npm run build`)
5. Deploys `app/out/` to GitHub Pages

### Manual Deployment

```bash
# 1. Generate solutions data
npm run generate

# 2. Build the app
npm run build

# 3. The app/out/ directory is ready to deploy
# You can deploy it to any static hosting service
```

## Configuration

### Base Path (for GitHub Pages)

The app is configured to work with GitHub Pages at `https://vermavarun.github.io/coding/`.

If you want to deploy to a different path:

1. Update `next.config.ts`:
   ```typescript
   basePath: '/your-path-here',
   ```

2. Update `app/lib/solutions.ts` metadataBase:
   ```typescript
   metadataBase: new URL('https://yourdomain.com'),
   ```

### Adding New Solutions

Simply add new solution files to the `LeetCode/` folder with proper metadata comments, then:

```bash
npm run generate  # Regenerate solutions.json
npm run build     # Rebuild the site
```

Or just push to GitHub and let the workflow handle it automatically.

## Troubleshooting

### "solutions.json not found" Error

Run `npm run generate` from the `app/` directory to create the JSON file.

### Pages Not Updating

1. Delete the `app/.next` and `app/out` directories
2. Run `npm run generate` to regenerate data
3. Run `npm run build` to rebuild

### 404 on GitHub Pages

Make sure:
1. The `.nojekyll` file exists in `app/out/`
2. GitHub Pages is configured to deploy from "GitHub Actions"
3. The workflow has proper permissions (check `.github/workflows/deploy-leetcode-site.yml`)

## Verifying SEO

1. **Google Search Console**: Add your site and submit the sitemap
2. **Robots.txt**: Visit `https://vermavarun.github.io/coding/robots.txt`
3. **Sitemap**: Visit `https://vermavarun.github.io/coding/sitemap.xml`
4. **Individual Pages**: Verify each problem page renders with full content

## Google Search Indexing

After deployment, your solutions will be indexed by Google because:

1. ✅ All content is pre-rendered HTML (not client-side JavaScript)
2. ✅ Each page has unique metadata (title, description, keywords)
3. ✅ Sitemap lists all pages for crawlers
4. ✅ Robots.txt allows all crawlers
5. ✅ Semantic HTML structure
6. ✅ Fast loading times
7. ✅ Mobile-friendly design

To speed up indexing:
- Submit your sitemap to Google Search Console
- Request indexing for important pages
- Share links on social media (Open Graph tags will help)

## Resources

- [Next.js Documentation](https://nextjs.org/docs)
- [Next.js Static Export](https://nextjs.org/docs/app/building-your-application/deploying/static-exports)
- [GitHub Pages Documentation](https://docs.github.com/en/pages)
- [Google Search Console](https://search.google.com/search-console)

## License

© 2026 Varun Verma. All rights reserved.
