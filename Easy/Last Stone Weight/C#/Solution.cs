using System;

namespace Last_Stone_Weight;

public class Solution {
	public int LastStoneWeight(int[] stones) {
		var rack = new List<int>(stones);
		for (int i = (rack.Count / 2) - 1; i >= 0; i--)
			HeapifyDown(rack, i);
			
		while (rack.Count > 1) {
			int stone1 = PickStone(rack);
			int stone2 = PickStone(rack);
			int drop = Math.Abs(stone1 - stone2);

			if (drop > 0)
				AddStone(drop, rack);
		}

		return rack.Count > 0 ? rack[0] : 0;
	}

	public static void AddStone(int weight, List<int> stones) {
		stones.Add(weight);
		HeapifyUp(stones);
	}

	private static int PickStone(List<int> stones) {
		int stone = stones[0];

		(stones[0], stones[^1]) = (stones[^1], stones[0]);
		stones.RemoveAt(stones.Count - 1);
		HeapifyDown(stones);
		
		return stone;
	}

	private static void HeapifyUp(List<int> stones) {
		int curr = stones.Count - 1;;
		int parent = (curr - 1) / 2;

		while (curr > 0 && stones[curr] > stones[parent]) {
			(stones[curr], stones[parent]) = (stones[parent], stones[curr]);
			curr = parent;
			parent = (curr - 1) / 2;
		}
	}

	private static void HeapifyDown(List<int> stones, int curr = 0) {
		int left = (curr * 2) + 1;
		int right  = (curr * 2) + 2;
		int n = stones.Count;

		if (left >= n) return;

		int promoted = left;
		if (right < n)
			promoted = stones[left] > stones[right] ? left : right;

		if (stones[promoted] > stones[curr]) {
			(stones[promoted], stones[curr]) = (stones[curr], stones[promoted]);
			HeapifyDown(stones, promoted);
		}
	}
}
