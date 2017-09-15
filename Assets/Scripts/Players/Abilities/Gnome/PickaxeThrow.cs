using System.Linq;
using UnityEngine;

public class PickaxeThrow : RangedAbility
{
    [Header("Pickaxe Throw")]
    public GameObject template;
    public float speed;
    public Vector3 projectileOffset;
    public Vector3 rotationSpeed;

    [Space]
    public TargetRenderer targetRenderer;

    private GameObject activeProjectile;

    private void Update()
    {
        Collider col = (from c in GetColliders()
                        where c.GetComponent<PickaxePoint>() && c.GetComponent<PickaxePoint>().enabled && Vector3.Angle((c.transform.position - new Vector3(0, c.transform.position.y, 0)) - (transform.position - new Vector3(0, transform.position.y, 0)), transform.forward) <= 45
                        orderby Vector3.Distance(transform.position, c.transform.position)
                        select c).FirstOrDefault();

        targetRenderer.SetActive(col);

        if (col)
        {
            targetRenderer.SetPosition(col.transform.position);

            ControlsManager.Controls controls = Controls;

            if (controls != null && controls.GetButtonDown(controls.buttonAbility2))
            {
                animator.SetTrigger("PickaxeAttack");

                PickaxePoint pp = col.GetComponent<PickaxePoint>();
                pp.enabled = false;

                GameObject projectile = Instantiate(template);
                projectile.transform.position = transform.position + projectileOffset;
                Projectile proj = projectile.AddComponent<Projectile>();
                proj.target = col.transform;
                proj.speed = speed;
                proj.spin = rotationSpeed;
                proj.destroyOnHit = false;
                proj.onHit = new UnityEngine.Events.UnityEvent();

                activeProjectile = projectile;

                proj.onHit.AddListener(() =>
                {
                    print("Pickaxe hit");
                    pp.grapple.enabled = true;
                    Destroy(pp);
                    Destroy(proj);
                });
            }
        }
    }
}
