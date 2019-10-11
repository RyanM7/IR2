using System.IO;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.PostProcessing;

public class SpacePostProcessingFactory
{
    [MenuItem("Assets/Create/Space Post-Processing Profile", priority = 201)]
    static void MenuCreatePostProcessingProfile()
    {
        var icon = EditorGUIUtility.FindTexture("ScriptableObject Icon");
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<DoCreateSpacePostProcessingProfile>(), "New Post-Processing Profile.asset", icon, null);
    }

    internal static SpacePostProcessingProfile CreatePostProcessingProfileAtPath(string path)
    {
        var profile = ScriptableObject.CreateInstance<SpacePostProcessingProfile>();
        profile.name = Path.GetFileName(path);
        AssetDatabase.CreateAsset(profile, path);
        return profile;
    }
}

class DoCreateSpacePostProcessingProfile : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        SpacePostProcessingProfile profile = SpacePostProcessingFactory.CreatePostProcessingProfileAtPath(pathName);
        ProjectWindowUtil.ShowCreatedAsset(profile);
    }
}