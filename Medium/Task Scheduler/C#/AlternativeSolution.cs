using System;

namespace Task_Scheduler;

public class AlternativeSolution : Solution {
	override public int LeastInterval(char[] tasks, int n) {
		var freq = new int[26];
		int maxCount = 0;
		int max = 0;

		foreach (char task in tasks) {
			int count = ++freq[task - 'A'];
			if (count > max) {
				max = count;
				maxCount = 1;
			}
			else if (count == max)
				maxCount++;
		}

		return Math.Max(
			tasks.Length,
			(max - 1) * (n + 1) + maxCount
		);
	}
}
