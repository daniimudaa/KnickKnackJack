using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Collectables : MonoBehaviour
{
	public CollectableManager.Level level;

    public string id;

    public GameObject blockedBy;

	public GameObject colectParticle;

	public AudioSource source;
	public AudioClip collectSound;

	public GameObject child;

    private void Awake()
    {
		if (CollectableManager.GetCollectable(level).Contains(id))
            Destroy(gameObject);
    }

	private IEnumerator OnTriggerEnter(Collider col)
    {
        if (blockedBy)
			yield return null;

        if (col.CompareTag("Player"))
        {
			
			source.PlayOneShot (collectSound);
			GameObject clone = Instantiate(colectParticle, gameObject.transform.position, Quaternion.identity);

			if (!CollectableManager.GetCollectable(level).Contains(id))
				CollectableManager.GetCollectable(level).Add(id);

			child.SetActive (false);
			yield return new WaitForSeconds(1.5f);
			Destroy(clone);
			Destroy(gameObject);
        }
    }
}
