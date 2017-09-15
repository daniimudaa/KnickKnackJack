using UnityEngine;

public class BreakableCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Axe")
		{
			Destroy (gameObject);
		}
	}
}

