using UnityEngine;

public class AnimateOnHit : ProjectileHandler
{
    public Animation anim;
	public GameObject fruit;

    public override void OnHit()
    {
        anim.Play();
		fruit.GetComponent<Rigidbody> ().isKinematic = true;
		fruit.GetComponent<Rigidbody> ().isKinematic = false;
    }
}
