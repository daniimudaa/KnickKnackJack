using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyPush : MonoBehaviour 
{
	void Update ()
	{
		//gameObject.GetComponent<Rigidbody> ().isKinematic = false;
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "collider" || col.gameObject.name == "Teddy") 
		{
			print ("TEDDDDDDDYYYYYYYYY");
			gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		}

		if (col.gameObject.name == "Robot") 
		{
			print ("ROBOOOOOOOOT");
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		}

		if (col.gameObject.name == "Doll") 
		{
			print ("DOOOOOOOOOOOOOOOOOOLL");
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		}

		if (col.gameObject.name == "Gnome") 
		{
			print ("GNOMMMMMMMMMMEE");
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		}
	}

	void OnCollisionExit (Collision coll)
	{
		if (coll.transform.tag == "Player") 
		{
			gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		}
	}
}
