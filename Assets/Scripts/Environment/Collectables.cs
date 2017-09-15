using UnityEngine;

public class Collectables : MonoBehaviour
{
    public string id;

    public GameObject blockedBy;

    private void Awake()
    {
        if (CollectableManager.collected.Contains(id))
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

            if (!CollectableManager.collected.Contains(id))
                CollectableManager.collected.Add(id);
            Destroy(gameObject);
        }
    }
}
