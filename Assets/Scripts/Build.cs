using UnityEngine;
using System.Collections;
using UnityEditor;

public class Build
{
    public static void Perform()
    {
        var sceneArray = new EditorBuildSettingsScene[1];
        sceneArray[0] = new EditorBuildSettingsScene("Assets/Fabian.unity", true);
        EditorBuildSettings.scenes = sceneArray;
    }
}