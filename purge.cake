#load "config.cake"

Task("purge")
  .Does(() =>
{
  foreach (var folder in config.PurgeFolders)
  {
    DeleteDirectories(GetDirectories(folder), new DeleteDirectorySettings{
        Force = true,
        Recursive = true
      }
    );
  }
  CreateDirectory(config.BuildReportsFolder);
});