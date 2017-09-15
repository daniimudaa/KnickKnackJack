using System.Linq;
using UnityEngine;

public class ProjectileShooter : RangedAbility
{
	

    [Header("Projectile Shooter")]
    public GameObject template;
    public float speed = 2F;
    public Vector3 projectileOffset = Vector3.zero;

    [Space]
    public TargetRenderer targetRenderer;

    private GameObject activeProjectile;

	public AudioSource RobotShootSource;
	public AudioClip RobotShootAudio;


	public void start ()
	{
		RobotShootSource = GetComponent<AudioSource> ();
	}

    private void Update()
    {
        Collider col = (from c in GetColliders()
                        where c.CompareTag("shootable") && Vector3.Angle((c.transform.position - new Vector3(0, c.transform.position.y, 0)) - (transform.position - new Vector3(0, transform.position.y, 0)), transform.forward) <= 45
                        orderby Vector3.Distance(transform.position, c.transform.position)
                        select c).FirstOrDefault();

        targetRenderer.SetActive(!activeProjectile && col);

        if (col)
        {
            targetRenderer.SetPosition(col.transform.position);

            ControlsManager.Controls controls = Controls;

            if (!activeProjectile && controls != null && controls.GetButtonDown(controls.buttonAbility1))
            {
				RobotShootSource.PlayOneShot (RobotShootAudio);
                GameObject projectile = Instantiate(template);
                projectile.transform.position = transform.position + projectileOffset;
                Projectile proj = projectile.AddComponent<Projectile>();
                proj.target = col.transform;
                proj.speed = speed;
                proj.onHit = new UnityEngine.Events.UnityEvent();

                ProjectileHandler[] hand = col.GetComponentsInChildren<ProjectileHandler>();
                foreach (ProjectileHandler handler in hand)
                    proj.onHit.AddListener(handler.OnHit);

                proj.onHit.AddListener(() => print("Target hit"));

                activeProjectile = projectile;
            }
        }
    }
}
