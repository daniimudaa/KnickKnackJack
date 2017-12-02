using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttackTrig : MonoBehaviour 
{
	bool collided;
	public GameObject catPaw;
	public GameObject catPawPosition;

	IEnumerator OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Player") 
		{
			collided = true;
			yield return new WaitForSeconds(5); //change for time waiting attack 
			if (collided) 
			{
				//print ("I AM AMAZING"); //testing to see if code works

				GameObject clone = Instantiate(catPaw, catPawPosition.transform.position, Quaternion.identity);
				//animation.Play("CatAttack");
				collided = false;

				//yield return new WaitForSeconds(5);
				Destroy(clone, 4.0f);
			}
		}
	}

	void OnCollisionExit () 
	{
		collided = false;
	}
}
