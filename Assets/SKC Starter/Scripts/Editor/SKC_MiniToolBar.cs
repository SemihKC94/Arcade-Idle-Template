/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEditor;
using UnityEngine;

public class SKC_MiniToolBar : EditorWindow
{
    [MenuItem("SKC/Mini Toolbar")]
    public static void ShowWindow()
    {
        //GetWindow<SKC_MiniToolBar>("Mini ToolBar"); //Flexible
        GetWindowWithRect<SKC_MiniToolBar>(new Rect(0, 0, 80, 600));
    }

    Color color;
    Vector3 pHolder = Vector3.zero;
    Vector3 pPrevious = Vector3.zero;
    Quaternion rHolder = Quaternion.identity;
    Quaternion rPre = Quaternion.identity;
    Vector3 sHolder = Vector3.zero;
    Vector3 sPre = Vector3.zero;
    Transform tHolder;
    Transform tParent;

    private void OnGUI()
    {
        GUILayout.Space(11);
        //GUI.backgroundColor = Color.red;
        EditorGUILayout.BeginVertical("Toolbar", GUILayout.ExpandHeight(true),GUILayout.Width(80));
        if (GUILayout.Button("T Copy", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            TransformCopy();
        }
        if (GUILayout.Button("T Paste", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            TransformPaste();
        }
        if (GUILayout.Button("T Reset", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            TransformReset();
        }
        if (GUILayout.Button("P Reset", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            PositionReset();
        }
        if (GUILayout.Button("R Reset", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            RotationReset();
        }
        if (GUILayout.Button("S Reset", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            ScaleReset();
        }
        if (GUILayout.Button("P Copy", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            PositionCopy();
        }
        if (GUILayout.Button("P Paste", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            PositionPaste();
        }
        if (GUILayout.Button("P Undo", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            PositionUndo();
        }
        if (GUILayout.Button("R Copy", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            RotationCopy();
        }
        if (GUILayout.Button("R Paste", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            RotationPaste();
        }
        if (GUILayout.Button("R Undo", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            RotationUndo();
        }
        if (GUILayout.Button("S Copy", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            ScaleCopy();
        }
        if (GUILayout.Button("S Paste", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            ScalePaste();
        }
        if (GUILayout.Button("S Undo", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            ScaleUndo();
        }
        if (GUILayout.Button("Create E", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            CreateEmptyObject();
        }
        if (GUILayout.Button("Create C", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            CreateChildObject();
        }
        if (GUILayout.Button("Add RB", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            AddComponentRB();
        }
        if (GUILayout.Button("Y Copy", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)) || Input.GetKeyDown(KeyCode.N))
        {
            XYCopy();
        }
        if (GUILayout.Button("Y Paste", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)) || Input.GetKeyDown(KeyCode.M))
        {
            XYPaste();
        }
        //GUILayout.Space(20);
        color = (Color)EditorGUILayout.ColorField(color);
        if (GUILayout.Button("Color", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            Colorize();
        }
        if (GUILayout.Button("Parent Select", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            ParentSelect();
        }
        if (GUILayout.Button("To Child", "ToolbarButton", GUILayout.Width(80), GUILayout.Height(25)))
        {
            SelectedChildToParent();
        }
        //GUILayout.FlexibleSpace();
        EditorGUILayout.EndVertical();
    }

    void ParentSelect()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            tParent = obj.transform;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }

    void SelectedChildToParent()
    {
        GameObject[] objs = Selection.gameObjects;
        if (objs != null)
        {
            foreach(GameObject obj in objs)
            {
                obj.transform.parent = tParent;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }

    void TransformCopy()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            tHolder = obj.transform;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void TransformPaste()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            obj.transform.position = tHolder.position;
            obj.transform.rotation = tHolder.rotation;
            obj.transform.localScale = tHolder.localScale;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }

    void TransformReset()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            if(obj != null)
            {
                obj.transform.position = Vector3.zero;
                obj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                obj.transform.localScale = Vector3.one;
            }
            else
            {
                EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
            }
        }
    }
    void PositionReset()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            if(obj != null)
            {
                obj.transform.position = Vector3.zero;
            }
            else
            {
                EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
            }
        }
    }
    void RotationReset()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            if(obj != null)
            {
                obj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
            }
        }
    }
    void ScaleReset()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            if(obj != null)
            {
                obj.transform.localScale = Vector3.one;
            }
            else
            {
                EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
            }
        }

    }

    void PositionCopy()
    {
        GameObject obj = Selection.activeGameObject;
        if(obj != null)
        {
            pHolder = obj.transform.position;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void PositionPaste()
    {
        GameObject obj = Selection.activeGameObject;
        if(obj != null)
        {
            pPrevious = obj.transform.position;
            obj.transform.position = pHolder;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void PositionUndo()
    {
        GameObject obj = Selection.activeGameObject;
        if(obj != null)
        {
            obj.transform.position = pPrevious;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void XYCopy()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            pHolder = new Vector3(0f, obj.transform.position.y, 0f);
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void XYPaste()
    {
        GameObject obj = Selection.activeGameObject;
        if (obj != null)
        {
            pPrevious = new Vector3(0f, obj.transform.position.y, 0f);
            obj.transform.position = new Vector3(obj.transform.parent.position.x, pHolder.y, obj.transform.parent.position.z);
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void RotationCopy()
    {
        GameObject obj = Selection.activeGameObject;
        if(obj != null)
        {
            rHolder = obj.transform.rotation;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void RotationPaste()
    {
        GameObject obj = Selection.activeGameObject;
        if(obj != null)
        {
            rPre = obj.transform.rotation;
            obj.transform.rotation = rHolder;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void RotationUndo()
    {
        GameObject obj = Selection.activeGameObject;
        if(obj != null)
        {
            obj.transform.rotation = rPre;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void ScaleCopy()
    {
        GameObject obj = Selection.activeGameObject;
        if(obj != null)
        {
            sHolder = obj.transform.localScale;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void ScalePaste()
    {
        GameObject obj = Selection.activeGameObject;
        if(obj != null)
        {
            sPre = obj.transform.localScale;
            obj.transform.localScale = sHolder;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void ScaleUndo()
    {
        GameObject obj = Selection.activeGameObject;
        if(obj != null)
        {
            obj.transform.localScale = sPre;
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void CreateEmptyObject()
    {
        GameObject obj = new GameObject();
        obj.name = "SKC New Object(E)";
    }
    void CreateChildObject()
    {
        GameObject obj = Selection.activeGameObject;
        if(obj != null)
        {
            GameObject obj2 = new GameObject();
            obj2.transform.position = obj.transform.position;
            obj2.transform.rotation = obj.transform.rotation;
            obj2.transform.localScale = obj.transform.localScale;
            obj2.transform.SetParent(obj.transform);
            obj2.name = "SKC New Child Object(E)";
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }
    void AddComponentRB()
    {
        GameObject obj = Selection.activeGameObject;
        if(obj != null)
        {
            if (obj.GetComponent<Rigidbody>() == null) obj.AddComponent<Rigidbody>();
            else EditorUtility.DisplayDialog("Attention", "Selected object has already Rigidbody", "Get it");
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }


    void Colorize()
    {
        
        foreach (GameObject obj in Selection.gameObjects)
        {
            if(obj != null)
            {
                Material material = new Material(Shader.Find("Standard"));
                material.color = color;
                int random = Random.Range(0, 1000);
                string name = "SKC_CreatedMaterial" + random.ToString() + ".mat";
                AssetDatabase.CreateAsset(material, "Assets/Materials/" + name);
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sharedMaterial = material;
                }
            }
            else
            {
                EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
            }
        }
    }
}


/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */