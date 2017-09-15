using UnityEngine;

// TODO: Test
public class GrappleTrigger : MonoBehaviour
{
    public GameObject origin;
    public GameObject destination;
    public GameObject grappleHook;
    public GameObject lineobj;
    //public GameObject climableCol;

    //public GameObject gnome;
    //public GameObject teddy;
    public GameObject robot;
    //public GameObject doll;


    public bool grappable;
    public bool grappled;

    public float speedUp = 1;

    public LineRenderer line;

    CharController charControllerRobot;
    //CharController charControllerGnome;
    //CharController charControllerTeddy;
    //CharController charControllerDoll;

    void Start()
    {
        line = lineobj.GetComponent<LineRenderer>();
        grappable = false;
        grappled = false;
        charControllerRobot = robot.GetComponent<CharController>();
        //charControllerRobot = robot.GetComponent<CharController>();
        //charControllerGnome = gnome.GetComponent<CharController>();
        //charControllerTeddy = teddy.GetComponent<CharController>();
        //charControllerDoll = doll.GetComponent<CharController>();
    }

    void Update()
    {
        Grappling();
    }

    void Grappling()
    {
        ControlsManager.Controls controls = charControllerRobot.controlsManager.GetControlsForCharacter(charControllerRobot.characterIndex);

        if (charControllerRobot.climbable == true)//(grappled == true)
        {
            print("grappleboolistrue");
            robot.GetComponent<Rigidbody>().useGravity = false;

            //Robot
            if (controls != null && controls.GetAxis(controls.movementAxis).y < 0)
            {
                print("MovingVertically-robot");
                robot.GetComponent<Rigidbody>().useGravity = false;
                robot.transform.Translate(Vector3.up * speedUp);

            }
            else if (controls != null && controls.GetAxis(controls.movementAxis).y > 0)
            {
                robot.transform.Translate(-Vector3.up * speedUp);
            }
        }

        //		if (charController.climbable2 == true)
        //		{
        //			gnome.GetComponent<Rigidbody> ().useGravity = true;
        //			teddy.GetComponent<Rigidbody> ().useGravity = true;
        //			doll.GetComponent<Rigidbody> ().useGravity = true;
        //
        //			//Gnome


        //Teddy
        //			if (Input.GetAxis(charControllerTeddy.yAxis1) < 0) 
        //			{
        //				print ("MovingVertically-teddy");
        //				teddy.GetComponent<Rigidbody> ().useGravity = false;
        //				teddy.transform.Translate (Vector3.up * speedUp);
        //
        //				if (Input.GetKeyDown (KeyCode.Joystick2Button2)) // if individual players 'X' button is pressed
        //				{
        //					charControllerTeddy.climbable2 = false; // turn off the singular characters vertical movement along the line so they can move like normal
        //				}
        //			}
        //			if (Input.GetAxis(charControllerTeddy.yAxis1) > 0)
        //			{
        //				teddy.transform.Translate (-Vector3.up * speedUp);
        //			}

        //Doll


        if (controls != null && controls.GetButtonDown(controls.buttonObjInteract))
        {
            if (grappable == true)
            {
                print("GrapplingOn");
                line.SetPosition(0, origin.transform.position);
                line.SetPosition(1, destination.transform.position);
                //				grappled = true;
                charControllerRobot.climbable = true;
                grappable = false;
                line.enabled = true;
                //line.GetComponent<MeshCollider> (true);

                //climableCol.SetActive (true);
            }
            //			else
            //			{
            //				if (charController.climbable && Input.GetKeyDown (KeyCode.Joystick3Button2)) 
            //				{
            //					print ("GrapplingOff");
            //					robot.GetComponent<Rigidbody> ().useGravity = true;
            //					//grappable = true; 
            //					charController.climbable = false;
            //					line.enabled = false;
            //					//line.GetComponent<MeshCollider> (false);
            //
            //					//climableCol.SetActive (false);
            //				}
            //			}



        }

    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.name == "Robot")
        {
            //Grappling ();
            grappleHook.SetActive(true);
            grappable = true;
        }

        if (charControllerRobot.climbable && collider.CompareTag("Player"))
        {
            CharController controller = collider.GetComponent<CharController>();

            ControlsManager.Controls controls = charControllerRobot.controlsManager.GetControlsForCharacter(controller.characterIndex);

            if (controls != null && controls.GetAxis(controls.movementAxis).y < 0)
            {
                print("MovingVertically-" + collider.name);
                collider.GetComponent<Rigidbody>().useGravity = false;
                collider.transform.Translate(Vector3.up * speedUp);

                if (controls.GetButtonDown(controls.buttonObjInteract)) // if individual players 'X' button is pressed
                {
                    controller.climbable2 = false; // turn off the singular characters vertical movement along the line so they can move like normal
                }
            }
            else if (controls != null && controls.GetAxis(controls.movementAxis).y > 0)
            {
                collider.transform.Translate(-Vector3.up * speedUp);
            }
        }

        //if (charController.climbable && collider.transform.tag == "Player 1")
        //{
        //    ControlsManager.Controls controls = charController.controlsManager.GetControlsForCharacter(charControllerGnome.characterIndex);

        //    charController.climbable = true;
        //    if (controls != null && controls.GetAxis(controls.movementAxis).y < 0)
        //    {
        //        print("MovingVertically-gnome");
        //        gnome.GetComponent<Rigidbody>().useGravity = false;
        //        gnome.transform.Translate(Vector3.up * speedUp);

        //        if (controls.GetButtonDown(controls.buttonObjInteract)) // if individual players 'X' button is pressed
        //        {
        //            charControllerGnome.climbable2 = false; // turn off the singular characters vertical movement along the line so they can move like normal
        //        }
        //    }
        //    else if (controls != null && controls.GetAxis(controls.movementAxis).y > 0)
        //    {
        //        gnome.transform.Translate(-Vector3.up * speedUp);
        //    }

        //}

        //if (charController.climbable && collider.transform.tag == "Player 2")
        //{
        //    ControlsManager.Controls controls = charController.controlsManager.GetControlsForCharacter(charControllerTeddy.characterIndex);

        //    charController.climbable = true;
        //    if (controls != null && controls.GetAxis(controls.movementAxis).y < 0)
        //    {
        //        print("MovingVertically-teddy");
        //        teddy.GetComponent<Rigidbody>().useGravity = false;
        //        teddy.transform.Translate(Vector3.up * speedUp);

        //        if (controls.GetButtonDown(controls.buttonObjInteract)) // if individual players 'X' button is pressed
        //        {
        //            charControllerTeddy.climbable2 = false; // turn off the singular characters vertical movement along the line so they can move like normal
        //        }
        //    }
        //    else if (controls != null && controls.GetAxis(controls.movementAxis).y > 0)
        //    {
        //        teddy.transform.Translate(-Vector3.up * speedUp);
        //    }
        //}

        //if (charController.climbable && collider.transform.tag == "Player 4")
        //{
        //    ControlsManager.Controls controls = charController.controlsManager.GetControlsForCharacter(charControllerDoll.characterIndex);

        //    charController.climbable = true;
        //    if (controls.GetAxis(controls.movementAxis).y < 0)
        //    {
        //        print("MovingVertically-doll");
        //        doll.GetComponent<Rigidbody>().useGravity = false;
        //        doll.transform.Translate(Vector3.up * speedUp);

        //        if (controls.GetButtonDown(controls.buttonObjInteract)) // if individual players 'X' button is pressed
        //        {
        //            charControllerDoll.climbable2 = false; // turn off the singular characters vertical movement along the line so they can move like normal
        //        }
        //    }
        //    if (controls != null && controls.GetAxis(controls.movementAxis).y > 0)
        //    {
        //        doll.transform.Translate(-Vector3.up * speedUp);
        //    }

        //}
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == robot)
        {
            grappleHook.SetActive(false);
            grappable = false;
            charControllerRobot.climbable = false;
            charControllerRobot.GetComponent<Rigidbody>().useGravity = true;

            //grappled = false;
            //charController.climbable = false;
        }

        if (collider.CompareTag("Player"))
        {
            CharController controller = collider.GetComponent<CharController>();

            controller.climbable = false;
            collider.GetComponent<Rigidbody>().useGravity = true;
        }

        //if (collider.transform.tag == "Player 1")
        //{
        //    charControllerGnome.climbable = false;
        //    charControllerGnome.GetComponent<Rigidbody>().useGravity = true;

        //}
        //if (collider.transform.tag == "Player 4")
        //{
        //    charControllerDoll.climbable = false;
        //    charControllerDoll.GetComponent<Rigidbody>().useGravity = true;
        //}
        //if (collider.transform.tag == "Player 2")
        //{
        //    charControllerTeddy.climbable = false;
        //    charControllerTeddy.GetComponent<Rigidbody>().useGravity = true;
        //}
    }
}
