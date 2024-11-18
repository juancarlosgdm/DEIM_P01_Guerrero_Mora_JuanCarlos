using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using SceneManagerUnity = UnityEngine.SceneManagement.SceneManager;

namespace GestionEscenas
{

    public class SceneManager : MonoBehaviour
    {
        public static SceneManager instance;

        [SerializeField] private CanvasGroup fade;

        [SerializeField] private float fadeDuration;

        private bool isLoadingScene;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        public static void LoadScene(string sceneName)
        {
            if (!instance.isLoadingScene)
            {
                instance.StartCoroutine(instance.LoadSceneCoroutine(sceneName));
            }
        }

        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            isLoadingScene = true;
            Time.timeScale = 0;

            Tween fadeTween = fade.DOFade(1, fadeDuration).SetEase(Ease.Linear);
            fadeTween.timeScale = 1;
            yield return fadeTween.WaitForCompletion();

            AsyncOperation loadOp = SceneManagerUnity.LoadSceneAsync(sceneName);
            while (!loadOp.isDone)
            {
                yield return null;
            }

            instance.fade.DOFade(0, fadeDuration).SetEase(Ease.Linear);

            isLoadingScene = false;
        }
    }

}
