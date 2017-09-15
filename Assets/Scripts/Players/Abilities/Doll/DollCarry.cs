using System.Collections;
using System.Linq;
using UnityEngine;

public class DollCarry : RangedAbility
{
    [Header("Doll Carry")]
    public Transform armTransform;
    public Vector3 objectOffset = Vector3.zero;

    private GameObject carrying;
    private Collider carryCol;
    private bool watching = false;

    private void Update()
    {
        if (carrying)
            carrying.transform.rotation = transform.rotation;

        if (watching)
            return;

        ControlsManager.Controls controls = Controls;

        if (controls != null && controls.GetButtonDown(controls.buttonAbility1))
        {
            if (carrying)
            {
                animator.SetBool("isLifting", false);
                StartCoroutine(AnimatorWatcher(true));
            }
            else
            {
                // try to find a carryable object within range
                carryCol = (from c in GetColliders()
                            where c.CompareTag("carryable")
                            orderby Vector3.Distance(transform.position, c.transform.position)
                            select c).FirstOrDefault();

                if (carryCol)
                {
                    GameObject carryable = carryCol.gameObject;
                    carrying = carryable;
                    carryable.transform.SetParent(armTransform);

                    carryCol.enabled = false;

                    carrying.transform.localPosition = objectOffset;
                    carrying.transform.rotation = transform.rotation;

                    animator.SetBool("isLifting", true);
                    animator.SetBool("spin", false);
                    StartCoroutine(AnimatorWatcher(false));
                }
            }
        }
    }

    private IEnumerator AnimatorWatcher(bool disown)
    {
        watching = true;
        controller.movementEnabled = false;
        // Wait until we enter pickup/drop state (otherwise the next statement immediately passes as true)
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Anim")).IsName("DollDrop") || animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Anim")).IsName("DollLift"));
        // Wait until we exit said state
        yield return new WaitUntil(() => !animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Anim")).IsName("DollDrop") && !animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Anim")).IsName("DollLift"));

        if (disown)
        {
            carrying.transform.SetParent(null);

            carryCol.enabled = true;

            // Project downwards and upwards trying to find ground nearby, if found, snap to it.
            RaycastHit hit;
            if (Physics.Raycast(new Ray(carryCol.bounds.center + Vector3.down * carryCol.bounds.extents.y, Vector3.down), out hit, 4F, ~(1 << 8)))
                carrying.transform.Translate(new Vector3(0F, -hit.distance, 0F), Space.World);
            else if (Physics.Raycast(new Ray(carryCol.bounds.center + Vector3.up * carryCol.bounds.extents.y, Vector3.up), out hit, 4F, ~(1 << 8)))
                carrying.transform.Translate(new Vector3(0F, hit.distance, 0F), Space.World);

            carrying = null;
            carryCol = null;
        }

        watching = false;
        controller.movementEnabled = true;
    }
}
