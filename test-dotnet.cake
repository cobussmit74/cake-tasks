#load "config.cake"
#tool "nuget:?package=NUnit.ConsoleRunner"
#tool "nuget:?package=NUnit.Extension.NUnitV2ResultWriter"
#tool "nuget:?package=OpenCover"

NUnit3Settings GetNUnit3Settings(NUnit3Labels labels)
{
  return new NUnit3Settings {
      Results = new[]{  new NUnit3Result
      {
        FileName = config.NunitOutputFile,
        Format = "nunit2"
      }},
      Labels = labels,
      Framework = "net-4.5",
      X86 = true
    };
}

Task("test-dotnet")
  .Does(() =>
{
  NUnit3(config.NunitTestLibrarySearchPattern, GetNUnit3Settings(NUnit3Labels.Off));
});

Task("cover-dotnet")
  .Does(() =>
{
  var settings = new OpenCoverSettings()
  {
      Register = "user",
      MergeByHash = true,
      ReturnTargetCodeOffset = 0
  };
  foreach (var filter in config.OpenCoverFilters)
  {
      settings.WithFilter(filter);
  }

  OpenCover(tool => {
  tool.NUnit3(config.NunitTestLibrarySearchPattern, GetNUnit3Settings(NUnit3Labels.All));
  },
  new FilePath(config.OpenCoverOutputFile),
  settings);
});