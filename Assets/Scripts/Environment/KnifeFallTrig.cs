using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeFallTrig : MonoBehaviour 
{
	public GameObject knife;

	void OnTriggerEnter (Collider col)
	{
		if (col.transform.tag == "Player") 
		{
			knife.GetComponent<Rigidbody> ().isKinematic = false;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.transform.tag == "Knife") 
		{
			knife.GetComponent<Rigidbody> ().isKinematic = true;
		}
	}
}
