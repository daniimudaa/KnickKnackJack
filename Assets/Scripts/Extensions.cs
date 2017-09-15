using UnityEngine;

public static class Extensions {
    public static Vector3 NormalizeRotation(this Vector3 rotation)
    {
        return NormalizeRotation(rotation.x, rotation.y, rotation.z);
    }

    public static Vector3 NormalizeRotation(float x, float y, float z)
    {
        x %= 360;
        y %= 360;
        z %= 360;

        if (x < 0)
            x += 360;
        if (y < 0)
            y += 360;
        if (z < 0)
            z += 360;

        return new Vector3(x, y, z);
    }
}
