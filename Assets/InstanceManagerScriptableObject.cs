using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "ScriptableObjects/InstanceManagerScriptableObject", order = 1)]
public class InstanceManagerScriptableObject : ScriptableObject
{
    public int floorValue;

    public void Start()
    {
        floorValue = 0;
    }

    public void AddFloor()
    {
        floorValue++;
    }
}
