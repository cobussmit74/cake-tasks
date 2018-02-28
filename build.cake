#load "config.cake"

Task("build")
  .Does(() =>
{
  foreach (var solution in config.SolutionPaths.SelectMany(GetFiles))
  {
    Information($"Calling MSBuild on - {solution}");
    MSBuild(solution, new MSBuildSettings {
      Verbosity = Verbosity.Minimal,
      ToolVersion = MSBuildToolVersion.VS2017,
      Configuration = "Debug",
      PlatformTarget = PlatformTarget.MSIL
      });
  }
});