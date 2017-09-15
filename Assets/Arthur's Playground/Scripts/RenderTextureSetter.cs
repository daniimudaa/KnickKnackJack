using UnityEngine;

public class RenderTextureSetter : MonoBehaviour
{
    public Camera cam;

    public Vector3 size;

    private RenderTexture ren;

    private void OnEnable()
    {
        ren = new RenderTexture((int)size.x, (int)size.y, (int)size.z);
        cam.targetTexture = ren;

        Shader s = Shader.Find("Unlit/Texture");
        Material mat = new Material(s);
        mat.mainTexture = ren;

        GetComponent<Renderer>().material = mat;
    }

    private void OnDisable()
    {
        ren.Release();
    }
}
