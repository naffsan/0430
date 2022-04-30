using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void MoveTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void MoveTo(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
