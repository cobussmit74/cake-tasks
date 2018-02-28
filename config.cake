#addin nuget:?package=Cake.Json
#addin nuget:?package=Newtonsoft.Json&version=9.0.1

class ConfigValues
{
  public string[] DefaultTasks { get; set; }
  public string Root { get; set; }
  public string SourceFolder { get; set; }
  public string BuildReportsFolder { get; set; }
  public string[] PurgeFolders { get; set; }
  public string[] SolutionPaths { get; set; }
  public string NunitOutputFile { get; set; }
  public string NunitTestLibrarySearchPattern { get; set; }
  public string OpenCoverOutputFile { get; set; }
  public string CoverageOutputFolder { get; set; }
  public string CoberturaOutputFile { get; set; }
  public string[] OpenCoverFilters { get; set; }
  public string[] CoverageReportExclusions { get; set; }
  public string KarmaPath { get; set; }
  public string KarmaConfigPath { get; set; }
}

public void CopyValues<T>(T target, T source)
{
    Type t = typeof(T);

    var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

    foreach (var prop in properties)
    {
        var value = prop.GetValue(source, null);
        if (value != null)
             prop.SetValue(target, value, null);
    }
}

var defaultConfilePath = "./default-config.json";
var localConfilePath = "../cake-config.json";
var config = DeserializeJsonFromFile<ConfigValues>(defaultConfilePath);
if (FileExists(localConfilePath))
{
  var localConfig = DeserializeJsonFromFile<ConfigValues>(localConfilePath);
  CopyValues(config, localConfig);
}