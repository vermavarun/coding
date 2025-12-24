# GitHub Pages Setup Instructions

Follow these steps to enable GitHub Pages for your LeetCode solutions website.

## 1️⃣ Enable GitHub Pages

1. Go to your repository on GitHub: `https://github.com/vermavarun/coding`
2. Click on **Settings** (top right)
3. In the left sidebar, click **Pages** (under "Code and automation")
4. Under "Build and deployment":
   - **Source**: Select "GitHub Actions"
   - This will allow the workflow to deploy automatically

## 2️⃣ Commit and Push

Commit all the new files:

```bash
git add .
git commit -m "Add LeetCode solutions website with GitHub Pages deployment"
git push origin main
```

## 3️⃣ Verify Deployment

1. Go to the **Actions** tab in your repository
2. You should see the "Build and Deploy LeetCode Solutions" workflow running
3. Wait for it to complete (usually takes 1-2 minutes)
4. Once complete, your site will be live at: `https://vermavarun.github.io/coding/`

## 4️⃣ Test Your Site

Visit: `https://vermavarun.github.io/coding/`

You should see:
- All your LeetCode solutions displayed
- Search functionality working
- Filters for language, difficulty, and tags
- Syntax-highlighted code
- Links to GitHub and LeetCode

## 🔄 Automatic Updates

Your site will automatically rebuild and redeploy whenever you:
- Add new solutions to the `LeetCode/` folder
- Update existing solutions
- Modify the website files in `docs/`
- Push changes to the `main` branch

## 🔍 SEO & Google Search

After deployment:
1. Your site will have a sitemap at: `https://vermavarun.github.io/coding/sitemap.xml`
2. Google Search Console (optional):
   - Visit: https://search.google.com/search-console
   - Add your site: `https://vermavarun.github.io/coding/`
   - Submit your sitemap: `https://vermavarun.github.io/coding/sitemap.xml`
   - Google will start indexing your solutions within a few days

## 📊 What Gets Generated

Each time the workflow runs:
- `solutions.json` - Contains all solution metadata and code
- `sitemap.xml` - SEO sitemap with all solution URLs
- The site is deployed to GitHub Pages

## 🛠️ Troubleshooting

### Workflow fails
- Check the Actions tab for error messages
- Ensure Node.js scripts have no syntax errors
- Verify all paths are correct

### Site not updating
- Check if the workflow completed successfully
- Clear browser cache (Ctrl+Shift+R or Cmd+Shift+R)
- Wait a few minutes for GitHub Pages CDN to update

### Solutions not appearing
- Verify your solution files follow the comment format
- Check `solutions.json` was generated correctly
- Look at browser console for JavaScript errors

## 📝 Adding New Solutions

Just add your solution files to the `LeetCode/` folder following the naming convention:
- `0001-TwoSum.cs`
- `0002-AddTwoNumbers.js`
- etc.

The site will automatically update on your next push!

## 🎨 Customization

To customize the site:
- **Styling**: Edit `docs/styles.css`
- **Layout**: Edit `docs/index.html`
- **Functionality**: Edit `docs/app.js`
- **Metadata**: Update meta tags in `docs/index.html`

After making changes, commit and push - the site will update automatically!
