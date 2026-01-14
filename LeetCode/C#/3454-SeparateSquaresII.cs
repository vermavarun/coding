/*
Title: 3454. Separate Squares II
Solution:
Difficulty: Hard
Approach: Sweep Line with Segment Tree for Union Area Calculation
Tags: Sweep Line, Segment Tree, Geometry, Coordinate Compression
1) Create horizontal sweep line events at square tops and bottoms.
2) Collect all unique x-coordinates for coordinate compression.
3) Sort events by y-coordinate to process from bottom to top.
4) Calculate total union area using segment tree to track covered widths.
5) Process events again, accumulating area until reaching half of total.
6) Use segment tree to efficiently track overlapping x-intervals at each y.
7) Return exact y-coordinate where area reaches half of total.

Time Complexity: O(n² log n) where n = number of squares (events * segment tree operations)
Space Complexity: O(n) for events, coordinate arrays, and segment tree
Tip: The key insight is using a horizontal sweep line combined with a segment tree for efficient union computation. The segment tree tracks overlapping x-intervals at each y-level, allowing us to calculate covered width in O(log n) time. This approach finds the exact horizontal line that divides the union area in half.
Similar Problems: 850. Rectangle Area II, 218. The Skyline Problem, 391. Perfect Rectangle
*/
public class Solution {
    public double SeparateSquares(int[][] squares) {
        var events = new List<(int y, int delta, int xl, int xr)>();    // List to store sweep line events
        var xs = new SortedSet<int>();                                  // Set to collect unique x-coordinates

        foreach (var s in squares) {                                    // Process each square
            int x = s[0], y = s[1], l = s[2];                           // Extract x, y coordinates and side length
            events.Add((y, 1, x, x + l));                               // Add bottom edge event (square starts)
            events.Add((y + l, -1, x, x + l));                          // Add top edge event (square ends)
            xs.Add(x);                                                  // Add left x-coordinate to set
            xs.Add(x + l);                                              // Add right x-coordinate to set
        }

        events.Sort((a, b) => a.y.CompareTo(b.y));                      // Sort events by y-coordinate (bottom to top)

        int[] xArr = xs.ToArray();                                      // Convert x-coordinates to array for indexing
        long totalArea = GetTotalArea(events, xArr);                    // Calculate total union area of all squares
        double half = totalArea / 2.0;                                  // Target is half of total area

        var tree = new SegmentTree(xArr);                               // Initialize segment tree for interval tracking
        long area = 0;                                                  // Track accumulated area from bottom
        int prevY = 0;               // ✅ MUST be 0                    // Start from y=0 to include all area

        foreach (var (y, delta, xl, xr) in events) {                    // Process each event
            long width = tree.CoveredWidth;                             // Get current covered width at this y-level
            long dy = y - prevY;                                        // Calculate height since last y
            long gain = width * dy;                                     // Calculate area gained since last y

            if (width > 0 && area + gain >= half) {                     // If adding this area reaches or exceeds half
                return prevY + (half - area) / width;                   // Return exact y where half is reached
            }

            area += gain;                                               // Accumulate area
            tree.Add(xl, xr, delta);                                    // Update segment tree with current event
            prevY = y;                                                  // Update previous y for next iteration
        }

        throw new Exception("Unreachable");                             // Should never reach here
    }

    private long GetTotalArea(
        List<(int y, int delta, int xl, int xr)> events,
        int[] xs) {

        var tree = new SegmentTree(xs);                                 // Create segment tree for area calculation
        long area = 0;                                                  // Initialize total area accumulator
        int prevY = 0;               // ✅ MUST be 0                    // Start from y=0 to capture all area

        foreach (var (y, delta, xl, xr) in events) {                    // Process each event
            area += tree.CoveredWidth * (y - prevY);                    // Add area for this horizontal strip
            tree.Add(xl, xr, delta);                                    // Update segment tree with event
            prevY = y;                                                  // Move to next y-level
        }
        return area;                                                    // Return total union area
    }
}
public class SegmentTree {
    private readonly int[] xs;                                          // Array of unique x-coordinates
    private readonly int n;                                             // Number of intervals (xs.Length - 1)
    private readonly int[] count;                                       // Count of overlapping intervals at each node
    private readonly long[] width;     // ✅ long                       // Total covered width at each node (use long to prevent overflow)

    public SegmentTree(int[] xs) {
        this.xs = xs;                                                   // Store coordinate array
        n = xs.Length - 1;                                              // Calculate number of intervals
        count = new int[4 * n];                                         // Allocate array for cover counts
        width = new long[4 * n];                                        // Allocate array for covered widths
    }

    public long CoveredWidth => width[0];   // ✅ long                 // Property to get total covered width

    public void Add(int l, int r, int v) {
        Add(0, 0, n - 1, l, r, v);                                      // Start recursive add from root node
    }

    private void Add(int idx, int lo, int hi, int l, int r, int v) {
        if (r <= xs[lo] || xs[hi + 1] <= l) return;                     // If range doesn't overlap with node range, return

        if (l <= xs[lo] && xs[hi + 1] <= r) {                           // If node range fully contained in query range
            count[idx] += v;                                            // Update cover count (+1 for start, -1 for end)
        } else {                                                        // If partial overlap
            int mid = (lo + hi) / 2;                                    // Calculate midpoint
            Add(idx * 2 + 1, lo, mid, l, r, v);                         // Recurse to left child
            Add(idx * 2 + 2, mid + 1, hi, l, r, v);                     // Recurse to right child
        }

        if (count[idx] > 0)                                             // If this node is fully covered
            width[idx] = (long)xs[hi + 1] - xs[lo];  // ✅ cast        // Set width to full interval width (cast to long)
        else if (lo == hi)                                              // If leaf node and not covered
            width[idx] = 0;                                             // No covered width
        else                                                            // If internal node and not covered
            width[idx] = width[idx * 2 + 1] + width[idx * 2 + 2];       // Width is sum of children's covered widths
    }
}
