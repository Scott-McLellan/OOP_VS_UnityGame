using UnityEngine;

public static class ScottMath
{
    public static float GetDistance(Vector2 a, Vector2 b)
    {
        return Mathf.Sqrt(((a.x - b.x) * (a.x - b.x)) + ((a.y - b.y) * (a.y - b.y)));
    }
}
