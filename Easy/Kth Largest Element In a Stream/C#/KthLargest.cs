using System;

namespace Kth_Largest_Element_In_a_Stream;

public class KthLargest {
	public readonly List<int> Scores;
	private readonly int K;

	public KthLargest(int k, int[] nums) {
		K = k;
		Scores = [];
		foreach (int n in nums) Add(n);
	}

	public int Add(int val) {
		Scores.Add(val);
		HeapifyUp();

		if (Scores.Count > K)
			Dequeue();

		return Scores[0];
	}

	private void Dequeue() {
		(Scores[0], Scores[^1]) = (Scores[^1], Scores[0]);
		Scores.RemoveAt(Scores.Count - 1);
		HeapifyDown();
	}

	private void HeapifyUp() {
		int curr = Scores.Count - 1;
		int parent = (curr - 1) / 2;

		while (curr > 0 && Scores[curr] < Scores[parent]) {
			(Scores[curr], Scores[parent]) = (Scores[parent], Scores[curr]);
			curr = parent;
			parent = (curr - 1) / 2;
		}
	}

	private void HeapifyDown(int curr = 0) {
		int n = Scores.Count;
		int left = (curr * 2) + 1;
		int right = (curr * 2) + 2;

		if (left >= n) return;

		int promoted = left;
		if (right < n)
			promoted = Scores[left] < Scores[right] ? left : right;
		
		if (Scores[promoted] < Scores[curr]) {
			(Scores[curr], Scores[promoted]) = (Scores[promoted], Scores[curr]);
			HeapifyDown(promoted);
		}
	}
}
