using System;

namespace anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "tree";
            string str2 = "rtee";
            bool areAnagram = isAnagram(str1, str2);
            Console.WriteLine("String is Anagram -> " + areAnagram);
        }

        /// Assuming 255 characters allowed 
        public static bool isAnagram(string str1, string str2)
        {
            char[] str11 = str1.ToCharArray();
            char[] str22 = str2.ToCharArray();

            if (str11.Length != str22.Length)
                return false;

            int[] count = new int[256];
            int i;

            for (i = 0; i < str1.Length; i++)
            {
                count[(int)str11[i]]++;
                count[(int)str22[i]]--;
            }

            for (i = 0; i < 256; i++)
                if (count[i] != 0)
                {
                    return false;
                }

            return true;

        }
    }
}
