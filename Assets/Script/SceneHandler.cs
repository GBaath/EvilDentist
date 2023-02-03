using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void SetScene(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
