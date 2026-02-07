using System;

namespace Kth_Largest_Element_in_an_Array;

public class AlternativeSolution {
	public int FindKthLargest(int[] nums, int k) {
		int n = nums.Length;
		
		int quickSelect(int left, int right) {
				if (left == right)
					return nums[left];

				int pivotIdx = Partition(nums, left, right);

				if (n - k < pivotIdx)
					return quickSelect(left, pivotIdx - 1);
				if (n - k > pivotIdx)
					return quickSelect(pivotIdx + 1, right);
				
				return nums[pivotIdx];
		}

		return quickSelect(0, n - 1);
	}

	private int Partition(int[] nums, int left, int right) {
		int pivot = nums[right];
		int pivotIdx = left;

		for (int i = left; i < right; i++) {
				if (nums[i] > pivot) continue;

				Swap(nums, i, pivotIdx);
				pivotIdx++; 
		}

		Swap(nums, right, pivotIdx);
		return pivotIdx;
	}

	private static void Swap(int[] arr, int i, int j) {
		(arr[i], arr[j]) = (arr[j], arr[i]);
	}
}
