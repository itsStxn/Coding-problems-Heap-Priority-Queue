using System;

namespace Design_Twitter;

public class AlternativeTwitter : Twitter {
	private class Tweet(int id, int userId, int idx, int time) {
		public int Id = id;
		public int Idx = idx;
		public int Time = time;
		public int UserId = userId;
	}

	private readonly Dictionary<int, HashSet<int>> Follows;
	private readonly Dictionary<int, List<Tweet>> Tweets;
	private int Time;

	public AlternativeTwitter() {
		Time = 0;
		Tweets = [];
		Follows = [];
	}
	
	override public void PostTweet(int userId, int tweetId) {
		Tweets.TryAdd(userId, []);

		int idx = Tweets[userId].Count;
		var tweet = new Tweet(tweetId, userId, idx, ++Time);
		Tweets[userId].Add(tweet);
	}
	
	override public IList<int> GetNewsFeed(int userId) {
		var heap = BuildFeedHeap(userId);
		var feed = new List<int>();

		while (feed.Count < 10 && heap.Count > 0) {
			var latest = Remove(heap);
			feed.Add(latest.Id);
			
			if (latest.Idx > 0) {
				int by = latest.UserId;
				int at = latest.Idx - 1;
				Add(heap, Tweets[by][at]);
			}
		}

		return feed;
	}

	override public void Follow(int followerId, int followeeId) {
		var followees = GetFollows(followerId);
		followees.Add(followeeId);
	}
	
	override public void Unfollow(int followerId, int followeeId) {
		if (Follows.TryGetValue(followerId, out var followees))
			followees.Remove(followeeId);
	}

	private List<Tweet> BuildFeedHeap(int userId) {
		var heap = new List<Tweet>();
		
		var tweets = GetTweets(userId);
		if (tweets.Count > 0)
			heap.Add(tweets[^1]);
		
		foreach (int id in GetFollows(userId)) {
			tweets = GetTweets(id);
			if (tweets.Count > 0)
				heap.Add(tweets[^1]);
		}

		int n = heap.Count;
		for (int i = (n / 2) - 1; i >= 0; i--)
			HeapifyDown(heap, i);

		return heap;
	}

	private List<Tweet> GetTweets(int userId) {
		Tweets.TryAdd(userId, []);
		return Tweets[userId];
	}

	private HashSet<int> GetFollows(int userId) {
		Follows.TryAdd(userId, []);
		return Follows[userId];
	}

	static void Add(List<Tweet> heap, Tweet tweet) {
		heap.Add(tweet);
		HeapifyUp(heap);
	}

	static private Tweet Remove(List<Tweet> heap) {
		int n = heap.Count - 1;
		var top = heap[0];

		Swap(heap, 0, n);
		heap.RemoveAt(n);
		if (heap.Count > 0)
			HeapifyDown(heap);

		return top;
	}

	static private void HeapifyUp(List<Tweet> heap) {
		int curr = heap.Count - 1;
		int parent = (curr - 1) / 2;

		while (curr > 0 && heap[curr].Time > heap[parent].Time) {
			Swap(heap, curr, parent);
			curr = parent;
			parent = (curr - 1) / 2;
		}
	}

	static private void HeapifyDown(List<Tweet> heap, int curr = 0) {
		int n = heap.Count;

		while (true) {
			int largest = curr;
			int l = (2 * curr) + 1; 
			int r = (2 * curr) + 2;

			if (l < n && heap[l].Time > heap[largest].Time)
				largest = l;
			
			if (r < n && heap[r].Time > heap[largest].Time)
				largest = r;

			if (largest == curr)
				return;

			Swap(heap, curr, largest);
			curr = largest;
		}
	}

	static private void Swap(List<Tweet> li, int i, int j) {
		(li[i], li[j]) = (li[j], li[i]);
	}
}
