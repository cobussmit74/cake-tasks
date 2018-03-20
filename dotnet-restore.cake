Task("dotnet-restore")
  .Does(() =>
{
  foreach (var solution in config.SolutionPaths.SelectMany(GetFiles))
  {
    Information($"Doing DotNet restore for - {solution}");
    DotNetCoreRestore(solution.FullPath);
  }
});