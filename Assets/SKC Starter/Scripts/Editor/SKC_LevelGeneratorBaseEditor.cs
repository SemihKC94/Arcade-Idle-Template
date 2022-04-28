/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SKC_LevelGeneratorBase))]
public class SKC_LevelGeneratorBaseEditor : Editor
{
    public enum Direction { RightAxes, UpAxes, ForwardAxes,NegativeRightAxes, NegativeUpAxes,NegativeForwardAxes }

    Direction direction;

    SerializedProperty platforms, randomize, spawnAmount, spaceBetweenPlatform, spawnAngle, angelStep,blockCount,blockRandom;
    private void OnEnable()
    {
        SKC_LevelGeneratorBase myLevelGenerator = (SKC_LevelGeneratorBase)target;

        platforms = serializedObject.FindProperty("platforms");
        randomize = serializedObject.FindProperty("randomize");
        spawnAmount = serializedObject.FindProperty("spawnAmount");
        spaceBetweenPlatform = serializedObject.FindProperty("spaceBetweenPlatform");
        spawnAngle = serializedObject.FindProperty("spawnAngle");
        angelStep = serializedObject.FindProperty("angelStep");
        blockCount = serializedObject.FindProperty("blockCount");
        blockRandom = serializedObject.FindProperty("blockRandom");
    }

    public override void OnInspectorGUI()
    {
        SKC_LevelGeneratorBase myLevelGenerator = (SKC_LevelGeneratorBase)target;
        serializedObject.Update();

        GUILayout.Label("Select Direction" );
        direction = (Direction)EditorGUILayout.EnumPopup(direction);

        GUILayout.Space(10);

        GUILayout.Label("Add Your Platform/s" );
        EditorGUILayout.PropertyField(platforms);

        GUILayout.Space(10);

        GUILayout.Label("How Many Spawn?" );
        EditorGUILayout.PropertyField(spawnAmount);

        GUILayout.Space(10);

        GUILayout.Label("Space Between Platforms" );
        EditorGUILayout.PropertyField(spaceBetweenPlatform);

        GUILayout.Space(10);

        GUILayout.Label("Angle for Spawning Object" );
        EditorGUILayout.PropertyField(spawnAngle);

        GUILayout.Space(10);

        GUILayout.Label("Increase each spawn angle" );
        EditorGUILayout.PropertyField(angelStep);

        GUILayout.Space(10);

        GUILayout.Label("Random Spawn");
        EditorGUILayout.PropertyField(randomize);
        GUILayout.Space(10);

        GUILayout.Label("Random Spawn");
        EditorGUILayout.PropertyField(blockRandom);
        GUILayout.Space(10);
        if (myLevelGenerator.blockRandom)
        {
            GUILayout.Space(10);

            GUILayout.Label("Random Block");
            EditorGUILayout.PropertyField(blockCount);
        }

        GUILayout.Space(10);

        if(GUILayout.Button("Generate Level"))
        {
            if (direction == Direction.RightAxes) CreateRight();
            if (direction == Direction.UpAxes) CreateUp();
            if (direction == Direction.ForwardAxes) CreateFor();
            if (direction == Direction.NegativeRightAxes) CreateNegRight();
            if (direction == Direction.NegativeUpAxes) CreateNegUp();
            if (direction == Direction.NegativeForwardAxes) CreateNegFor();
        }

        GUILayout.Space(10);

        if(GUILayout.Button("Delete Selected Child"))
        {
            DeleteChilds();
        }

        serializedObject.ApplyModifiedProperties();
    }

    void DeleteChilds()
    {
        Transform obj = Selection.activeTransform;

        if(obj != null)
        {
            int childCount = obj.childCount;

            for (int i = childCount - 1; i >= 0; i--)
            {
                Transform t = obj.GetChild(i).transform;
                DestroyImmediate(t.gameObject);
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Warning", "You should select an object or objects", "Get it");
        }
    }

    void CreateRight()
    {
        SKC_LevelGeneratorBase myLevelGenerator = (SKC_LevelGeneratorBase)target;

        Transform obj = Selection.activeTransform;

        if (obj == null) myLevelGenerator.CreateLevelRight();
        else myLevelGenerator.CreateLevelRight(obj);

#if UNITY_EDITOR
        Debug.Log("Right Axes Create Level");
#endif
    }

    void CreateUp()
    {
        SKC_LevelGeneratorBase myLevelGenerator = (SKC_LevelGeneratorBase)target;

        Transform obj = Selection.activeTransform;

        if (obj == null) myLevelGenerator.CreateLevelUp();
        else myLevelGenerator.CreateLevelUp(obj);

#if UNITY_EDITOR
        Debug.Log("Up Axes Create Level");
#endif
    }

    void CreateFor()
    {
        SKC_LevelGeneratorBase myLevelGenerator = (SKC_LevelGeneratorBase)target;

        Transform obj = Selection.activeTransform;

        if (obj == null) myLevelGenerator.CreateLevelForward();
        else myLevelGenerator.CreateLevelForward(obj);

#if UNITY_EDITOR
        Debug.Log("Forward Axes Create Level");
#endif
    }

    void CreateNegRight()
    {
        SKC_LevelGeneratorBase myLevelGenerator = (SKC_LevelGeneratorBase)target;

        Transform obj = Selection.activeTransform;

        if (obj == null) myLevelGenerator.CreateLevelNegativeRight();
        else myLevelGenerator.CreateLevelNegativeRight(obj);

#if UNITY_EDITOR
        Debug.Log("Negative Right Axes Create Level");
#endif
    }

    void CreateNegUp()
    {
        SKC_LevelGeneratorBase myLevelGenerator = (SKC_LevelGeneratorBase)target;

        Transform obj = Selection.activeTransform;

        if (obj == null) myLevelGenerator.CreateLevelNegativeUp();
        else myLevelGenerator.CreateLevelNegativeUp(obj);

#if UNITY_EDITOR
        Debug.Log("Negative Up Axes Create Level");
#endif
    }

    void CreateNegFor()
    {
        SKC_LevelGeneratorBase myLevelGenerator = (SKC_LevelGeneratorBase)target;

        Transform obj = Selection.activeTransform;

        if (obj == null) myLevelGenerator.CreateLevelNegativeForward();
        else myLevelGenerator.CreateLevelNegativeForward(obj);

#if UNITY_EDITOR
        Debug.Log("Negative Forward Axes Create Level");
#endif
    }
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */