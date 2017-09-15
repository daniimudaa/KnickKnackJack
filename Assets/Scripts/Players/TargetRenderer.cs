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
        SpriteRenderer spr = targetIndicatorObject.AddComponent<SpriteRenderer>();

        targetIndicatorObject.AddComponent<TargetIndicator>();

        spr.sprite = targetIndicator;
        spr.color = colorMultiplier;

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
