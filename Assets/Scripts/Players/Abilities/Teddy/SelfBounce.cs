using System.Collections;
using UnityEngine;

public class SelfBounce : CharacterAbility
{
    public float bounceHeight = 50F;
    public float statePercentage = .75F;

    public AudioClip teddyBouceAudio;
	public AudioSource audioSource;

    private bool jumpLocked = false;

    private void Update()
    {
        if (jumpLocked)
            return;

        ControlsManager.Controls controls = Controls;

        if (controls != null && controls.GetButtonDown(controls.buttonAbility2) && controller.isGrounded)
        {
            animator.SetTrigger("selfBounce");
            StartCoroutine(Bounce());
        }
    }

    private IEnumerator Bounce()
    {
        jumpLocked = true;
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("BellyFlop"));
        yield return new WaitUntil(() =>
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

            return info.normalizedTime >= statePercentage;
        });

		audioSource.PlayOneShot (teddyBouceAudio);
        rigidbody.AddForce(Vector3.up * bounceHeight, ForceMode.VelocityChange);
        jumpLocked = false;
    }
}
