using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    public GameObject LoadImage;

    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitScene()
    {
        Application.Quit();
    }

    public void LoadSceneLoad(string level)
    {
        LoadImage.SetActive(true);
        SceneManager.LoadScene(level);
    }


}

