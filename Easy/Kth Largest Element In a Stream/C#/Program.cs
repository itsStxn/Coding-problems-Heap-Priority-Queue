using Kth_Largest_Element_In_a_Stream;

var kthLargest = new KthLargest(3, [4, 5, 8, 2]);
Console.WriteLine(kthLargest.Add(3));	// return 4
Console.WriteLine(kthLargest.Add(5));	// return 5
Console.WriteLine(kthLargest.Add(10));	// return 5
Console.WriteLine(kthLargest.Add(10));	// return 5
Console.WriteLine(kthLargest.Add(9));	// return 8
Console.WriteLine(kthLargest.Add(4));	// return 8

kthLargest = new KthLargest(4, [7, 7, 7, 7, 8, 3]);
Console.WriteLine(kthLargest.Add(2));	// return 7
Console.WriteLine(kthLargest.Add(10));	// return 7
Console.WriteLine(kthLargest.Add(9));	// return 7
Console.WriteLine(kthLargest.Add(9));	// return 8
