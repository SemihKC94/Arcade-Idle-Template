using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class SKC_TransformExtensions
{
    /// <summary>
    /// Gets all children of tranfsorm and returns them.
    /// </summary>
    /// <returns>List of children.</returns>
    /// <param name="transform">Transform.</param>
    public static List<Transform> GetChildren(this Transform transform)
    {
        var children = new List<Transform>();

        // Iterate over all children in transform.
        foreach (Transform child in transform)
        {
            children.Add(child);
        }

        return children;
    }

    public static List<Transform> GetChildrenIsActive(this Transform transform)
    {
        var children = new List<Transform>();

        // Iterate over all children in transform.
        foreach (Transform child in transform)
        {
            if(child.gameObject.activeSelf == true) children.Add(child);
        }

        return children;
    }

    public static List<Transform> GetChildrenIsInActive(this Transform transform)
    {
        var children = new List<Transform>();

        // Iterate over all children in transform.
        foreach (Transform child in transform)
        {
            if(child.gameObject.activeSelf == false) children.Add(child);
        }

        return children;
    }

    /// <summary>
    /// Gets all children of tranfsorm and returns them.
    /// </summary>
    /// <returns>Array of children.</returns>
    /// <param name="transform">Transform.</param>
    public static Transform[] GetChildrenArray(this Transform transform)
    {
        var children = new Transform[transform.childCount - 1];

        // Iterate over all children in transform.
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Transform child = transform.GetChild(i);
            children[i] = child;
        }
        return children;
    }

    /// <summary>
    /// Gets all children of tranfsorm and returns them.
    /// </summary>
    /// <returns>Array of childern.</returns>
    /// <param name="Renderer">Renderer.</param>
    public static List<Renderer> GetRendererToTransformLists(this List<Transform> transform)
    {
        var children = new List<Renderer>();

        // Iterate over all children in transform.
        foreach (Transform child in transform)
        {
            children.Add(child.GetComponent<Renderer>());
        }

        return children;
    }

    public static List<NavMeshSurface> GetNavMeshSurfacesToTransformLists(this List<Transform> transform)
    {
        var children = new List<NavMeshSurface>();

        // Iterate over all children in transform.
        foreach (Transform child in transform)
        {
            children.Add(child.GetComponent<NavMeshSurface>());
        }

        return children;
    }

    public static List<NavMeshAgent> GetNavMeshAgentsToTransformLists(this List<Transform> transform)
    {
        var children = new List<NavMeshAgent>();

        // Iterate over all children in transform.
        foreach (Transform child in transform)
        {
            children.Add(child.GetComponent<NavMeshAgent>());
        }

        return children;
    }

    public static List<UniqueTerritory> GetUniqueTerritoriesFromTransformList(this Transform transform)
    {
        var children = new List<UniqueTerritory>();

        // Iterate over all children in transform.
        foreach (Transform child in transform)
        {
            children.Add(child.GetComponent<UniqueTerritory>());
        }

        return children;
    }
}
