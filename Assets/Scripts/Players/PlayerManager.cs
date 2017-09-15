using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public GameObject[] players;

	public float maxDistance = 10f;

	void Update () {
		ConstrainPlayerDistances ();
	}

	void ConstrainPlayerDistances() {
		Vector3 midpoint = UpdateCameraPosition.Midpoint(players);

		//finding the max distance between any two player
		for (int i = 0; i < players.Length; i++) {
			Vector3 displacement = midpoint - players [i].transform.position;

			// Constrain the displacement so that it never exceeds maxDistance
			if (displacement.magnitude > maxDistance) {
				float exceededAmount = displacement.magnitude - maxDistance;

				players [i].transform.position += exceededAmount * displacement.normalized;
			}
		}
	}
}
