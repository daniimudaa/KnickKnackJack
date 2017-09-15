using UnityEngine;

public class CamExploring : MonoBehaviour 
{
	public GameObject cameraPitch;

	PitchController script;


	// Use this for initialization
	void Start () 
	{
		script = cameraPitch.GetComponent<PitchController> ();
	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter (Collider col)
	{
		if (col.transform.tag == "Player")
		{
			script.isPitchExploring = true;
			cameraPitch.SendMessage ("SetPitchExploring");
		}

	}

		void OnTriggerExit (Collider col)
		{
		if (col.tag == "Player") 
			{
			
			script.isPitchExploring = false; 
			//cameraPitch.SendMessage ("isPitchExploring = false");
				//cameraPitch.SendMessage ("isPitchExploring = false");
			}
		}
}
