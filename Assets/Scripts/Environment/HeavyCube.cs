using UnityEngine;

public class HeavyCube : MonoBehaviour
{
    public bool simplistic = true;

    [ConditionalHide("simplistic", true, true)]
    public Vector3 targetPositionOffset;
    [ConditionalHide("simplistic", true, true)]
    public Vector3 targetRotationOffset;
    [ConditionalHide("simplistic", true, true)]
    public float timeInSeconds = 5F;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool playing = false;
    private float currentTime = 0F;

    private new Rigidbody rigidbody;

    private MeshFilter fl;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (playing || !collision.gameObject.CompareTag("Player"))
            return;
        CharController controller = collision.gameObject.GetComponent<CharController>();

        if (controller && controller.characterIndex == CharController.Character.TEDDY)
        {
            if (simplistic && rigidbody)
            {
                rigidbody.isKinematic = false;
                return;
            }

            playing = true;
            currentTime = 0F;
            initialPosition = transform.localPosition;
            initialRotation = transform.localRotation;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (simplistic && rigidbody && collision.gameObject.CompareTag("Player"))
        {
            CharController controller = collision.gameObject.GetComponent<CharController>();

			if (controller && controller.characterIndex == CharController.Character.TEDDY) 
			{
				rigidbody.isKinematic = true;
			}
        }
    }

    private void Update()
    {
        if (!playing || simplistic)
            return;

        currentTime += Time.deltaTime;

        transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition + targetPositionOffset, currentTime / timeInSeconds);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, initialRotation * Quaternion.Euler(targetRotationOffset), currentTime / timeInSeconds);

        if (currentTime >= timeInSeconds)
            Destroy(this);
    }

    private void OnDrawGizmos()
    {
        if (simplistic)
            return;

        Vector3 pos = transform.localPosition;
        Quaternion rot = transform.localRotation;

        if (playing)
        {
            pos = initialPosition;
            rot = initialRotation;
        }

        if (!fl)
            fl = GetComponent<MeshFilter>();
        if (!fl)
            return;

        Gizmos.color = Color.green;

        if (transform.parent)
            Gizmos.matrix = transform.parent.localToWorldMatrix;

        Gizmos.DrawLine(pos, pos + targetPositionOffset);
        Gizmos.DrawWireMesh(fl.sharedMesh, pos + targetPositionOffset, rot * Quaternion.Euler(targetRotationOffset), transform.localScale);
    }
}
