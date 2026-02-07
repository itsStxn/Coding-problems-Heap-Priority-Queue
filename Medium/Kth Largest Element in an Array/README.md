# Kth Largest Element in an Array

## Description
Given an integer array `nums` and an integer `k`, return the `kth` largest element in the array.

Note that it is the `kth` largest element in the sorted order, not the `kth` distinct element.

Can you solve it without sorting?

### Example 1
***Input***: `nums` = [3,2,1,5,6,4], `k` = 2  
***Output***: 5  

### Example 2
***Input***: `nums` = [3,2,3,1,2,4,5,5,6], `k` = 4  
***Output***: 4  

### Constraints
- 1 <= `k` <= `nums.length` <= 10^5
- -10^4 <= `nums[i]` <= 10^4

## Strategy

### Heap
Implement a min heap. Since the heap does not increase or decrease, no need to turn `nums` into a list.

Once the min heap is implemented, push the top to the back `k - 1` times to get the desired kth largest element.

### Quick Select
The problem can also be solved by implementing quick select algorithm. Since kth largest is requested, quick select should be the variation for kth largest.

## Time Complexity
### Heap - O(k * log n)
The top is pushed to back to a branch `k` times.

### Quick Select - O(n)
`Partition` goes over `n` numbers. The method is called on each recursive lever, but either within a left or right partition. This keeps complexity still O(n). 

## Space Complexity

### Heap - O(1)
No additional data stcucture of `n` size is used.

### Quick Select - O(log n)
The call stack increases if deciding to recurse over the left or right partition.
