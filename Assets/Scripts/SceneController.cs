using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    private static Scene loaderScene;
    private static GameObject loader;

    public static void LoadScene(string scene)
    {
        loaderScene = SceneManager.CreateScene("Runtime/Loader");

        for (int i = 0; i < SceneManager.sceneCount; i++)
            if (SceneManager.GetSceneAt(i) != loaderScene)
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i));

        GameObject loaderTemplate = Resources.Load<GameObject>("LoadingScreen");
        Updater upd = null;

        if (loaderTemplate)
        {
            loader = Object.Instantiate(loaderTemplate);
            upd = loader.AddComponent<Updater>();
        }

        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        if (upd)
        {
            upd.operation = async;
        }
    }

    private class Updater : MonoBehaviour
    {
        public AsyncOperation operation;

        private RectTransform bar;
        private float barMaxSize;

        private void Awake()
        {
            RectTransform barParent = transform.Find("LoadingBar").GetComponent<RectTransform>();
            bar = barParent.Find("LoadedBar").GetComponent<RectTransform>();
            barMaxSize = barParent.sizeDelta.x;

            bar.sizeDelta = new Vector2(10F, bar.sizeDelta.y);
        }

        private void Update()
        {
            bar.sizeDelta = new Vector2(operation.progress * barMaxSize, bar.sizeDelta.y);
        }
    }
}
