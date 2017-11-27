using UnityEngine;

public class BreakOnHit : ProjectileHandler
{
	public GameObject Hold;

    public override void OnHit()
    {
		Destroy (Hold);
        Destroy(gameObject);
    }
}
