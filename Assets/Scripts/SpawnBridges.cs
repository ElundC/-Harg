using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBridges : MonoBehaviour
{
    public List<GameObject> Bridges;

    void Start()
    {
        int randlevel = Random.Range(0, Bridges.Count);
        Instantiate(Bridges[randlevel], transform.position, Quaternion.identity);
    }
}

