using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public AudioSource audioSource;
    public static float time = 0.0f;

    public void ChangeScene(string sceneName)
    {
        Debug.Log(audioSource.time);
        time = audioSource.time;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
