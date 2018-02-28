#load "config.cake"
#load "task-list.cake"
#load "show-root.cake"
#load "git-submodule.cake"
#load "npm-install.cake"
#load "purge.cake"
#load "nuget-restore.cake"
#load "build.cake"
#load "test-dotnet.cake"
#load "test-javascript.cake"
#load "test.cake"
#load "report-generator.cake"
#load "convert-opencover-cobertura.cake"
#load "../local-tasks/imports.cake"

var target = Argument("target", "Default");

Task("Default")
  .Does(() =>
{
  foreach (var taskName in config.DefaultTasks)
  {
    RunTarget(taskName);
  }
});

RunTarget(target);