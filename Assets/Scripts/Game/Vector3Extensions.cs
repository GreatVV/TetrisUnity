using UnityEngine;

public static class Vector3Extensions
{
    public static Vector3 RoundToInt(this Vector3 vector)
    {
        var clamped = new Vector3
                      {
                          x = Mathf.RoundToInt(vector.x),
                          y = Mathf.RoundToInt(vector.y),
                          z = Mathf.RoundToInt(vector.z)
                      };
        return clamped;
    }
}