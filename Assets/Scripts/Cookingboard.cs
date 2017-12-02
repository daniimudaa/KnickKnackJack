using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookingboard : MonoBehaviour 
{
	public Animation CookingboardAnim;
	public Animation PlayerJump;
	public GameObject fruit;

	void Start ()
	{
		
	}

	IEnumerator OnCollisionEnter (Collision col)
	{
		if (col.gameObject.CompareTag("FruitBall"))
		{
			CookingboardAnim.Play();
			PlayerJump.Play();
			Destroy (fruit);
		}

		yield return null;
	}
}
