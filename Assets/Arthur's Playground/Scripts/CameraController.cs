using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = .5F;
    private CameraTrigger previousTrigger;

    private void Update()
    {
        CameraTrigger activeTrigger = (from t in CameraTrigger.cache
                                       where t.containsPlayers
                                       orderby t.order descending
                                       select t).FirstOrDefault();

        if (!activeTrigger)
            activeTrigger = previousTrigger;
        else
            previousTrigger = activeTrigger;

        if (!activeTrigger)
            return;

        transform.position = Vector3.Lerp(transform.position, activeTrigger.cameraTransform.position, Time.deltaTime * speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, activeTrigger.cameraTransform.rotation, Time.deltaTime * speed);
    }
}