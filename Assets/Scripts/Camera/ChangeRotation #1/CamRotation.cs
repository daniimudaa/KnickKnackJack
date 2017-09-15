using UnityEngine;

public class CamRotation : MonoBehaviour 
{

	public GameObject cameraPitch;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Player")
		{
			cameraPitch.SendMessage ("SetPitchRotating");
		}
	}

	void OntriggerStay (Collider coll)
	{
		cameraPitch.SendMessage ("SetPitchRotatingStop");
	}

	void OnTriggerExit (Collider col)
	{
		if (col.tag == "Player") 
		{
				cameraPitch.SendMessage ("SetPitchRotatingStop");
		}
	}
}
