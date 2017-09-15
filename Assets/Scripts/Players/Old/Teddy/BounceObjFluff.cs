using UnityEngine;

public class BounceObjFluff : MonoBehaviour 
{
	public float bounceforce = 2;
	//public GameObject teddy;


	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	void OnTriggerStay (Collider other)
	{
		print ("ontriggerwithplayer2andselfie");

		if (other.gameObject.tag == "Player 2") 
		{
			print ("shootingplayerup");

			other.GetComponentInParent<Rigidbody> ().AddForce (0f, 200f, 0f, ForceMode.Acceleration);
		}
	}
}
