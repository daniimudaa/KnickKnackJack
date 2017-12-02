using GamepadInput;
using UnityEngine;

public class Continue : MonoBehaviour
{
    public string sceneName;
    public string alternateScene;

    public GamePad.Button continueButton = GamePad.Button.A;

    private void Update()
    {
        if (GamePad.GetButtonDown(continueButton, GamePad.Index.Any))
        {
            if (!string.IsNullOrEmpty(alternateScene) && CollectableManager.Count >= CollectableManager.totalCollectibles)
                SceneController.LoadScene(alternateScene);
            else if (!string.IsNullOrEmpty(sceneName))
                SceneController.LoadScene(sceneName);
        }
    }
}

