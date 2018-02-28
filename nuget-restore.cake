#load "config.cake"

Task("nuget-restore")
  .Does(() =>
{
  foreach (var solution in config.SolutionPaths.SelectMany(GetFiles))
  {
    Information($"Doing NuGet restore for - {solution}");
    NuGetRestore(solution);
  }
});