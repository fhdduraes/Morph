using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenuButtonController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI loadingText;

        private void Start() => loadingText.SetText(string.Empty);

        public void MainMenu() => StartCoroutine(LoadScene(0));

        public void NewGame() => StartCoroutine(LoadScene(2));

        public void TranslationMenu() => StartCoroutine(LoadScene(1));

        private IEnumerator LoadScene(int sceneIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                loadingText.SetText($"LOADING: { Mathf.FloorToInt(progress * 100f) }%");

                yield return null;
            }
        }
    }
}