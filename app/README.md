# LeetCode Solutions Next.js App

This is a Next.js application that displays LeetCode solutions with server-side rendering for optimal SEO and Google indexing.

## Features

- 🚀 **Server-Side Rendering (SSR)** - All solution pages are pre-rendered for search engines
- 🔍 **SEO Optimized** - Comprehensive metadata, sitemap, and robots.txt
- 🎨 **Modern UI** - Clean, responsive design with Tailwind CSS
- 🔎 **Search & Filter** - Filter by difficulty, language, and search by problem name
- 📱 **Mobile Responsive** - Works perfectly on all devices
- 🏷️ **Rich Metadata** - Each solution includes tags, complexity analysis, and tips

## Getting Started

First, install dependencies:

```bash
npm install
```

Make sure the `solutions.json` file is generated:

```bash
cd ..
node scripts/generate-solutions.js
```

Run the development server:

```bash
npm run dev
```

Open [http://localhost:3000](http://localhost:3000) with your browser to see the result.

## Build for Production

```bash
npm run build
```

The static site will be exported to the `out` directory.

## Project Structure

```
app/
├── app/
│   ├── layout.tsx           # Root layout with metadata
│   ├── page.tsx             # Home page with all problems
│   ├── robots.ts            # Robots.txt configuration
│   ├── sitemap.ts           # Dynamic sitemap generation
│   └── problems/
│       └── [problemNumber]/ # Dynamic routes for each problem
│           ├── page.tsx     # Individual problem page
│           └── not-found.tsx
├── components/
│   ├── CodeBlock.tsx        # Code display component
│   ├── FilterBar.tsx        # Search and filter UI
│   ├── ProblemsClient.tsx   # Client-side filtering logic
│   └── SolutionCard.tsx     # Problem card component
└── lib/
    └── solutions.ts         # Data fetching utilities
```

## SEO Features

- ✅ Semantic HTML structure
- ✅ Meta tags for each page
- ✅ Open Graph tags for social sharing
- ✅ Dynamic sitemap generation
- ✅ Robots.txt configuration
- ✅ Static site generation for all pages
- ✅ Fast page load times
- ✅ Mobile-responsive design

## Technologies

- **Next.js 16.2.2** - React framework with SSR and static generation
- **React 19.2.4** - UI library
- **TypeScript** - Type safety
- **Tailwind CSS 4** - Styling

## License

© 2026 Varun Verma. All rights reserved.
