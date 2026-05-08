/*
Title: 3629. Minimum Jumps to Reach End via Prime Teleportation
Difficulty: Medium
Solution: https://leetcode.com/problems/minimum-jumps-to-reach-end-via-prime-teleportation/solutions/8172632/simplest-solution-c-time-on-m-log-log-m-wcpdk/
Approach: BFS + Sieve of Eratosthenes
Tags: Array, BFS, Math, Number Theory
1) Build a Sieve of Eratosthenes to identify all primes up to the maximum value in nums.
2) Build a map from each value to all indices where it appears.
3) Start BFS from index 0; each BFS level represents one jump.
4) From each index, explore: adjacent left/right indices, and — if the current value is prime — all indices whose values are multiples of that prime.
5) Track processed prime values to avoid re-expanding the same set of multiples multiple times.
6) Return the jump count when index n-1 is reached; return -1 if the queue is exhausted.

Time Complexity: O(n + M log log M) where n = nums.length and M = max(nums) (Sieve dominates)
Space Complexity: O(n + M) for the index map and the sieve array
Tip: The key optimisation is marking a prime value as "processed" after its multiples are enqueued — without this, the same prime could trigger O(n) redundant work every time it appears in the queue.
Similar Problems: 1345. Jump Game IV, 815. Bus Routes, 2612. Minimum Reverse Operations
*/
public class Solution
{
    // isPrime[number] = true if the number is prime
    private bool[] isPrime;

    /// <summary>
    /// Builds a Sieve of Eratosthenes to quickly check
    /// whether a number is prime or not.
    /// </summary>
    private void BuildPrimeSieve(int maximumValue)
    {
        isPrime = new bool[maximumValue + 1];

        // Initially assume every number is prime
        Array.Fill(isPrime, true);

        // 0 and 1 are not prime numbers
        if (maximumValue >= 0)
            isPrime[0] = false;

        if (maximumValue >= 1)
            isPrime[1] = false;

        // Mark multiples of each prime as non-prime
        for (int currentNumber = 2;
             currentNumber * currentNumber <= maximumValue;
             currentNumber++)
        {
            if (!isPrime[currentNumber])
                continue;

            // Start from currentNumber² because smaller multiples
            // would already have been processed
            for (int multiple = currentNumber * currentNumber;
                 multiple <= maximumValue;
                 multiple += currentNumber)
            {
                isPrime[multiple] = false;
            }
        }
    }

    public int MinJumps(int[] nums)
    {
        int arrayLength = nums.Length;

        // Maps each number -> list of indices where it appears
        Dictionary<int, List<int>> valueToIndicesMap =
            new Dictionary<int, List<int>>();

        int maximumValue = 0;

        // Build lookup map and find maximum element
        for (int index = 0; index < arrayLength; index++)
        {
            if (!valueToIndicesMap.ContainsKey(nums[index]))
            {
                valueToIndicesMap[nums[index]] = new List<int>();
            }

            valueToIndicesMap[nums[index]].Add(index);

            maximumValue = Math.Max(maximumValue, nums[index]);
        }

        // Precompute prime numbers up to maximumValue
        BuildPrimeSieve(maximumValue);

        // Standard BFS setup
        Queue<int> bfsQueue = new Queue<int>();
        bool[] visitedIndices = new bool[arrayLength];

        bfsQueue.Enqueue(0);
        visitedIndices[0] = true;

        // Prevents processing the same prime value multiple times
        HashSet<int> processedPrimeValues = new HashSet<int>();

        int jumpCount = 0;

        while (bfsQueue.Count > 0)
        {
            int currentLevelSize = bfsQueue.Count;

            // Process one BFS level at a time
            while (currentLevelSize-- > 0)
            {
                int currentIndex = bfsQueue.Dequeue();

                // Reached destination
                if (currentIndex == arrayLength - 1)
                {
                    return jumpCount;
                }

                // Move to previous index
                int previousIndex = currentIndex - 1;

                if (previousIndex >= 0 &&
                    !visitedIndices[previousIndex])
                {
                    bfsQueue.Enqueue(previousIndex);
                    visitedIndices[previousIndex] = true;
                }

                // Move to next index
                int nextIndex = currentIndex + 1;

                if (nextIndex < arrayLength &&
                    !visitedIndices[nextIndex])
                {
                    bfsQueue.Enqueue(nextIndex);
                    visitedIndices[nextIndex] = true;
                }

                int currentValue = nums[currentIndex];

                // Prime-based jumps are allowed only once per prime value
                if (!isPrime[currentValue] ||
                    processedPrimeValues.Contains(currentValue))
                {
                    continue;
                }

                // Jump to every index containing a multiple
                // of the current prime value
                for (int multiple = currentValue;
                     multiple <= maximumValue;
                     multiple += currentValue)
                {
                    // Skip if this multiple does not exist in array
                    if (!valueToIndicesMap.ContainsKey(multiple))
                    {
                        continue;
                    }

                    // Visit all indices having this multiple
                    foreach (int targetIndex in valueToIndicesMap[multiple])
                    {
                        if (visitedIndices[targetIndex])
                            continue;

                        bfsQueue.Enqueue(targetIndex);
                        visitedIndices[targetIndex] = true;
                    }
                }

                // Mark this prime value as processed
                // so we do not repeat expensive multiple traversal
                processedPrimeValues.Add(currentValue);
            }

            // One BFS level completed = one jump
            jumpCount++;
        }

        // Destination cannot be reached
        return -1;
    }
}