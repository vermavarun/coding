import type { Metadata } from 'next';
import { notFound } from 'next/navigation';
import Link from 'next/link';
import { getProblemById, getAllProblems } from '@/lib/solutions';
import { CodeBlock } from '@/components/CodeBlock';

interface Props {
  params: Promise<{
    problemNumber: string;
  }>;
}

export async function generateMetadata({ params }: Props): Promise<Metadata> {
  const { problemNumber } = await params;
  const solutions = getProblemById(problemNumber);

  if (!solutions || solutions.length === 0) {
    return {
      title: 'Problem Not Found',
    };
  }

  const solution = solutions[0];
  return {
    title: `${solution.problemNumber}. ${solution.title}`,
    description: `${solution.difficulty} - ${solution.approach}. Available in ${solutions.map(s => s.language).join(', ')}. ${solution.tip}`,
    keywords: solution.tags.join(', '),
    openGraph: {
      title: `${solution.problemNumber}. ${solution.title}`,
      description: solution.approach,
      type: 'article',
    },
  };
}

export async function generateStaticParams() {
  const problemsMap = getAllProblems();
  const problemNumbers = Array.from(problemsMap.keys());

  return problemNumbers.map((problemNumber) => ({
    problemNumber,
  }));
}

const difficultyColors = {
  Easy: 'bg-green-100 text-green-800 border-green-300',
  Medium: 'bg-yellow-100 text-yellow-800 border-yellow-300',
  Hard: 'bg-red-100 text-red-800 border-red-300',
};

export default async function ProblemPage({ params }: Props) {
  const { problemNumber } = await params;
  const solutions = getProblemById(problemNumber);

  if (!solutions || solutions.length === 0) {
    notFound();
  }

  const mainSolution = solutions[0]!;

  return (
    <div className="min-h-screen bg-gray-50">
      {/* Header */}
      <header className="bg-white shadow-sm border-b sticky top-0 z-10">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-4">
          <div className="flex items-center justify-between">
            <Link href="/" className="text-blue-600 hover:text-blue-800 font-medium">
              ← Back to All Problems
            </Link>
            {mainSolution.solutionLink && (
              <a
                href={mainSolution.solutionLink}
                target="_blank"
                rel="noopener noreferrer"
                className="text-sm text-blue-600 hover:text-blue-800"
              >
                View on LeetCode →
              </a>
            )}
          </div>
        </div>
      </header>

      <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        {/* Problem Header */}
        <div className="bg-white rounded-lg shadow-sm border p-6 mb-6">
          <div className="flex items-start justify-between mb-4">
            <h1 className="text-3xl font-bold text-gray-900">
              {mainSolution.problemNumber}. {mainSolution.title}
            </h1>
            <span className={`px-3 py-1 rounded-full text-sm font-medium border ${difficultyColors[mainSolution.difficulty]}`}>
              {mainSolution.difficulty}
            </span>
          </div>

          {/* Tags */}
          {mainSolution.tags.length > 0 && (
            <div className="mb-4">
              <h3 className="text-sm font-semibold text-gray-700 mb-2">Topics</h3>
              <div className="flex flex-wrap gap-2">
                {mainSolution.tags.map((tag) => (
                  <span
                    key={tag}
                    className="px-2 py-1 bg-gray-100 text-gray-700 rounded text-xs"
                  >
                    {tag}
                  </span>
                ))}
              </div>
            </div>
          )}

          {/* Approach */}
          {mainSolution.approach && (
            <div className="mb-4">
              <h3 className="text-sm font-semibold text-gray-700 mb-2">Approach</h3>
              <p className="text-gray-800">{mainSolution.approach}</p>
            </div>
          )}

          {/* Complexity */}
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mb-4">
            {mainSolution.timeComplexity && (
              <div className="bg-blue-50 rounded-lg p-3 border border-blue-200">
                <h3 className="text-xs font-semibold text-blue-700 mb-1">Time Complexity</h3>
                <p className="text-sm text-blue-900 font-mono">{mainSolution.timeComplexity}</p>
              </div>
            )}
            {mainSolution.spaceComplexity && (
              <div className="bg-purple-50 rounded-lg p-3 border border-purple-200">
                <h3 className="text-xs font-semibold text-purple-700 mb-1">Space Complexity</h3>
                <p className="text-sm text-purple-900 font-mono">{mainSolution.spaceComplexity}</p>
              </div>
            )}
          </div>

          {/* Steps */}
          {mainSolution.steps.length > 0 && (
            <div className="mb-4">
              <h3 className="text-sm font-semibold text-gray-700 mb-2">Algorithm Steps</h3>
              <ol className="space-y-1">
                {mainSolution.steps.map((step, index) => (
                  <li key={index} className="text-gray-700 text-sm">
                    {step}
                  </li>
                ))}
              </ol>
            </div>
          )}

          {/* Tip */}
          {mainSolution.tip && (
            <div className="bg-amber-50 border border-amber-200 rounded-lg p-4 mb-4">
              <h3 className="text-sm font-semibold text-amber-800 mb-2">💡 Tip</h3>
              <p className="text-sm text-amber-900">{mainSolution.tip}</p>
            </div>
          )}

          {/* Similar Problems */}
          {mainSolution.similarProblems && (
            <div className="bg-gray-50 border border-gray-200 rounded-lg p-4">
              <h3 className="text-sm font-semibold text-gray-700 mb-2">Similar Problems</h3>
              <p className="text-sm text-gray-700">{mainSolution.similarProblems}</p>
            </div>
          )}
        </div>

        {/* Language Tabs */}
        <div className="bg-white rounded-lg shadow-sm border overflow-hidden">
          <div className="border-b bg-gray-50 px-6 py-3">
            <h2 className="text-lg font-semibold text-gray-900">Solutions</h2>
          </div>

          <div className="p-6">
            {solutions.map((solution, index) => (
              <div key={index} className="mb-8 last:mb-0">
                <div className="flex items-center justify-between mb-3">
                  <h3 className="text-md font-semibold text-gray-900 flex items-center gap-2">
                    <span className="px-2 py-1 bg-blue-100 text-blue-800 rounded text-sm">
                      {solution.language}
                    </span>
                    {solution.filename}
                  </h3>
                  <a
                    href={solution.githubUrl}
                    target="_blank"
                    rel="noopener noreferrer"
                    className="text-sm text-blue-600 hover:text-blue-800"
                  >
                    View on GitHub
                  </a>
                </div>
                <CodeBlock code={solution.code} language={solution.language} />
              </div>
            ))}
          </div>
        </div>
      </main>

      {/* Footer */}
      <footer className="bg-white border-t mt-12">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-6">
          <div className="text-center text-sm text-gray-600">
            <p>© {new Date().getFullYear()} Varun Verma. All rights reserved.</p>
          </div>
        </div>
      </footer>
    </div>
  );
}
