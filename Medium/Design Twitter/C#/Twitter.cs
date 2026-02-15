using System;

namespace Design_Twitter;

public class Twitter {
	private class Tweet(int id, int userId, int time) {
		public int Id = id;
		public int Time = time;
		public int UserId = userId;
	}

	private readonly Dictionary<int, HashSet<int>> Follows;
	private readonly Dictionary<int, List<Tweet>> Tweets;
	private int Time;

	public Twitter() {
		Time = 0;
		Tweets = [];
		Follows = [];
	}
	
	virtual public void PostTweet(int userId, int tweetId) {
		var tweet = new Tweet(tweetId, userId, ++Time);
		Tweets.TryAdd(userId, []);
		Tweets[userId].Add(tweet);
	}
	
	virtual public IList<int> GetNewsFeed(int userId) {
		var pool = GetFeedPool(userId);
		var feed = new List<int>();
		Tweet? latest = null;
		
		while (feed.Count < 10) {
			foreach (var (id, ptr) in pool) {
				var tweet = GetTweet(id, ptr);
				if (tweet == null)
					continue;

				if (latest == null || latest.Time < tweet.Time)
					latest = tweet;
			}

			if (latest == null)
				break;

			pool[latest.UserId]++;
			feed.Add(latest.Id);
			latest = null;
		}

		return feed;
	}

	virtual public void Follow(int followerId, int followeeId) {
		GetFollows(followerId).Add(followeeId);
	}
	
	virtual public void Unfollow(int followerId, int followeeId) {
		if (Follows.TryGetValue(followerId, out var followees))
			followees.Remove(followeeId);
	}

	private Dictionary<int, int> GetFeedPool(int userId) {
		var pool = new Dictionary<int, int>();
		
		foreach (var followeeId in GetFollows(userId))
			pool.Add(followeeId, 1);
		pool.Add(userId, 1);
		
		return pool;
	}

	private Tweet? GetTweet(int userId, int nth) {
		Tweets.TryAdd(userId, []);

		var tweets = Tweets[userId];
		int idx = tweets.Count - nth;
		return idx < 0 ? null : tweets[idx];
	}

	private HashSet<int> GetFollows(int userId) {
		Follows.TryAdd(userId, []);
		return Follows[userId];
	}
}
