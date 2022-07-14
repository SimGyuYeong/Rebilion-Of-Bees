using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScenes : MonoBehaviour
{
    public GameObject loadPanel;
    public GameObject buttonPanel;
    public Image progressBar;

    public void LoadScene(string str)
    {
        StartCoroutine(LoadSceneCoroutine(str));
    }

    public void FirstStart()
    {
        GameManager.IsFirst = true;
        LoadScene("GameScene");
    }

    public void QuitScene()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        buttonPanel.SetActive(false);
        loadPanel.SetActive(true);
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        float timer = 0f;
        while(!op.isDone)
        {
            yield return null;

            Debug.Log(op.progress);
            if(op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(progressBar.fillAmount == 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
