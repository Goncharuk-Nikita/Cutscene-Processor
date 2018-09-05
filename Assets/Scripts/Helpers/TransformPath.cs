using System;
using UnityEngine;

[Serializable]
public class TransformPath  
{
    public int id { get; set; }
    public string fullPath { get;  set; }

    private TransformPath()
    { }

    public static TransformPath GetPath(Transform transform)
    {
        return new TransformPath
        {
            id = transform.GetInstanceID(),
            fullPath = GetHierarchyPath(transform)
        };
    }

    private static string GetHierarchyPath(Transform transform)
    {
         var path = transform.name;
         while (transform.parent != null)
         {
             transform = transform.parent;
             path = transform.name + "/" + path;
         }
        
         return path;
    }
}
