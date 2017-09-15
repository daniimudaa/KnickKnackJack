using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool torchIsOn = false;

    public GameObject torchObj;
    //public GameObject robot;

    private CharController controller;

    private void Awake()
    {
        controller = GetComponent<CharController>();
    }

    void Update()
    {
        ControlsManager.Controls controls = controller.controlsManager.GetControlsForCharacter(controller.characterIndex);

        // RT toggles the torch
        if (controls != null && controls.GetButtonDown(controls.buttonAbility1))
        {
            print("torch is " + (torchObj.activeInHierarchy ? "off" : "on"));
            torchObj.SetActive(!torchObj.activeInHierarchy);
        }

        // RT turns torch on and LT turns torch off
        /*if (controls != null && controls.GetButtonDown(controls.buttonAbility1))
        {
            print("torch is on");
            torchObj.SetActive(true);
        }
        if (controls != null && controls.GetButtonDown(controls.buttonAbility2))
        {
            print("torch is off");
            torchObj.SetActive(false);
        }*/


        //		if (GamepadInput.GamePad.GetState (GamepadInput.GamePad.Index.Any).RightShoulder) 
        //			{
        //				print ("torch is on");
        //				torchObj.SetActive (true);
        //			}
        //
        //		if (GamepadInput.GamePad.GetState (GamepadInput.GamePad.Index.Any).LeftShoulder) 				
        //			{
        //				print ("torch is on");
        //				torchObj.SetActive (false);
        //			}

    }
}
