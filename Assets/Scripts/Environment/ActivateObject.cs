using UnityEngine;

public class ActivateObject : MonoBehaviour
{

    public GameObject dropCube;
    public GameObject doll;
	public Animation bedroomAnim;

    void Start()
    {
        //dropCube.GetComponent<Rigidbody> ().isKinematic = false;
    }

    void Update()
    {

    }

    void OnTriggerStay(Collider col)
    {
        if (col.transform.tag == "Player" && col.gameObject.GetComponent<CharController>().characterIndex == CharController.Character.DOLL)
        {
			
            CharController controller = col.GetComponent<CharController>();
            ControlsManager.Controls controls = controller.controlsManager.GetControlsForCharacter(controller.characterIndex);

            if (controls != null && controls.GetButton(controls.buttonObjInteract))
            {
				
                dropCube.GetComponent<Rigidbody>().isKinematic = false;
				bedroomAnim.Play ();
            }
        }

		if (col.transform.tag == "PressureWeight")
		{
			dropCube.SetActive (true);
			dropCube.GetComponent<Rigidbody>().isKinematic = false;
		}
    }
}
