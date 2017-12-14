using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DollHover : CharacterAbility
{

    public float hoverTime = 4F;

	public GameObject hair;

    private bool Hovering
    {
        get
        {
            return isHovering;
        }
        set
        {
            isHovering = value;
            currentHover = 0F;
            rigidbody.useGravity = !value;
            animator.SetBool("spin", value);
        }
    }
    private bool isHovering = false;
    private float currentHover = 0F;

    private void Update()
    {
        if (!controller.movementEnabled)
            return;

        ControlsManager.Controls controls = Controls;

        if (controller.isGrounded || (Hovering && currentHover >= hoverTime))
            Hovering = false;
        else if (Hovering)
            currentHover += Time.deltaTime;
        else if (controls != null && controls.GetButtonDown(controls.buttonJump))
            Hovering = true;

        if (controls == null || !controls.GetButton(controls.buttonJump))
            Hovering = false;
    
		if (Hovering) 
		{
			hair.SetActive (true);
		}


		StartCoroutine (Hair ());
	}

	private IEnumerator Hair() 
	{
		if (!Hovering) 
		{
			yield return new WaitForSeconds(1f);
			hair.SetActive (false);
		}
	}
		
}
