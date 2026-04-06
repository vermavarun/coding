'use client';

interface CodeBlockProps {
  code: string;
  language: string;
}

const languageMap: Record<string, string> = {
  'C#': 'csharp',
  'JavaScript': 'javascript',
  'Python': 'python',
  'Java': 'java',
  'Go': 'go',
  'SQL': 'sql',
  'Bash': 'bash',
};

export function CodeBlock({ code, language }: CodeBlockProps) {
  const handleCopy = () => {
    navigator.clipboard.writeText(code);
  };

  return (
    <div className="relative">
      <button
        onClick={handleCopy}
        className="absolute top-2 right-2 px-3 py-1 bg-gray-700 hover:bg-gray-600 text-white text-xs rounded transition-colors"
      >
        Copy
      </button>
      <pre className="bg-gray-900 text-gray-100 p-4 rounded-lg overflow-x-auto">
        <code className={`language-${languageMap[language] || 'plaintext'}`}>
          {code}
        </code>
      </pre>
    </div>
  );
}
