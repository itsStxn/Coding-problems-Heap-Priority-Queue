using System;

namespace Kth_Largest_Element_in_an_Array;

public class Solution {
	public int FindKthLargest(int[] nums, int k) {
		int n = nums.Length;
		for (int i = (nums.Length / 2) - 1; i >= 0; i--)
			HeapifyDown(nums, n, curr: i);

		for (int i = 0; i < k - 1; i++)
			Remove(nums, n - i);

		return nums[0];
	}

	private static void Remove(int[] heap, int len) {
		int lastIdx = len - 1;
		Swap(heap, 0, lastIdx);
		HeapifyDown(heap, lastIdx, curr: 0);
	}

	private static void Swap(int[] arr, int i, int j) {
		(arr[i], arr[j]) = (arr[j], arr[i]);
	}

	private static void HeapifyDown(int[] heap, int n, int curr) {
		while (true) {
			int left = (curr * 2) + 1;
			int right = (curr * 2) + 2;
			int largest = curr;

			if (left < n && heap[left] > heap[largest])
				largest = left;

			if (right < n && heap[right] > heap[largest])
				largest = right;
			
			if (largest == curr)
				break;

			Swap(heap, largest, curr);
			curr = largest;
		}
	}
}
