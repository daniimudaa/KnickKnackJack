using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CameraTrigger : MonoBehaviour
{
    public static readonly List<CameraTrigger> cache = new List<CameraTrigger>();

    public bool alwaysDrawFrustrum = false;
    public int order;

    [Space]
    public bool followRotation;
    public Vector2 panLimit = Vector2.zero;

    [NonSerialized]
    public bool containsPlayers;

    [NonSerialized]
    public Transform cameraTransform;

    private void Start()
    {
        CheckCameraPoint();
    }

    private void OnEnable()
    {
        cache.Add(this);
    }

    private void OnDisable()
    {
        cache.Remove(this);
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.tag);
        if (other.CompareTag("Player"))
            containsPlayers = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            containsPlayers = false;
    }

    private void OnValidate()
    {
        CheckCameraPoint();
    }

    private void OnDrawGizmos()
    {
        if (alwaysDrawFrustrum)
            OnDrawGizmosSelected();
    }

    private void OnDrawGizmosSelected()
    {
        CheckCameraPoint();

        Gizmos.color = Color.magenta;

        Matrix4x4 temp = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(cameraTransform.position, cameraTransform.rotation, Vector3.one);
        if (Camera.main.orthographic)
        {
            float spread = Camera.main.farClipPlane - Camera.main.nearClipPlane;
            float center = (Camera.main.farClipPlane + Camera.main.nearClipPlane) * 0.5f;
            Gizmos.DrawWireCube(new Vector3(0, 0, center), new Vector3(Camera.main.orthographicSize * 2 * Camera.main.aspect, Camera.main.orthographicSize * 2, spread));
        }
        else
        {
            Gizmos.DrawFrustum(Vector3.zero, Camera.main.fieldOfView, Camera.main.farClipPlane, Camera.main.nearClipPlane, Camera.main.aspect);
        }
        Gizmos.matrix = temp;
    }

    private void CheckCameraPoint()
    {
        if (!cameraTransform)
        {
            Transform t = transform.Find("CameraPlacement");
            if (!t)
            {
                t = new GameObject("CameraPlacement").transform;
                t.SetParent(transform, false);
            }

            cameraTransform = t;
        }
    }
}
