using UnityEngine;

public class TargetRenderer : MonoBehaviour
{
    private static Material spriteNoclip;

    [Space]
    public Sprite targetIndicator;
    [ColorUsage(true)]
    public Color colorMultiplier = Color.white;

    private GameObject targetIndicatorObject;

    private bool active = false;

    private void Start()
    {
        if (!spriteNoclip)
            spriteNoclip = new Material(Shader.Find("Sprites/NoClip"));

        targetIndicatorObject = new GameObject("targetIndicator");
        GameObject targetIndicatorDraw = new GameObject("targetDraw");
        targetIndicatorDraw.transform.SetParent(targetIndicatorObject.transform);

        SpriteRenderer spr = targetIndicatorDraw.AddComponent<SpriteRenderer>();

        targetIndicatorDraw.AddComponent<TargetIndicator>();

        spr.sprite = targetIndicator;
        spr.color = colorMultiplier;
        spr.material = spriteNoclip;

        GameObject buttonDraw = new GameObject("buttonDraw");
        buttonDraw.transform.SetParent(buttonDraw.transform);

        spr = buttonDraw.AddComponent<SpriteRenderer>();

        //spr.sprite = Create Button Sprites
        spr.material = spriteNoclip;

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
