using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableCube : MonoBehaviour 
{
	public GameObject explosionParticle;

	IEnumerator OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Axe")
		{
			GameObject clone = Instantiate(explosionParticle, gameObject.transform.position, Quaternion.identity);
			yield return new WaitForSeconds(0.1f);
			Destroy (gameObject);
			yield return new WaitForSeconds(5);

			Destroy(clone, 4.0f);
		}
	}
}

