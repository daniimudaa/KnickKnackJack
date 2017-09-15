using System;
using UnityEngine;

[RequireComponent(typeof(GrappleTarget))]
public class PickaxePoint : MonoBehaviour {
    [NonSerialized]
    public GrappleTarget grapple;

    private void Awake()
    {
        grapple = GetComponent<GrappleTarget>();
        grapple.enabled = false;
    }
}
