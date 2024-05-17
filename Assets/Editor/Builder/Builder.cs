using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public static class Builder
{
    private static void ProcessBuild(BuildTarget targetPlatform)
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = EditorBuildSettingsScene.GetActiveSceneList(EditorBuildSettings.scenes);
        string folder = targetPlatform switch
        {
            BuildTarget.StandaloneWindows => "Windows",
            BuildTarget.Android => "Android",
            BuildTarget.iOS => "iOS",
            BuildTarget.StandaloneWindows64 => "Windows64",
            BuildTarget.WebGL => "WebGL",
            BuildTarget.StandaloneOSX => "OSX",
            _ => "Default"
        };
        string fileName = string.IsNullOrEmpty(PlayerSettings.productName) ? "MyApp" : PlayerSettings.productName;
        buildPlayerOptions.locationPathName = Path.Combine("Builds", folder, fileName);
        buildPlayerOptions.target = targetPlatform;
        buildPlayerOptions.options = BuildOptions.CompressWithLz4HC;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
    public static void BuildAndroid()
    {
        Debug.Log("Building started...");
        ProcessBuild(BuildTarget.Android);
        Debug.Log("Building finished.");
    }

    public static void BuildiOS()
    {
        Debug.Log("Building started...");
        ProcessBuild(BuildTarget.iOS);
        Debug.Log("Building finished.");
    }

    public static void BuildWebGL()
    {
        Debug.Log("Building started...");
        ProcessBuild(BuildTarget.WebGL);
        Debug.Log("Building finished.");
    }
}
