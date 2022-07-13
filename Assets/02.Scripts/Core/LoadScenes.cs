using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScenes : MonoBehaviour
{
    public void LoadScene(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void FirstStart()
    {
        GameManager.IsFirst = true;
        SceneManager.LoadScene("GameScene");
    }

    public void QuitScene()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
