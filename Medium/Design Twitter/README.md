# Design Twitter

## Description
Design a simplified version of Twitter where users can post tweets, follow/unfollow another user, and is able to see the **10 most recent tweets** in the user's news feed.

Implement the `Twitter` class:
- `Twitter()` Initializes your twitter object.
- `void postTweet(int userId, int tweetId)` Composes a new tweet with ID tweetId by the user userId. Each call to this function will be made with a unique tweetId.
- `List<Integer> getNewsFeed(int userId)` Retrieves the 10 most recent tweet IDs in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user themself. Tweets must be ordered from most recent to least recent.
- `void follow(int followerId, int followeeId)` The user with ID followerId started following the user with ID `followeeId`.
- `void unfollow(int followerId, int followeeId)` The user with ID followerId started unfollowing the user with ID `followeeId`.

### Example 1
***Input***  
`["Twitter", "postTweet", "getNewsFeed", "follow", "postTweet", "getNewsFeed", "unfollow", "getNewsFeed"]`  
`[[], [1, 5], [1], [1, 2], [2, 6], [1], [1, 2], [1]]`

***Output***  
`[null, null, [5], null, null, [6, 5], null, [5]]`

***Explanation***  
```code
Twitter twitter = new Twitter();
twitter.postTweet(1, 5); // User 1 posts a new tweet (id = 5).
twitter.getNewsFeed(1);  // User 1's news feed should return a list with 1 tweet id -> [5]. return [5]
twitter.follow(1, 2);    // User 1 follows user 2.
twitter.postTweet(2, 6); // User 2 posts a new tweet (id = 6).
twitter.getNewsFeed(1);  // User 1's news feed should return a list with 2 tweet ids -> [6, 5]. Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
twitter.unfollow(1, 2);  // User 1 unfollows user 2.
twitter.getNewsFeed(1);  // User 1's news feed should return a list with 1 tweet id -> [5], since user 1 is no longer following user 2.
```

### Constraints
- `1 <= userId, followerId, followeeId <= 500`
- `0 <= tweetId <= 10^4`
- All the tweets have unique IDs.
- At most `3 * 10^4` calls will be made to `postTweet`, `getNewsFeed`, `follow`, and `unfollow`.
- A user cannot follow himself.

## Strategy
First off, store users in a map that maps userIds (followers) to a set of userIds (followees). Also, store tweets in a map that maps userIds to a list of `Tweet` objects. A `Tweet` object has an id, time (basically a count), userId and **possibily** an Idx (index). The complex part of the problem comes from the `getNewsFeed` function. There are 2 approaches.

### Pointer dictionary
Create a dictionary that stores the current `userId` and its followees mapped to the number 1. That pointer number will be used like this: **length on tweet list - pointer**. That means creating pointers to their most recent post. Increasing the pointer means pointing to the older tweet.

Create a `feed` list of integers. While this feed is less than 10, loop over the dictionary and keep finding the pointer that points to the latest tweet. Once found, add the tweet id to the list and increase the pointer. Break the loop if no tweet was found whatsoever.

### Heap
Create a max heap of `Tweet` object and a `feed` list of integers. A `Tweet` has info about its index. That is a pointer. Populate the heap with the current `userId`'s latest tweet and the latest tweet of the followees. While feed is less than 10, keep popping out the tweet with the highest time attribute. That is possible becaouse it is a max heap. Add the tweet id to `feed`. 

The tweet has info about its `userId` and the index. If the index is more than zero, subtract the index by 1 to get the older post of that `userId`, and add it back to the heap. Break the loop if the heap is empty.

## Time Complexity - O(F)
The complexity comes from `getNewsFeed`. The main parameter are a user's followees, so `F`.

### Pointer dictionary
Building a dictionary of userIds mapped to pointers takes linear time. Then the while loop ends when at most 10 tweets are found by moving pointers, making this `O(F + 10 * F)`, so `O(F)`

### Heap
Building a heap of tweets takes linear time with a bottom-up approach. Then the while loop ends when at most 10 tweets are found by heap operations, making this `O(F + 10 * log F)`, so `O(F)`

## Space Complexity - O(n)
With `n` being the number of tweets and relations, those are all stored in 2 different dictionaries.
