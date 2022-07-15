using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Items : MonoBehaviour
{
    public GameObject[] SpawnItems;
 

    private void Start()
    {

        Instantiate(SpawnItems[Random.Range(0, SpawnItems.Length)], this.transform);
    }

}
