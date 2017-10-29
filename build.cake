#tool "GitVersion.CommandLine"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
//////////////////////////////////////////////////////////////////////
var version = "0.1.0";
var versionNumber = "1.0.0";

var artifacts = Directory("./artifacts");
var solution = File("./src/Orbit.sln");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////
Task("Clean")
    .Does(() => 
{
    CleanDirectories("./src/**/bin");
    CleanDirectories("./src/**/obj");

    if (DirectoryExists(artifacts))
    {
        DeleteDirectory(artifacts, new DeleteDirectorySettings 
        {
            Recursive = true,
            Force = true
        });
    }
});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() => 
{
    DotNetCoreRestore(solution);
});

Task("Versioning")
    .IsDependentOn("Clean")
    .Does(() => 
{
    if (!BuildSystem.IsLocalBuild)
    {
        GitVersion(new GitVersionSettings
        {
            OutputType = GitVersionOutput.BuildServer
        });
    }

    var result = GitVersion(new GitVersionSettings
    {
        OutputType = GitVersionOutput.Json
    });

    version = result.NuGetVersion;
    versionNumber = result.MajorMinorPatch;
});

Task("Build")
    .IsDependentOn("Versioning")
    .IsDependentOn("Restore")
    .Does(() => 
{
    CreateDirectory(artifacts);

    DotNetBuild(solution, x => 
    {
        x.SetConfiguration(configuration);
    });
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() => 
{
    var projects = GetFiles("./src/**/*.Tests.csproj");

    foreach (var project in projects)
    {
        DotNetCoreTest(project.FullPath);
    }
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////
Task("Default")
    .IsDependentOn("Test");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////
RunTarget(target);
