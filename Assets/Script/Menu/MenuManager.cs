using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadIndexScene(int _indexScene)
    {
        SceneManager.LoadScene(_indexScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
