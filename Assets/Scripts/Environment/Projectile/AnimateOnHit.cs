using UnityEngine;

public class AnimateOnHit : ProjectileHandler
{
    public Animation anim;

    public override void OnHit()
    {
        anim.Play();
    }
}
