using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector3 spin;

    public bool destroyOnHit = true;

    public UnityEvent onHit;

    private Vector3 currentSpin;

    private void Awake()
    {
        if (!gameObject.GetComponent<BoxCollider>())
            gameObject.AddComponent<BoxCollider>().isTrigger = true;
        if (!gameObject.GetComponent<Rigidbody>())
            gameObject.AddComponent<Rigidbody>().isKinematic = true;
    }

    private void Update()
    {
        if (!target)
        {
            Destroy(gameObject);
            return;
        }

        transform.LookAt(target);

        Vector3 dir = (target.position - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
        transform.Rotate(currentSpin += spin * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!target)
            return;

        if (other.transform == target)
        {
            if (onHit != null)
                onHit.Invoke();
            if (destroyOnHit)
                Destroy(gameObject);
        }
    }
}
