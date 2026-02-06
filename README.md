# Heap / Priority Queue

## Difficulties

### Easy

- Kth Largest Element In a Stream   	
- Last Stone Weight

### Medium

- K Closest Points to Origin   	
- Kth Largest Element In An Array   	
- Task Scheduler   	
- Design Twitter 

### Hard

- Find Median From Data Stream

## Patterns

- Need to **repeatedly get min or max**
- Asked for **top K elements**
- Asked for **Kth smallest or largest**
- Data arrives as a **stream**
- Need to maintain **best K so far**
- Requires **dynamic ordering**
- Use of **min-heap or max-heap**
- Heap size often limited to **K**
- Involves **push and pop operations**
- Time complexity involves **log n**
- Asked to **merge sorted lists or arrays**
- Asked to **schedule tasks or intervals**
- Asked to find **closest / farthest elements**
- Asked to minimize or maximize **cost or time**
- Asked to find **running median**
- Requires storing **pairs or tuples**
- Comparison based on **custom key**
- Often combined with **hash map**
- Used in **greedy algorithms**
- Used for **interval problems**
- Heap replaces **sorting for efficiency**
- Involves **lazy deletion**
- Requires careful handling of **heap sign (negative for max-heap)**
- Can simulate **max-heap using min-heap**
- Rebalancing logic for **two heaps**
- Edge cases with **empty heap**
- Used when order matters **only at extremes**
- Helps avoid **O(n log n) full sort**
- Final answer depends on **heap top**
- Space complexity tied to **heap size**

## Tips

- A heap **guarantees** that at the top there are either **max or min values**

### Binary Heap

- Tree where the **parent's value >= children's value**
- Represented as a list of **most-left** elements -> **there is no right without the left**
- Parent = **(i - 1) / 2**, left child = **(2 * i) + 1**, right child = **(2 * i) + 2**
- In a heap list, the leafs correspond to **all the values after the middle index**, so **leafs' indeces > (list.Count / 2) - 1**

- **Building a heap takes O(n) time:** 
	- Iterate backwards from the **last non-leaf index to the root** and call **HeapifyDown on each index**
	- Leaf nodes need **no work**, nodes one level up might move **at most 1 level**
	- Nodes on the higher up can move, but **there are very few of them**
	- Going backwards because calling HeapifyDown on the parents **work only if the children are already heaps**
