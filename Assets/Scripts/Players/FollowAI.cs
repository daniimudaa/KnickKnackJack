using System.Linq;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    public float maxDistance = 10F;
    public float teleportDistance = 50F;
    public float speedMultiplier = 2F;

    [Header("Order")]
    public CharController.Character follow;

    private CharController controller;
    private CharController other;

    private FollowAI otherAI;

    private bool isAIDisableArea = false;

    private void Awake()
    {
        controller = GetComponent<CharController>();
        other = FindObjectsOfType<CharController>().Where(c => c.characterIndex == follow).OrderBy(c => c.characterIndex).FirstOrDefault();
        otherAI = other.GetComponent<FollowAI>();
    }

    private void Update()
    {
        if (controller.controlsManager.GetControlsForCharacter(controller.characterIndex) != null)
            return;

        // Reset the current speed
        controller.currentSpeed = 0F;

        if ((isAIDisableArea && (!otherAI || otherAI.isAIDisableArea)) || !controller.movementEnabled)
            return;

        // If other exists and we are sufficiently far from them
        if (other && Vector3.Distance(transform.position, other.transform.position) > maxDistance)
        {
            if (!other.isGrounded)
                return;

            Vector3 op = other.transform.position;
            // Calculate our direction to them
            Vector3 dir = (new Vector3(op.x, transform.position.y, op.z) - transform.position).normalized;

            // Look at them
            transform.LookAt(new Vector3(op.x, transform.position.y, op.z));

            // If we are sufficiently far from them to teleport
            if (Vector3.Distance(transform.position, other.transform.position) > teleportDistance)
            {
                // Teleport to them
                transform.position = new Vector3(op.x + .5F, op.y, op.z + .5F);
                return;
            }

            // Move towards them in world space
            transform.Translate(dir * controller.speed * Time.deltaTime * speedMultiplier, Space.World);
            // Set the current speed for the animator
            controller.currentSpeed = dir.magnitude * controller.speed;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("NoAI"))
            isAIDisableArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NoAI"))
            isAIDisableArea = false;
    }
}
