/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEditor;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using SKC.Utils;

public class SKC_Editor : EditorWindow
{
    //Main Toolbar
    private static int _toolBar = 0;
    private static string[] toolBarString = { "Manipulator", "Snap", "Paint", "Exit" };


    private static GUISkin skin;
    private static GUIStyle toolBarStyle;
    private static GUIStyle toolBarSubStyle;
    private static GUIStyle textError;

    //private Vars
    Color color;
    static Vector3 pHolder = Vector3.zero;
    static Vector3 pPrevious = Vector3.zero;
    static Quaternion rHolder = Quaternion.identity;
    static Quaternion rPre = Quaternion.identity;
    static Vector3 sHolder = Vector3.zero;
    static Vector3 sPre = Vector3.zero;

    static bool sceneViewOnScreen = false;

    private void OnGUI()  // Only Work with Windows
    {
        skin = (GUISkin)AssetDatabase.LoadAssetAtPath("Assets/SKC Starter/Textures/EditorButtons/editorGUISkin.guiskin", typeof(GUISkin)); // Load Skin
        toolBarStyle = skin.GetStyle("Button");
        toolBarSubStyle = skin.GetStyle("Box");
        textError = skin.GetStyle("LabelError");

        var windowRect = new Rect(0, 0, 800, 400);
        GUILayout.BeginArea(windowRect);
        
        GUILayout.BeginArea(new Rect(750, 0, 45, 35));

        if (GUILayout.Button("Close"))
        {
            SKC_Editor window = (SKC_Editor)EditorWindow.GetWindow(typeof(SKC_Editor));
            window.Close();
        }
        GUILayout.EndArea();


        if(sceneViewOnScreen)
        {
            if (_toolBar == 2)
            {
                PaintArea();
            }
        }
        else
        {
            GUILayout.Label("Please open SKC / Editor from top menu.", textError);
        }


        GUILayout.EndArea();
    }

    [MenuItem("SKC/Editor")]
    public static void ShowEditor()
    {
        sceneViewOnScreen = true;

        skin = (GUISkin)AssetDatabase.LoadAssetAtPath("Assets/SKC Starter/Textures/EditorButtons/editorGUISkin.guiskin", typeof(GUISkin)); // Load Skin
        toolBarStyle = skin.GetStyle("Button"); 
        toolBarSubStyle = skin.GetStyle("Box");
        textError = skin.GetStyle("LabelError");

        SceneView.duringSceneGui += OnSceneGUI;
        if (SceneView.lastActiveSceneView) SceneView.lastActiveSceneView.Repaint();
    }

    [MenuItem("SKC/Editor Window")]
    public static void ShowWindow()
    {
        //SKC_Editor window = (SKC_Editor)EditorWindow.GetWindowWithRect<SKC_Editor>(new Rect(0,0,800,400));
        SKC_Editor window = ScriptableObject.CreateInstance(typeof(SKC_Editor)) as SKC_Editor;
        window.maxSize = new Vector2(800, 400);
        window.minSize = new Vector2(800, 400);
        window.ShowUtility();
    }
    private static void OnSceneGUI(SceneView sceneView)
    {
        GUI.skin = skin;

        Handles.BeginGUI();
        
        // We define the toolbars' rects here
        var ToolBarRect = new Rect((SceneView.lastActiveSceneView.camera.pixelRect.width / 6), 10, (SceneView.lastActiveSceneView.camera.pixelRect.width * 4 / 6), SceneView.lastActiveSceneView.camera.pixelRect.height / 20);
        GUILayout.BeginArea(ToolBarRect);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        _toolBar = GUILayout.Toolbar(_toolBar,toolBarString,toolBarStyle);

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
        
        //GUI.skin = default;

        switch (_toolBar)
        {
            case 0:
                var ToolBarRectMan = new Rect((SceneView.lastActiveSceneView.camera.pixelRect.width / 7), 35, (SceneView.lastActiveSceneView.camera.pixelRect.width * 4 / 6), SceneView.lastActiveSceneView.camera.pixelRect.height / 15);
                GUILayout.BeginArea(ToolBarRectMan);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("T Reset",  toolBarSubStyle))
                {
                    TransformReset();
                }

                if (GUILayout.Button("P Reset", toolBarSubStyle))
                {
                    PositionReset();
                }

                if (GUILayout.Button("R Reset", toolBarSubStyle))
                {
                    RotationReset();
                }

                if (GUILayout.Button("S Reset", toolBarSubStyle))
                {
                    ScaleReset();
                }

                if (GUILayout.Button("P Copy", toolBarSubStyle))
                {
                    PositionCopy();
                }

                if (GUILayout.Button("P Paste", toolBarSubStyle))
                {
                    PositionPaste();
                }

                if (GUILayout.Button("R Copy", toolBarSubStyle))
                {
                    RotationCopy();
                }

                if (GUILayout.Button("R Paste", toolBarSubStyle))
                {
                    RotationPaste();
                }

                if (GUILayout.Button("S Copy", toolBarSubStyle))
                {
                    ScaleCopy();
                }

                if (GUILayout.Button("S Paste", toolBarSubStyle))
                {
                    ScalePaste();
                }

                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
                break;

            case 1:
                var ToolBarRectSnap = new Rect((SceneView.lastActiveSceneView.camera.pixelRect.width / 7), 35, (SceneView.lastActiveSceneView.camera.pixelRect.width * 4 / 6), SceneView.lastActiveSceneView.camera.pixelRect.height / 15);
                GUILayout.BeginArea(ToolBarRectSnap);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("Snap", GUILayout.Height(ToolBarRect.height)))
                {
                    Debug.Log("Snap Pressed");
                }

                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
                break;

            case 2:
                var ToolBarRectPaint = new Rect((SceneView.lastActiveSceneView.camera.pixelRect.width / 7), 35, (SceneView.lastActiveSceneView.camera.pixelRect.width * 4 / 6), SceneView.lastActiveSceneView.camera.pixelRect.height / 15);
                GUILayout.BeginArea(ToolBarRectPaint);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();


                if (GUILayout.Button("Paint", GUILayout.Height(ToolBarRect.height)))
                {
                    Debug.Log("Paint Pressed");
                }

                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
                break;

            case 3:
                sceneViewOnScreen = false;
                SceneView.duringSceneGui -= OnSceneGUI;
                if (SceneView.lastActiveSceneView) SceneView.lastActiveSceneView.Repaint();
                _toolBar = 0;

                break;

        }
        Handles.EndGUI();
    }

    #region Manipulator Methods
    private static void TransformReset()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj != null)
            {
                obj.transform.position = Vector3.zero;
                obj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                obj.transform.localScale = Vector3.one;
            }
            else
            {
                Debug.LogError("You should select an object or objects");
                EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
            }
        }
    }

    private static void PositionReset()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj != null)
            {
                obj.transform.position = Vector3.zero;
            }
            else
            {
                EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
            }
        }
    }

    private static void RotationReset()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj != null)
            {
                obj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
            }
        }
    }

    private static void ScaleReset()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj != null)
            {
                obj.transform.localScale = Vector3.one;
            }
            else
            {
                EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
            }
        }

    }

    private static void PositionCopy()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            pHolder = obj.transform.position;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    private static void PositionPaste()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            pPrevious = obj.transform.position;
            obj.transform.position = pHolder;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    private static void PositionUndo()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            obj.transform.position = pPrevious;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    private static void RotationCopy()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            rHolder = obj.transform.rotation;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    private static void RotationPaste()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            rPre = obj.transform.rotation;
            obj.transform.rotation = rHolder;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    private static void RotationUndo()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            obj.transform.rotation = rPre;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    private static void ScaleCopy()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            sHolder = obj.transform.localScale;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    private static void ScalePaste()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            sPre = obj.transform.localScale;
            obj.transform.localScale = sHolder;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    private static void ScaleUndo()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            obj.transform.localScale = sPre;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }

    #endregion

    private static void PaintArea()
    {
        GUILayout.BeginArea(new Rect(0, 0, 150, 500));
        GUILayout.BeginHorizontal();
        GUILayout.Box("Prefab Drop Box", GUILayout.Width(150), GUILayout.Height(500));
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */