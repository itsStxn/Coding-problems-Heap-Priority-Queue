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
Get the highest task frequency and count how many tasks appear that many times. 

We can assume that The task with the highest frequency means that elements will appear in between its gaps. For example:

**Case A B C A B C with n = 2**  
A appears the most (also B and C, but let's consider A). It means **A _ _ A** should provide enough interval for other tasks. An interval is **A _ _**. It appears once, so basically an interval is (max occurance - 1). The interval length is `n + 1`. After the interval, you simply add the number of elements with that same occurance as A. Basically **A _ _ + A B C**. This whole thing means **A B C A B C**, which is 6. 

The overall formula is (max occurance - 1) * (`n + 1`) + max occurance count. This formula **assumes** that each gap of the most frequent number is successfully giving room for all the rest, but this is not always the case.

**Case A B C A B C with n = 1**
Now `n` is 1. It means that an interval is **A _**, and then the most frequent numbers are added. So this setting says **A _ + A B C**, which sums up to 5. This is wrong, because the interval only leaves room for an additional task: either **A B A B C** or **A C A B C**. In both cases, a task is missing.

**Case A B C A B C D E F with n = 2**
This case seems to completely ignore **D E F**. The formula works with the most frequent numbers, and suggest **A _ _ A B C**. The interval leaves room for B and C, but the result completely ignores the existence of **D E F**. If `n` was equal to 3, there would be space just for 1 extra task in **A _ _ _ A B C**. To get the space needed, `n` should be 5, resulting in **A _ _ _ _ _ A B C**. 

**Note** that all the result that where correct from using the formula, resulted in a result with a length greater or equal to the length of `tasks`. So, the result should be the **max(length of tasks, gap formula)**.

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
