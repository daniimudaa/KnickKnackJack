using UnityEngine;

public class HeavyCubeNew : MonoBehaviour
{
    public Vector3 targetPositionOffset;
    public Vector3 targetRotationOffset;
    public float timeInSeconds = 2F;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool playing = false;
    private float currentTime = 0F;

    private MeshFilter fl;

    private void OnCollisionEnter(Collision collision)
    {
        if (playing || !collision.gameObject.CompareTag("Player"))
            return;
        CharController controller = collision.gameObject.GetComponent<CharController>();
        if (controller && controller.characterIndex == CharController.Character.TEDDY)
        {
            playing = true;
            currentTime = 0F;
            initialPosition = transform.localPosition;
            initialRotation = transform.localRotation;
        }
    }

    private void Update()
    {
        if (!playing)
            return;

        currentTime += Time.deltaTime;

        transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition + targetPositionOffset, currentTime / timeInSeconds);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, initialRotation * Quaternion.Euler(targetRotationOffset), currentTime / timeInSeconds);

        if (currentTime >= timeInSeconds)
            Destroy(this);
    }

    private void OnDrawGizmos()
    {
        Vector3 pos = transform.localPosition;
        Quaternion rot = transform.localRotation;

        if (playing)
        {
            pos = initialPosition;
            rot = initialRotation;
        }
        if (!fl)
            fl = GetComponent<MeshFilter>();

        Gizmos.color = Color.green;
        Gizmos.matrix = transform.parent.localToWorldMatrix;

        Gizmos.DrawLine(pos, pos + targetPositionOffset);
        Gizmos.DrawWireMesh(fl.sharedMesh, pos + targetPositionOffset, rot * Quaternion.Euler(targetRotationOffset), transform.localScale);
    }
}
