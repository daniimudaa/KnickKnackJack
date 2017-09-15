using UnityEngine;

public class CamTrigger : MonoBehaviour 
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
			cameraPitch.SendMessage ("SetPitchLow");
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.tag == "Player") 
		{
			cameraPitch.SendMessage ("SetPitchHigh");
		}
	}
}
