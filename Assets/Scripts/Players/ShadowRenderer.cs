using UnityEngine;

public class ShadowRenderer : MonoBehaviour
{
    public float size;
    [ColorUsage(true)]
    public Color color = new Color(0F, 0F, 0F, 0.5F);
    public Vector3 offset = new Vector3(0F, .1F, 0F);

    private new Collider collider;
    private SpriteRenderer shadow;

    private int layerMask;

    private void Awake()
    {
		collider = GetComponentInChildren<Collider>();

        GameObject go = new GameObject("shadowRender");
        go.transform.SetParent(transform, false);
        go.transform.Rotate(90, 0, 0);
        go.transform.localScale = new Vector3(size, size);

        shadow = go.AddComponent<SpriteRenderer>();
        shadow.sprite = Resources.Load<Sprite>("Sprites/Shadow");
        shadow.color = color;

        layerMask = 0;
        for (int i = 0; i < 32; i++)
        {
            if (!Physics.GetIgnoreLayerCollision(gameObject.layer, i))
            {
                layerMask = layerMask | 1 << i;
            }
        }
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Ray(collider.bounds.center, Vector3.down), out hit, 200F, layerMask))
        {
            shadow.transform.localScale = new Vector3(size, size);
            shadow.transform.position = new Vector3(transform.position.x, collider.bounds.center.y - hit.distance, transform.position.z) + offset;
            shadow.transform.forward = hit.normal;
        }
        else
        {
            shadow.transform.localScale = new Vector3(0F, 0F);
        }
    }
}
