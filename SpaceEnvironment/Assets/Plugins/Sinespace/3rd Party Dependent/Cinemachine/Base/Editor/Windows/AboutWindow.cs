using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace Cinemachine.Editor
{
    [InitializeOnLoad]
    public class AboutWindow : EditorWindow
    {
        //private const string kShowOnStartupKey = "CNMCN_Show_About_On_Start";
        private const string kLastVersionOpened = "CNMCN_Last_Version_Loaded";
        private const string kInvalidVersionNumber = "0.0";

        private static readonly Vector2 kMinWindowSize = new Vector2(550f, 550f);

        //private static bool ShowOnStart
        //{
        //    get { return EditorPrefs.GetBool(kShowOnStartupKey, true); }
        //    set { EditorPrefs.SetBool(kShowOnStartupKey, value); }
        //}

        private static string LastVersionLoaded
        {
            get { return EditorPrefs.GetString(kLastVersionOpened, kInvalidVersionNumber); }
            set { EditorPrefs.SetString(kLastVersionOpened, value); }
        }

        private GUIStyle mButtonStyle;
        private GUIStyle mLabelStyle;
        private GUIStyle mHeaderStyle;
        private Vector2 mReleaseNoteScrollPos = Vector2.zero;

        private void OnGUI()
        {
            if (EditorApplication.isCompiling)
            {
                Close();
            }

            if (mButtonStyle == null)
            {
                mButtonStyle = new GUIStyle(GUI.skin.button);
                mButtonStyle.richText = true;
            }

            if (mLabelStyle == null)
            {
                mLabelStyle = new GUIStyle(EditorStyles.label);
                mLabelStyle.wordWrap = true;
                mLabelStyle.richText = true;
            }

            if (mHeaderStyle == null)
            {
                mHeaderStyle = new GUIStyle(EditorStyles.boldLabel);
                mHeaderStyle.wordWrap = true;
            }

            using (var vertScope = new EditorGUILayout.VerticalScope())
            {
                if (CinemachineSettings.CinemachineHeader != null)
                {
                    float headerWidth = position.width;
                    float aspectRatio = (float)CinemachineSettings.CinemachineHeader.height / (float)CinemachineSettings.CinemachineHeader.width;
                    GUILayout.BeginScrollView(Vector2.zero, false, false, GUILayout.Width(headerWidth), GUILayout.Height(headerWidth * aspectRatio));
                    Rect texRect = new Rect(0f, 0f, headerWidth, headerWidth * aspectRatio);

                    GUILayout.FlexibleSpace();
                    GUILayout.BeginArea(texRect);
                    GUI.DrawTexture(texRect, CinemachineSettings.CinemachineHeader, ScaleMode.ScaleToFit);
                    GUILayout.EndArea();
                    GUILayout.FlexibleSpace();

                    GUILayout.EndScrollView();
                }

                EditorGUILayout.LabelField("Welcome to Cinemachine!", mLabelStyle);
                EditorGUILayout.LabelField("Smart camera tools for passionate creators.", mLabelStyle);
                //EditorGUILayout.SelectableLabel("user@cinemachineimagery.com", mLabelStyle);
                EditorGUILayout.LabelField("Below are links to the documentation and to the forums, please reach out if you have any questions or feedback", mLabelStyle);

                if (GUILayout.Button("<b>Documentation</b>\n<i>Read</i>", mButtonStyle))
                {
                    Application.OpenURL("http://www.cinemachineimagery.com/documentation/");
                }

                if (GUILayout.Button("<b>Tutorials</b>\n<i>Watch</i>", mButtonStyle))
                {
                    Application.OpenURL("http://www.cinemachineimagery.com/tutorials/");
                }

                if (GUILayout.Button("<b>Forum</b>\n<i>Discuss</i>", mButtonStyle))
                {
                    Application.OpenURL("https://forum.unity3d.com/forums/timeline-cinemachine.127/");
                }

                if (GUILayout.Button("<b>Rate it!</b>\nUnity Asset Store", mButtonStyle))
                {
                    Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/60946");
                }
            }

            EditorGUILayout.LabelField("Release Notes", mHeaderStyle);
            using (var scrollScope = new EditorGUILayout.ScrollViewScope(mReleaseNoteScrollPos, GUI.skin.box))
            {
                mReleaseNoteScrollPos = scrollScope.scrollPosition;
            }

            //using (var horScope = new EditorGUILayout.HorizontalScope())
            //{
            //    GUILayout.FlexibleSpace();
            //    ShowOnStart = EditorGUILayout.Toggle("Show On Startup", ShowOnStart);
            //}
        }

        [MenuItem("Cinemachine/About")]
        private static void OpenWindow()
        {
            EditorApplication.update += ShowWindowDeferred;
        }

        private static void ShowWindowDeferred()
        {
            string loadedVersion = LastVersionLoaded;
//            if (loadedVersion != Cinemachine.Utility.CinemachineDebugLogger.kVersionString)
//            {
//                LastVersionLoaded = Cinemachine.Utility.CinemachineDebugLogger.kVersionString;
//            }

            AboutWindow window = EditorWindow.GetWindow<AboutWindow>();

            window.titleContent = new UnityEngine.GUIContent("About", CinemachineSettings.CinemachineLogoTexture);
            window.minSize = kMinWindowSize;
            window.Show(true);

            EditorApplication.update -= ShowWindowDeferred;
        }
    }
}
