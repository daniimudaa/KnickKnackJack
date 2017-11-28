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
			print ("Doll found");
            CharController controller = col.GetComponent<CharController>();
            ControlsManager.Controls controls = controller.controlsManager.GetControlsForCharacter(controller.characterIndex);

            if (controls != null && controls.GetButton(controls.buttonObjInteract))
            {
				print ("trying to play animation");
                dropCube.GetComponent<Rigidbody>().isKinematic = false;
				print ("Fake drop cube");
				bedroomAnim.Play ();
				print ("Animation PLAYED");
            }
        }

		if (col.transform.tag == "PressureWeight")
		{
			dropCube.SetActive (true);
			dropCube.GetComponent<Rigidbody>().isKinematic = false;
		}
    }
}
