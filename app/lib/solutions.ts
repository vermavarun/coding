import fs from 'fs';
import path from 'path';

export interface Solution {
  problemNumber: string;
  title: string;
  language: string;
  difficulty: 'Easy' | 'Medium' | 'Hard';
  filename: string;
  path: string;
  githubUrl: string;
  approach: string;
  tags: string[];
  steps: string[];
  timeComplexity: string;
  spaceComplexity: string;
  solutionLink: string;
  tip: string;
  similarProblems: string;
  code: string;
}

export interface SolutionsData {
  stats: {
    totalSolutions: number;
    languages: string[];
    tags: string[];
    lastUpdated: string;
    uniqueProblems: number;
  };
  solutions: Solution[];
}

export function getSolutionsData(): SolutionsData {
  const solutionsPath = path.join(process.cwd(), '..', 'docs', 'solutions.json');

  if (!fs.existsSync(solutionsPath)) {
    throw new Error('solutions.json not found. Please run generate-solutions.js first.');
  }

  const fileContents = fs.readFileSync(solutionsPath, 'utf8');
  return JSON.parse(fileContents);
}

export function getAllProblems(): Map<string, Solution[]> {
  const data = getSolutionsData();
  const problemsMap = new Map<string, Solution[]>();

  data.solutions.forEach(solution => {
    const key = solution.problemNumber;
    if (!problemsMap.has(key)) {
      problemsMap.set(key, []);
    }
    problemsMap.get(key)!.push(solution);
  });

  return problemsMap;
}

export function getProblemById(problemNumber: string): Solution[] | null {
  const problemsMap = getAllProblems();
  return problemsMap.get(problemNumber) || null;
}

export function getUniqueProblemList(): Array<{
  problemNumber: string;
  title: string;
  difficulty: 'Easy' | 'Medium' | 'Hard';
  languages: string[];
}> {
  const problemsMap = getAllProblems();
  const uniqueProblems: Array<{
    problemNumber: string;
    title: string;
    difficulty: 'Easy' | 'Medium' | 'Hard';
    languages: string[];
  }> = [];

  problemsMap.forEach((solutions, problemNumber) => {
    if (solutions.length > 0) {
      uniqueProblems.push({
        problemNumber,
        title: solutions[0].title,
        difficulty: solutions[0].difficulty,
        languages: solutions.map(s => s.language)
      });
    }
  });

  // Sort by problem number
  uniqueProblems.sort((a, b) => parseInt(a.problemNumber) - parseInt(b.problemNumber));

  return uniqueProblems;
}
