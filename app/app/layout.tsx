import type { Metadata } from "next";
import { Geist, Geist_Mono } from "next/font/google";
import "./globals.css";

const geistSans = Geist({
  variable: "--font-geist-sans",
  subsets: ["latin"],
});

const geistMono = Geist_Mono({
  variable: "--font-geist-mono",
  subsets: ["latin"],
});

export const metadata: Metadata = {
  title: {
    default: "LeetCode Solutions by Varun Verma",
    template: "%s | LeetCode Solutions by Varun Verma"
  },
  description: "Comprehensive LeetCode solutions in multiple programming languages with detailed explanations, complexity analysis, and tips for interview preparation.",
  keywords: ["LeetCode", "coding solutions", "algorithms", "data structures", "interview preparation", "C#", "Java", "Python", "JavaScript", "Go", "SQL"],
  authors: [{ name: "Varun Verma" }],
  creator: "Varun Verma",
  publisher: "Varun Verma",
  metadataBase: new URL('https://vermavarun.github.io'),
  openGraph: {
    type: 'website',
    locale: 'en_US',
    siteName: 'LeetCode Solutions by Varun Verma',
  },
  robots: {
    index: true,
    follow: true,
    googleBot: {
      index: true,
      follow: true,
      'max-video-preview': -1,
      'max-image-preview': 'large',
      'max-snippet': -1,
    },
  },
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html
      lang="en"
      className={`${geistSans.variable} ${geistMono.variable} h-full antialiased`}
    >
      <body className="min-h-full flex flex-col">{children}</body>
    </html>
  );
}
