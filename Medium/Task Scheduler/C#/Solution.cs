using System;

namespace Task_Scheduler;

public class Solution {
	virtual public int LeastInterval(char[] tasks, int n) {
		var cooldown = new Queue<(int task, int time)>();
		int[] heap = Heapify(tasks);
		int size = heap.Length; 
		int time = 0;
		
		while (size > 0 || cooldown.Count > 0) {
			time++;
			if (cooldown.TryPeek(out var pending) && pending.time == time) {
				Add(heap, ++size, pending.task);
				cooldown.Dequeue();
			}

			if (size == 0)
				continue;
			
			int task = Remove(heap, --size) - 1;
			if (task > 0)
				cooldown.Enqueue((task, time + n + 1));
		}
		
		return time;
	}

	static int[] Heapify(char[] arr) {
		var freq = new Dictionary<char, int>();
		foreach (char task in arr)
			if (!freq.TryAdd(task, 1))
				freq[task]++;

		int[] heap = [..freq.Values];
		int n = heap.Length;

		for (int i = (n / 2) - 1; i >= 0; i--)
			HeapifyDown(heap, n, i);

		return heap;
	}

	static private void Add(int[] heap, int n, int el) {
		heap[n - 1] = el;
		HeapifyUp(heap, n);
	}

	static private int Remove(int[] heap, int n) {
		int top = heap[0];
		Swap(heap, 0, n);
		HeapifyDown(heap, n);

		return top;
	}

	static private void HeapifyUp(int[] heap, int n) {
		int curr = n - 1;
		int parent = (curr - 1) / 2;

		while (curr > 0 && heap[curr] > heap[parent]) {
			Swap(heap, curr, parent);
			curr = parent;
			parent = (curr - 1) / 2;
		}
	}

	static private void HeapifyDown(int[] heap, int n, int curr = 0) {
		while (true) {
			int largest = curr;
			int l = (2 * curr) + 1;
			int r = (2 * curr) + 2;

			if (l < n && heap[l] > heap[largest])
				largest = l;

			if (r < n && heap[r] > heap[largest])
				largest = r;

			if (largest == curr)
				break;

			Swap(heap, curr, largest);
			curr = largest;
		}
	}

	static private void Swap(int[] arr, int i, int j) {
		(arr[i], arr[j]) = (arr[j], arr[i]);
	}
}
