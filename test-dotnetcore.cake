#load "config.cake"

Task("test-dotnetcore")
  .Does(() =>
{
  foreach(var file in GetFiles(config.NunitTestLibrarySearchPattern))
  {
      DotNetCoreTest(file.FullPath, new DotNetCoreTestSettings
      {
        OutputDirectory = config.NunitOutputFile,
        NoRestore = true,
        NoBuild = true
      });
  }
});