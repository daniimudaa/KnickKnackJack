using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public AudioClip teddyBouceAudio;

    public LayDown bounce;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharController controller = collision.gameObject.GetComponent<CharController>();
            ControlsManager.Controls controls = controller.controlsManager.GetControlsForCharacter(controller.characterIndex);

            if (controls != null && controls.GetButtonDown(controls.buttonJump) && controller.isGrounded)
            {
                AudioSource.PlayClipAtPoint(teddyBouceAudio, transform.position);
                controller.isGrounded = false;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounce.bounceHeight, ForceMode.VelocityChange);
            }
        }
    }
}
