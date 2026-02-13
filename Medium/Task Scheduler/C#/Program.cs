using Task_Scheduler;

var task = new Solution();
Console.WriteLine(task.LeastInterval(tasks: ['A','A','A','B','B','B'], n: 2));
Console.WriteLine(task.LeastInterval(tasks: ['A','C','A','B','D','B'], n: 1));
Console.WriteLine(task.LeastInterval(tasks: ['A','A','A', 'B','B','B'], n: 3));

task = new AlternativeSolution();
Console.WriteLine(task.LeastInterval(tasks: ['A','A','A','B','B','B'], n: 2));
Console.WriteLine(task.LeastInterval(tasks: ['A','C','A','B','D','B'], n: 1));
Console.WriteLine(task.LeastInterval(tasks: ['A','A','A', 'B','B','B'], n: 3));
