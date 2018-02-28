#load "config.cake"

Task("show-root")
  .Description("Lists all files in the root folder. Usefull for figuring out the startup directory.")
  .Does(() =>
{
  Information(config.Root);
  foreach (var file in GetFiles($"{config.Root}*"))
  {
    Information(file);
  }
});