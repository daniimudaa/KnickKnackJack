using UnityEngine;

public class Rotator : MonoBehaviour {
    public Vector3 rotation;
    public float speed = 2F;

    private void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
