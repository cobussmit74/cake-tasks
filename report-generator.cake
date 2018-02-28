#load "config.cake"
#tool "nuget:?package=ReportGenerator"

Task("report-generator")
  .Does(() =>
{
  var exclusions = "-" + string.Join(";-",config.CoverageReportExclusions);
  
  var nugetPath = Context.Tools.Resolve("ReportGenerator.exe");
  StartProcess(nugetPath, new ProcessSettings {
    Arguments = new ProcessArgumentBuilder()
      .AppendQuoted("-reports:" + config.OpenCoverOutputFile)
      .AppendQuoted("-targetdir:" + config.CoverageOutputFolder)
      .AppendQuoted("-assemblyfilters:" + exclusions)
  });
});