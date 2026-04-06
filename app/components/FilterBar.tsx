'use client';

import { useState } from 'react';

interface FilterBarProps {
  difficulties: string[];
  languages: string[];
  onFilterChange: (filters: { difficulty: string; language: string; search: string }) => void;
}

export function FilterBar({ difficulties, languages, onFilterChange }: FilterBarProps) {
  const [difficulty, setDifficulty] = useState('');
  const [language, setLanguage] = useState('');
  const [search, setSearch] = useState('');

  const handleFilterChange = (newDifficulty?: string, newLanguage?: string, newSearch?: string) => {
    const updatedDifficulty = newDifficulty !== undefined ? newDifficulty : difficulty;
    const updatedLanguage = newLanguage !== undefined ? newLanguage : language;
    const updatedSearch = newSearch !== undefined ? newSearch : search;

    if (newDifficulty !== undefined) setDifficulty(newDifficulty);
    if (newLanguage !== undefined) setLanguage(newLanguage);
    if (newSearch !== undefined) setSearch(newSearch);

    onFilterChange({
      difficulty: updatedDifficulty,
      language: updatedLanguage,
      search: updatedSearch
    });
  };

  return (
    <div className="bg-white p-4 rounded-lg shadow-sm border mb-6">
      <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
        <div>
          <label htmlFor="search" className="block text-sm font-medium text-gray-700 mb-1">
            Search
          </label>
          <input
            id="search"
            type="text"
            placeholder="Search problems..."
            value={search}
            onChange={(e) => handleFilterChange(undefined, undefined, e.target.value)}
            className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
        </div>

        <div>
          <label htmlFor="difficulty" className="block text-sm font-medium text-gray-700 mb-1">
            Difficulty
          </label>
          <select
            id="difficulty"
            value={difficulty}
            onChange={(e) => handleFilterChange(e.target.value)}
            className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
          >
            <option value="">All Difficulties</option>
            {difficulties.map((diff) => (
              <option key={diff} value={diff}>
                {diff}
              </option>
            ))}
          </select>
        </div>

        <div>
          <label htmlFor="language" className="block text-sm font-medium text-gray-700 mb-1">
            Language
          </label>
          <select
            id="language"
            value={language}
            onChange={(e) => handleFilterChange(undefined, e.target.value)}
            className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
          >
            <option value="">All Languages</option>
            {languages.map((lang) => (
              <option key={lang} value={lang}>
                {lang}
              </option>
            ))}
          </select>
        </div>
      </div>
    </div>
  );
}
