using UnityEngine;

public class GrappleTarget : MonoBehaviour
{
    public Vector3 offset;
    public float traversalTime = 0.5F;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(transform.position + offset, (Vector3.one - Vector3.up) * 2);
    }
}
