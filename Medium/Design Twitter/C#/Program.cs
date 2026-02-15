using Design_Twitter;

var print = (IList<int> li) => Console.WriteLine(string.Join(", ", li));

var twitter = new Twitter();
twitter.PostTweet(1, 5); 			//* User 1 posts a new tweet (id = 5).
print(twitter.GetNewsFeed(1));  	//* User 1's news feed should return a list with 1 tweet id -> [5]. return [5]
twitter.Follow(1, 2);    			//* User 1 follows user 2.
twitter.PostTweet(2, 6); 			//* User 2 posts a new tweet (id = 6).
print(twitter.GetNewsFeed(1));  	//* User 1's news feed should return a list with 2 tweet ids -> [6, 5]. Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
twitter.Unfollow(1, 2);  			//* User 1 unfollows user 2.
print(twitter.GetNewsFeed(1));  	//* User 1's news feed should return a list with 1 tweet id -> [5], since user 1 is no longer following user 2.

twitter = new AlternativeTwitter();
twitter.PostTweet(1, 5); 			//* User 1 posts a new tweet (id = 5).
print(twitter.GetNewsFeed(1));  	//* User 1's news feed should return a list with 1 tweet id -> [5]. return [5]
twitter.Follow(1, 2);    			//* User 1 follows user 2.
twitter.PostTweet(2, 6); 			//* User 2 posts a new tweet (id = 6).
print(twitter.GetNewsFeed(1));  	//* User 1's news feed should return a list with 2 tweet ids -> [6, 5]. Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
twitter.Unfollow(1, 2);  			//* User 1 unfollows user 2.
print(twitter.GetNewsFeed(1));  	//* User 1's news feed should return a list with 1 tweet id -> [5], since user 1 is no longer following user 2.
