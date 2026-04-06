import type { Metadata } from 'next';
import { getSolutionsData, getUniqueProblemList } from '@/lib/solutions';
import { ProblemsClient } from '@/components/ProblemsClient';

export const metadata: Metadata = {
  title: 'LeetCode Solutions by Varun Verma | 296+ Problems Solved',
  description: 'Comprehensive LeetCode solutions in C#, Java, Python, JavaScript, Go, SQL, and Bash. 296+ problems with detailed explanations, time/space complexity analysis, and tips.',
  keywords: 'LeetCode, coding solutions, algorithms, data structures, C#, Java, Python, JavaScript, interview preparation',
  openGraph: {
    title: 'LeetCode Solutions by Varun Verma',
    description: '296+ LeetCode problems solved with detailed explanations',
    type: 'website',
  },
};

export default function Home() {
  const data = getSolutionsData();
  const problems = getUniqueProblemList();

  const difficulties = ['Easy', 'Medium', 'Hard'];
  const languages = data.stats.languages;

  return (
    <div className="min-h-screen bg-gray-50">
      {/* Header */}
      <header className="bg-white shadow-sm border-b">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-6">
          <div className="flex items-center justify-between">
            <div>
              <h1 className="text-3xl font-bold text-gray-900">
                LeetCode Solutions
              </h1>
              <p className="mt-1 text-sm text-gray-600">
                by Varun Verma
              </p>
            </div>
            <div className="text-right">
              <div className="text-2xl font-bold text-blue-600">
                {data.stats.uniqueProblems}
              </div>
              <div className="text-sm text-gray-600">
                Problems Solved
              </div>
            </div>
          </div>

          {/* Stats Bar */}
          <div className="mt-6 grid grid-cols-2 md:grid-cols-4 gap-4">
            <div className="bg-blue-50 rounded-lg p-3 border border-blue-200">
              <div className="text-xs text-blue-600 font-medium">Total Solutions</div>
              <div className="text-xl font-bold text-blue-900">{data.stats.totalSolutions}</div>
            </div>
            <div className="bg-green-50 rounded-lg p-3 border border-green-200">
              <div className="text-xs text-green-600 font-medium">Languages</div>
              <div className="text-xl font-bold text-green-900">{data.stats.languages.length}</div>
            </div>
            <div className="bg-purple-50 rounded-lg p-3 border border-purple-200">
              <div className="text-xs text-purple-600 font-medium">Topics</div>
              <div className="text-xl font-bold text-purple-900">{data.stats.tags.length}</div>
            </div>
            <div className="bg-orange-50 rounded-lg p-3 border border-orange-200">
              <div className="text-xs text-orange-600 font-medium">Last Updated</div>
              <div className="text-xs font-bold text-orange-900">
                {new Date(data.stats.lastUpdated).toLocaleDateString()}
              </div>
            </div>
          </div>
        </div>
      </header>

      {/* Main Content */}
      <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        <ProblemsClient
          problems={problems}
          difficulties={difficulties}
          languages={languages}
        />
      </main>

      {/* Footer */}
      <footer className="bg-white border-t mt-12">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-6">
          <div className="text-center text-sm text-gray-600">
            <p>© {new Date().getFullYear()} Varun Verma. All rights reserved.</p>
            <p className="mt-1">
              <a
                href="https://github.com/vermavarun/coding"
                target="_blank"
                rel="noopener noreferrer"
                className="text-blue-600 hover:text-blue-800"
              >
                View on GitHub
              </a>
            </p>
          </div>
        </div>
      </footer>
    </div>
  );
}
