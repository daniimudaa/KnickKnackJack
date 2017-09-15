using UnityEngine;

public abstract class CharacterAbility : MonoBehaviour
{
    protected CharController controller;
    protected Animator animator;
    protected new Rigidbody rigidbody;

    protected ControlsManager.Controls Controls
    {
        get
        {
            return controller.controlsManager.GetControlsForCharacter(controller.characterIndex);
        }
    }

    protected virtual void Awake()
    {
        controller = GetComponent<CharController>();
        if (!controller)
            GetComponentInParent<CharController>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
}
