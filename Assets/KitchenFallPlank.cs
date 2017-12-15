using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenFallPlank : MonoBehaviour 

{

	void OnTriggerStay (Collider col)
	{
		if (col.transform.tag == "Blocked") 
		{
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		} else 
		{
			gameObject.GetComponent<Rigidbody> ().isKinematic = false;

		}
	}
}
