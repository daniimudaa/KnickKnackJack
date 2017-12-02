using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
	public CollectableManager.Level level;

    public string id;

    public GameObject blockedBy;

    private void Awake()
    {
		if (CollectableManager.GetCollectable(level).Contains(id))
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (blockedBy)
            return;

        if (col.CompareTag("Player"))
        {
            //play audio sound
            //play particle effect

			if (!CollectableManager.GetCollectable(level).Contains(id))
				CollectableManager.GetCollectable(level).Add(id);
            Destroy(gameObject);
        }
    }
}
