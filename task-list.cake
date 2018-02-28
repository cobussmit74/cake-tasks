#load "config.cake"

Task("task-list")
  .Does(() =>
{
    var defaultTaskName = "Default";
    foreach (var task in Tasks
        .Where(t => t.Name != defaultTaskName)
        .OrderBy(t => t.Name))
    {
        Information(task.Name);
    }

    if (Tasks.Any(t => t.Name == defaultTaskName))
    {
        Information($"({defaultTaskName})");
        Information($"\t{string.Join("\n\t",config.DefaultTasks)}");
    }
});

Task("list").IsDependentOn("task-list");