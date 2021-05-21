using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static Transform GetSibling(this Transform transform, int index)
    {
        Transform parent = transform.parent;

        if (parent.childCount > index)
        {
            return parent.GetChild(index);
        }

        return null;
    }

    public static void SetZ(this Vector3 vector3, float z)
    {
        vector3 = new Vector3(vector3.x, vector3.y, z);
    }
}
