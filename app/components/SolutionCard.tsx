import Link from 'next/link';

interface SolutionCardProps {
  problemNumber: string;
  title: string;
  difficulty: 'Easy' | 'Medium' | 'Hard';
  languages: string[];
}

const difficultyColors = {
  Easy: 'bg-green-100 text-green-800 border-green-300',
  Medium: 'bg-yellow-100 text-yellow-800 border-yellow-300',
  Hard: 'bg-red-100 text-red-800 border-red-300',
};

export function SolutionCard({ problemNumber, title, difficulty, languages }: SolutionCardProps) {
  return (
    <Link href={`/problems/${problemNumber}`} className="block">
      <div className="border rounded-lg p-4 hover:shadow-lg transition-shadow duration-200 bg-white">
        <div className="flex items-start justify-between mb-2">
          <div className="flex-1">
            <h3 className="font-semibold text-lg text-gray-900">
              {problemNumber}. {title}
            </h3>
          </div>
          <span className={`px-3 py-1 rounded-full text-xs font-medium border ${difficultyColors[difficulty]}`}>
            {difficulty}
          </span>
        </div>
        <div className="flex flex-wrap gap-2 mt-3">
          {languages.map((lang) => (
            <span
              key={lang}
              className="px-2 py-1 bg-blue-50 text-blue-700 rounded text-xs font-medium"
            >
              {lang}
            </span>
          ))}
        </div>
      </div>
    </Link>
  );
}
