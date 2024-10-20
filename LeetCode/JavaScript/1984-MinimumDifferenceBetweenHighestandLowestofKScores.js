/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var minimumDifference = function(nums, k) {
    nums.sort((a, b) => a - b);                                // Sort the array
     let i = 0;                                                // Initialize the window
     let j = i + k - 1;                                        // Initialize the window
     let res = Number.MAX_VALUE;                               // Initialize the result

     while (j < nums.length) {                                 // Iterate through the array
         res = Math.min(res, nums[j] - nums[i]);               // Find the difference between the last and first element of the window and update the result
         i++;                                                  // Move the window by 1
         j++;                                                  // Move the window by 1
     }

     return res;
};