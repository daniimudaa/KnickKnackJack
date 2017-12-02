using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoungeAnim : MonoBehaviour 
{
	public Animation anim;
	public GameObject AnimTrigger;



	void OnTriggerEnter (Collider col)
	{
		if (col.transform.tag == "Animation") 
		{
			anim.Play ();
			Destroy (gameObject.GetComponent<TeddyPush> ());
			//gameObject.GetComponent<TeddyPush> ().enabled = false;
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			Destroy (AnimTrigger);
		}
	}


}
