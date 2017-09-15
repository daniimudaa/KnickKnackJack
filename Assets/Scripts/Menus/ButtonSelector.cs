using UnityEngine;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour {
    public Selectable defaultButton;

    private void OnEnable()
    {
        defaultButton.Select();
    }
}
