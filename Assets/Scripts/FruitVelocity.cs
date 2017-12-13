using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitVelocity : MonoBehaviour 
{
	public int variableForceDown;


	void Update()
	{
		gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.down * variableForceDown, ForceMode.Force);
	}

}
