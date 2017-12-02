using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationBedroom : MonoBehaviour 
{
	public Animation anim;
	public Animation anim2;



	void OnTriggerEnter (Collider coll)
	{

		if (coll.transform.tag == "JackInBox") 
		{
			anim.Play();
			anim2.Play ();
		}
	}
}
