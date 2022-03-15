using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevels : MonoBehaviour
{
    public List<GameObject> levels;
    void Start()
    {

        int randlevel = Random.Range(0, levels.Count);
        Instantiate(levels[randlevel], transform.position, Quaternion.identity);
    
    }
}