using UnityEngine;

public class UpdateCameraPosition : MonoBehaviour 
{
	public GameObject[] players;
	public float rate = 0.2f;

	void Update () 
	{
		SetCameraPosition ();
	}

	void SetCameraPosition() 
	{
		Vector3 midpoint = Midpoint(players);

		Vector3 currentVelocity = new Vector3();
		transform.position = Vector3.SmoothDamp (transform.position, midpoint, ref currentVelocity, rate);
	}

	public static Vector3 Midpoint(GameObject[] gameObjects) 
	{
		Vector3 midpoint = new Vector3 ();

		//find position of each player and find the middle point/average of each player
		for (int i = 0; i < gameObjects.Length; i++) 
		{
			midpoint += gameObjects [i].transform.position;
		}

		midpoint /= gameObjects.Length;

		return midpoint;
	}
}
