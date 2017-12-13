using System.Collections;
using System.Linq;
using UnityEngine;

public class GrappleShoot : RangedAbility
{
    public TargetRenderer targetRenderer;
    public Material lineMaterial;
    public Material padMaterial;

    private GrappleTarget currentTarget;
    private GameObject grapplePoint;

    public AudioSource RobotGrappleSource;
    public AudioClip RobotGrappleAudio;
	public AudioClip GrappleZoomAudio;
	public AudioSource RobotLoopGrappleSource;

    public GameObject teleporterLine;
    public GameObject teleporterRing;
	public GameObject endTeleporterRing;

	public GameObject gnomeTeleporterLine;
    public GameObject dollTeleporterLine;
    public GameObject teddyTeleporterLine;

    public void start()
    {
        RobotGrappleSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        Collider col = (from c in GetColliders()
                        where c.GetComponent<GrappleTarget>() && c.GetComponent<GrappleTarget>().enabled && Vector3.Angle((c.transform.position - new Vector3(0, c.transform.position.y, 0)) - (transform.position - new Vector3(0, transform.position.y, 0)), transform.forward) <= 45
                        orderby Vector3.Distance(transform.position, c.transform.position)
                        select c).FirstOrDefault();

        targetRenderer.SetActive(!currentTarget && col);

        ControlsManager.Controls controls = Controls;

        if (col && controls != null)
        {
            targetRenderer.SetPosition(col.transform.position);

            bool interactBtn = controls.GetButtonDown(controls.buttonObjInteract);
            bool cancelBtn = controls.GetButtonDown(controls.buttonPlayerInteract);

            if ((interactBtn || (currentTarget && cancelBtn)))
            {
                if (!currentTarget)
                {
                    currentTarget = col.GetComponent<GrappleTarget>();

                    if (currentTarget)
                    {
                        RobotGrappleSource.PlayOneShot(RobotGrappleAudio);
						RobotLoopGrappleSource.Play();
                        controller.movementEnabled = false;
                        teleporterLine.SetActive (true);
                        teleporterRing.SetActive (true);
						endTeleporterRing.SetActive (true);
                        grapplePoint = new GameObject("grapple");
                        Grapple g = grapplePoint.AddComponent<Grapple>();
                        g.target = currentTarget;
                        g.traversalTime = currentTarget.traversalTime;
                        g.source = transform;
                        g.ziplineFx = new GameObject[] { gnomeTeleporterLine, teddyTeleporterLine, dollTeleporterLine };

                        LineRenderer lr = grapplePoint.AddComponent<LineRenderer>();
                        lr.useWorldSpace = true;
                        lr.textureMode = LineTextureMode.Tile;
                        lr.SetPositions(new Vector3[] { transform.position, currentTarget.transform.position, currentTarget.transform.position + currentTarget.offset });
                        lr.material = lineMaterial;

                        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                        plane.transform.SetParent(grapplePoint.transform, false);
                        plane.transform.localScale *= .5F;
                        plane.GetComponent<MeshRenderer>().material = padMaterial;
                    }
                }
                else
                {
                    if (!cancelBtn)
                    {
                        GameObject[] ziplineFx= { teleporterLine };
                        currentTarget.StartCoroutine(Zipline(transform, rigidbody, currentTarget.traversalTime, transform.position, currentTarget.transform.position + currentTarget.offset, ziplineFx));
                    }

                    Destroy(grapplePoint);
                    currentTarget = null;
                    teleporterRing.SetActive (false);
					endTeleporterRing.SetActive (false);
					RobotLoopGrappleSource.Stop();
					gameObject.GetComponent<CharController> ().movementEnabled = true;

                }
            }
        }
    }

    private static IEnumerator Zipline(Transform t, Rigidbody rb, float traversalTime, Vector3 source, Vector3 destination, GameObject[] ziplineFx)
    {
        rb.isKinematic = true;
        t.position = source;

        CharController controller = t.GetComponent<CharController>();
        if (!controller)
            t.GetComponentInParent<CharController>();
        controller.movementEnabled = false;

        float time = 0F;

        do
        {
            time += Time.deltaTime;

            t.position = Vector3.Lerp(source, destination, time / traversalTime);

            yield return null;
        } while (time <= traversalTime);

        rb.isKinematic = false;

        controller.movementEnabled = true;

        foreach (GameObject fx in ziplineFx) {
            fx.SetActive (false);
        }
    }

	private class Grapple : MonoBehaviour
    {
        public GrappleTarget target;
        public Transform source;
        public float traversalTime;
        public GameObject[] ziplineFx;

        private void Start()
        {
            BoxCollider collider = gameObject.AddComponent<BoxCollider>();
            transform.position = source.position;
            collider.isTrigger = true;
            collider.center = Vector3.zero;
            collider.size = Vector3.one * 6F;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                CharController controller = other.GetComponent<CharController>();
                if (!controller)
                    controller = other.GetComponentInParent<CharController>();

                if (controller != null && controller.characterIndex != CharController.Character.ROBOT)
                {
                    ControlsManager.Controls controls = controller.controlsManager.GetControlsForCharacter(controller.characterIndex);

                    if (controls != null && controls.GetButtonDown(controls.buttonObjInteract))
                    {
                        Rigidbody rb = controller.GetComponent<Rigidbody>();


						//trying to make the particle effect on each player as they press to go up the teleporter turn on while teleporting and then turn off once theyve landed at the point
						//my attempt but it says i cant use a non-static refrernce here so comes up as null in the console
						//referencing from the class above
						//the object particles are on each player named as "TeleporterLine"
						//also trying to play audio piece but its not static

//						RobotGrappleSource.PlayOneShot(GrappleZoomAudio);

                        foreach (GameObject fx in ziplineFx) {
                            fx.SetActive (true);
                        }

                        if (!rb.isKinematic)
                            target.StartCoroutine(Zipline(controller.transform, rb, traversalTime, controller.transform.position, target.transform.position + target.offset, ziplineFx));
					}
                }
            }
        }
    }
}
