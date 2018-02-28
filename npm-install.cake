#load "config.cake"
#addin "Cake.Npm"

Task("npm-install")
  .Does(() =>
{
  var settings = new NpmInstallSettings();
  settings.FromPath(config.Root);
  NpmInstall(settings);
});