public class BreakOnHit : ProjectileHandler
{
    public override void OnHit()
    {
        Destroy(gameObject);
    }
}
