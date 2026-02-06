using System;

namespace K_Closest_Points_to_Origin;

public class Solution {
	public int[][] KClosest(int[][] points, int k) {
		List<int[]> plane = [];
		foreach (var point in points)
			Add(point, k, plane);

		return [..plane];
	}

	private static void Add(int[] point, int k, List<int[]> plane) {
		plane.Add(point);
		HeapifyUp(plane);

		if (plane.Count > k)
			Remove(plane);
	}

	private static void Remove(List<int[]> plane) {
		(plane[0], plane[^1]) = (plane[^1], plane[0]);
		plane.RemoveAt(plane.Count - 1);
		HeapifyDown(plane);
	}

	private static double Dist(int[] xy) {
		int x = xy[0];
		int y = xy[1];
		return Math.Sqrt((x * x) + (y * y));
	}

	private static void HeapifyUp(List<int[]> plane) {
		int curr = plane.Count - 1;
		int parent = (curr - 1) / 2;

		while (curr > 0 && Dist(plane[curr]) > Dist(plane[parent])) {
			(plane[curr], plane[parent]) = (plane[parent], plane[curr]);
			curr = parent;
			parent = (curr - 1) / 2;
		}
	}

	private static void HeapifyDown(List<int[]> plane, int curr = 0) {
		int n = plane.Count;
		int left = (curr * 2) + 1;
		int right = (curr * 2) + 2;

		if (left >= n) return;

		int promoted = left;
		if (right < n)
			promoted = Dist(plane[left]) > Dist(plane[right]) ? left : right;

		if (Dist(plane[promoted]) > Dist(plane[curr])) {
			(plane[promoted], plane[curr]) = (plane[curr], plane[promoted]);
			HeapifyDown(plane, promoted);
		}
	}
}
