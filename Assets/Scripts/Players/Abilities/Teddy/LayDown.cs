using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayDown : CharacterAbility 
{
    public GameObject jumpBox;

    public float bounceHeight;

    private void Update()
    {
        ControlsManager.Controls controls = Controls;

        if(controls != null && controls.GetButtonDown(controls.buttonAbility1))
        {
            bool gettingUp = animator.GetBool("teddyLay");

            rigidbody.isKinematic = !gettingUp;

            animator.SetBool("teddyLay", !gettingUp);
            animator.SetBool("teddyGettingup", gettingUp);
            controller.movementEnabled = gettingUp;

            jumpBox.SetActive(!gettingUp);
        }
    }
}
