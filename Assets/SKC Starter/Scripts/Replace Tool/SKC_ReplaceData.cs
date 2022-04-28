using UnityEngine;

/// <summary>
/// Data class for replace tool.
/// </summary>
public class SKC_ReplaceData : ScriptableObject
{
    // Reference to replace object.
    public GameObject replaceObject;

    // Array of object to replace.
    public GameObject[] objectsToReplace;
}