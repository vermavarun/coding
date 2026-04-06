import { MetadataRoute } from 'next';
import { getAllProblems } from '@/lib/solutions';

export const dynamic = 'force-static';

export default function sitemap(): MetadataRoute.Sitemap {
  const baseUrl = 'https://vermavarun.github.io/coding';

  const problemsMap = getAllProblems();
  const problemPages = Array.from(problemsMap.keys()).map((problemNumber) => ({
    url: `${baseUrl}/problems/${problemNumber}`,
    lastModified: new Date(),
    changeFrequency: 'monthly' as const,
    priority: 0.8,
  }));

  return [
    {
      url: baseUrl,
      lastModified: new Date(),
      changeFrequency: 'daily',
      priority: 1,
    },
    ...problemPages,
  ];
}
