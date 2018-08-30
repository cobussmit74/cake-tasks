Task("dotnet-build")
  .Does(() =>
{
  foreach (var solution in config.SolutionPaths.SelectMany(GetFiles))
  {
    Information($"Doing DotNet build for - {solution}");
    DotNetCoreBuild(solution.FullPath);
  }
});