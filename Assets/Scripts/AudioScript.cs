using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Music starts at " + SceneChanger.time);
        audioSource.time = SceneChanger.time;
        audioSource.Play();
    }
}
