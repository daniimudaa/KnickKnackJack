using UnityEngine;

public class TargetRenderer : MonoBehaviour
{
    [Space]
    public Sprite targetIndicator;
    [ColorUsage(true)]
    public Color colorMultiplier = Color.white;

    private GameObject targetIndicatorObject;

    private bool active = false;

    private void Start()
    {
        targetIndicatorObject = new GameObject("targetIndicator");
        GameObject targetIndicatorDraw = new GameObject("targetDraw");
        targetIndicatorDraw.transform.SetParent(targetIndicatorObject.transform);

        SpriteRenderer spr = targetIndicatorDraw.AddComponent<SpriteRenderer>();

        targetIndicatorDraw.AddComponent<TargetIndicator>();

        spr.sprite = targetIndicator;
        spr.color = colorMultiplier;
        spr.material = new Material(Shader.Find("Sprites/NoClip"));

        targetIndicatorObject.SetActive(active);
    }

    public void SetActive(bool active)
    {
        if (this.active != active)
        {
            this.active = active;
            targetIndicatorObject.SetActive(active);
        }
    }

    public void SetPosition(Vector3 vec)
    {
        targetIndicatorObject.transform.position = vec;
    }
}
