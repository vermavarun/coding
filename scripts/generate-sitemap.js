const fs = require('fs');
const path = require('path');

const SOLUTIONS_FILE = path.join(__dirname, '..', 'docs', 'solutions.json');
const SITEMAP_FILE = path.join(__dirname, '..', 'docs', 'sitemap.xml');
const BASE_URL = 'https://vermavarun.github.io/coding';

function generateSitemap() {
    console.log('Generating sitemap...');

    // Read solutions.json
    const data = JSON.parse(fs.readFileSync(SOLUTIONS_FILE, 'utf-8'));
    const solutions = data.solutions;

    // Start sitemap XML
    let xml = '<?xml version="1.0" encoding="UTF-8"?>\n';
    xml += '<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">\n';

    // Add homepage
    xml += '  <url>\n';
    xml += `    <loc>${BASE_URL}/</loc>\n`;
    xml += `    <lastmod>${new Date().toISOString().split('T')[0]}</lastmod>\n`;
    xml += '    <changefreq>daily</changefreq>\n';
    xml += '    <priority>1.0</priority>\n';
    xml += '  </url>\n';

    // Add each solution
    solutions.forEach(solution => {
        const langSafe = solution.language.replace('#', 'sharp');
        const anchor = `#solution-${solution.problemNumber}-${langSafe}`;

        xml += '  <url>\n';
        xml += `    <loc>${BASE_URL}/${anchor}</loc>\n`;
        xml += `    <lastmod>${new Date().toISOString().split('T')[0]}</lastmod>\n`;
        xml += '    <changefreq>weekly</changefreq>\n';
        xml += '    <priority>0.8</priority>\n';
        xml += '  </url>\n';
    });

    xml += '</urlset>';

    // Write sitemap
    fs.writeFileSync(SITEMAP_FILE, xml);
    console.log(`Generated ${SITEMAP_FILE} with ${solutions.length + 1} URLs`);
}

try {
    generateSitemap();
} catch (error) {
    console.error('Error generating sitemap:', error);
    process.exit(1);
}
