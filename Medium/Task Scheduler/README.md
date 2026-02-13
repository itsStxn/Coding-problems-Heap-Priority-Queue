# Task Scheduler

## Description
You are given an array of CPU tasks, each labeled with a letter from A to Z, and a number `n`. Each CPU interval can be idle or allow the completion of one task. Tasks can be completed in any order, but there's a constraint: there has to be a gap of at least `n` intervals between two tasks with the same label.

Return *the minimum number of CPU intervals required to complete all tasks*.

### Example 1
***Input***: `tasks = ["A","A","A","B","B","B"]`, `n = 2`  
***Output***: 8  
***Explanation***: A possible sequence is: A -> B -> idle -> A -> B -> idle -> A -> B.

After completing task A, you must wait two intervals before doing A again. The same applies to task B. In the 3rd interval, neither A nor B can be done, so you idle. By the 4th interval, you can do A again as 2 intervals have passed.

### Example 2
***Input***: `tasks = ["A","C","A","B","D","B"]`, `n = 1`  
***Output***: 6  
***Explanation***: A possible sequence is: A -> B -> C -> D -> A -> B.

With a cooling interval of 1, you can repeat a task after just one other task.

### Example 3
***Input***: `tasks = ["A","A","A", "B","B","B"]`, `n = 3`  
***Output***: 10  
***Explanation***: A possible sequence is: A -> B -> idle -> idle -> A -> B -> idle -> idle -> A -> B.

There are only two types of tasks, A and B, which need to be separated by 3 intervals. This leads to idling twice between repetitions of these tasks.

### Constraints
- `1 <= tasks.length <= 10^4`
- `tasks[i]` is an uppercase English letter.
- `0 <= n <= 100`

## Strategy

### Max heap
Get the frequencies of each task, and put those number in a max heap. Create a queue to store each task's frequency and the next time that it can be run. Run an iteration where a time variable increases each time. Keep getting the max element from the max heap, decrease the frequency, and add n to the time that the frequency can be put back into the heap. Make sure to ignore a frequency when it is 0.

### Math
Get the highest task frequency and count how many tasks appear that many times. The task with the highest frequency means that elements will appear in between its gaps. The gap is `n + 1` long (the task occupies one place itself). Basically, all you need to do is multiply `n + 1` for the highest frequency, and then add the amount of tasks that have that frequency.  

## Time Complexity

### Max heap - O(n * log n)
The complexity comes from calling operations that work on a branch of the heap in an `n` loop.

### Math - O(n)
Each task is processed once.

## Space Complexity

### Max heap - O(n)
A queue and a dictionary of `n` size are used.

### Math - O(1)
An array is used, but it has a fixed size of 26.
