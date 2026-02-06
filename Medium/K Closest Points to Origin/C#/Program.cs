using K_Closest_Points_to_Origin;

var task = new Solution();
static void PrintTest(int[][] test) {
	string ans = string.Empty;
	foreach (var coordinate in test) {
		ans += $"[{string.Join(", ", coordinate)}] ";
	}
	Console.WriteLine(ans);
}

var test1 = task.KClosest(points: [[1,3],[-2,2]], k: 1);
var test2 = task.KClosest(points: [[3,3],[5,-1],[-2,4]], k: 2);

PrintTest(test1);
PrintTest(test2);
