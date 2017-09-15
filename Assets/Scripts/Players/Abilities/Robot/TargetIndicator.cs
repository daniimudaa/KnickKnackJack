using UnityEngine;

public class TargetIndicator : MonoBehaviour {
    public float speed = 50F;

    private Vector3 baseSize;
    private float angle = 0F;

    private void Awake()
    {
        baseSize = transform.localScale;
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(new Vector3(0F, 0F, angle += (speed * Time.deltaTime)));
        transform.localScale = baseSize * (1.5F + Mathf.Sin(angle * Mathf.Deg2Rad * 2F) * .5F);
    }
}
