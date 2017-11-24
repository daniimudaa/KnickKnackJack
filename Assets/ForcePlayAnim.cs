using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlayAnim : MonoBehaviour
{
	public Animation anim;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			anim.Play ();
		}
	}
}
