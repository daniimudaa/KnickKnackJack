using UnityEngine;

public class RangedAbility : CharacterAbility
{
    [Header("Ranged Ability")]
    public Vector3 rangeOffset = Vector3.zero;
    public Vector3 range = Vector3.one;

    protected Collider[] GetColliders()
    {
        // Project a box of specified range around us and return all colliders within it
        return Physics.OverlapBox(transform.position + rangeOffset, range / 2, transform.rotation);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position + rangeOffset, range);
    }
}
