using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingClothes : MonoBehaviour 
{
	void OnTriggerEnter (Collider col)
	{
		if (col.transform.tag == "Player") 
		{
			gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		}
	}

}
