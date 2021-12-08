using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeHandler : MonoBehaviour
{
    public InstanceManagerScriptableObject instance;

    private void Awake()
    {
        PlayerPrefs.SetInt("Floor", 0);
    }
}
