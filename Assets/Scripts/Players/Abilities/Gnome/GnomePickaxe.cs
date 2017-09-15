using System.Collections;
using UnityEngine;

public class GnomePickaxe : CharacterAbility
{
    public GameObject pickaxe;

    private void Start()
    {
        pickaxe.SetActive(false);
    }

    private void Update()
    {
        ControlsManager.Controls controls = controller.controlsManager.GetControlsForCharacter(controller.characterIndex);

        if (controls != null && controls.GetButtonDown(controls.buttonAbility1))
        {
            print("gnome attacking");
            animator.SetTrigger("PickaxeAttack");
            StartCoroutine(ShowPickaxe());
        }
    }

    private IEnumerator ShowPickaxe()
    {
        pickaxe.SetActive(true);
        yield return new WaitForSeconds(1.2F);
        pickaxe.SetActive(false);
    }
}
