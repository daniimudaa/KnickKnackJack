using UnityEngine;

public class UpdateCameraDolly : MonoBehaviour 
{

	public GameObject[] players;

	//value
	public float maxDistance = 10f;

	//min distance for zoom
	public float minDolly =  50f;

	//min distance for zoom
	public float maxDolly = 200f;

	void Update () 
	{
		setCameraDolly ();
	}

	void setCameraDolly () 
	{
		float currentMaxDistance = 0f;

		//finding the max distance between any two player
		for (int i = 0; i < players.Length; i++) 
		{
			for (int j = 0; j < players.Length; j++) 
			{
				Vector3 displacement = players [i].transform.position - players [j].transform.position;

				currentMaxDistance = Mathf.Max (currentMaxDistance, displacement.magnitude);
			}
		}

		//clamping the min and max distance the dolly can zoom 
		float value = Mathf.Clamp01 (Mathf.InverseLerp (0f, maxDistance, currentMaxDistance));

		//
		float dolly = Mathf.Lerp (minDolly, maxDolly, value);

		//moving the zoom from local positions on the z axis (negative numbers)
		transform.localPosition = new Vector3 (0f, 0f, -dolly);
	}
}
