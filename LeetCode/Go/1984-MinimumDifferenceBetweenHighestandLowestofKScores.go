func minimumDifference(nums []int, k int) int {
    sort.Ints(nums)                          // Sort the array
	i := 0                                   // Initialize the window
	j := i + k - 1                           // Initialize the window
	res := math.MaxInt32                     // Initialize the result

	for j < len(nums) {                      // Iterate through the array
		res = int(math.Min(float64(res), float64(nums[j]-nums[i]))) // Find the difference and update the result
		i++                                   // Move the window by 1
		j++                                   // Move the window by 1
	}

	return res
}