using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtils
{
    public static Vector3 WithZ(this Vector3 vec, float z)
    {
        return new Vector3(vec.x, vec.y, z);
    }
    
    public static Vector3 WithZ(this Vector2 vec, float z)
    {
        return new Vector3(vec.x, vec.y, z);
    }
}
