#load "config.cake"
#addin "Cake.Npm"

NpmRunScriptSettings CreateKarmaRunSettings(bool singleRun)
{
  var settings = new NpmRunScriptSettings 
      {
          ScriptName = "karma"
      };
  settings.FromPath(config.Root);
  settings.WithArguments("start");
  settings.WithArguments(config.KarmaConfigPath);

  if (singleRun){
    settings.WithArguments("--single-run");
  }

  return settings;
}

Task("test-javascript")
  .Does(() =>
{
  NpmRunScript(CreateKarmaRunSettings(true));
});

Task("watch-javascript")
  .Does(() =>
{
  NpmRunScript(CreateKarmaRunSettings(false));
});