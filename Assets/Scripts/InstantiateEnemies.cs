using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    GameObject obj;
    Object prefabs;

    // Start is called before the first frame update
    void Start()
    {
        prefabs = Resources.Load("Prefabs/Bear");

        obj = Instantiate(prefabs, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;        
        obj.transform.parent = GameObject.Find("Enemy").transform;
    }
}
