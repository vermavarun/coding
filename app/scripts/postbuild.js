const fs = require('fs');
const path = require('path');

// Create .nojekyll file in the out directory
const outDir = path.join(__dirname, '..', 'out');

if (fs.existsSync(outDir)) {
  fs.writeFileSync(path.join(outDir, '.nojekyll'), '');
  console.log('✅ Created .nojekyll file');
} else {
  console.error('❌ Out directory does not exist');
  process.exit(1);
}
