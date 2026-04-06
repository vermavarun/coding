'use client';

import { useState, useMemo } from 'react';
import { SolutionCard } from './SolutionCard';
import { FilterBar } from './FilterBar';

interface Problem {
  problemNumber: string;
  title: string;
  difficulty: 'Easy' | 'Medium' | 'Hard';
  languages: string[];
}

interface ProblemsClientProps {
  problems: Problem[];
  difficulties: string[];
  languages: string[];
}

export function ProblemsClient({ problems, difficulties, languages }: ProblemsClientProps) {
  const [filters, setFilters] = useState({
    difficulty: '',
    language: '',
    search: ''
  });

  const filteredProblems = useMemo(() => {
    return problems.filter(problem => {
      const matchesDifficulty = !filters.difficulty || problem.difficulty === filters.difficulty;
      const matchesLanguage = !filters.language || problem.languages.includes(filters.language);
      const matchesSearch = !filters.search ||
        problem.title.toLowerCase().includes(filters.search.toLowerCase()) ||
        problem.problemNumber.includes(filters.search);

      return matchesDifficulty && matchesLanguage && matchesSearch;
    });
  }, [problems, filters]);

  return (
    <>
      <FilterBar
        difficulties={difficulties}
        languages={languages}
        onFilterChange={setFilters}
      />

      <div className="mb-4 text-sm text-gray-600">
        Showing {filteredProblems.length} of {problems.length} problems
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
        {filteredProblems.map((problem) => (
          <SolutionCard
            key={problem.problemNumber}
            problemNumber={problem.problemNumber}
            title={problem.title}
            difficulty={problem.difficulty}
            languages={problem.languages}
          />
        ))}
      </div>

      {filteredProblems.length === 0 && (
        <div className="text-center py-12 text-gray-500">
          No problems found matching your filters.
        </div>
      )}
    </>
  );
}
