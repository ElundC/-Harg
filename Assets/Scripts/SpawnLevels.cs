using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevels : MonoBehaviour
{
    public List<GameObject> levels;
    public int rand = 1; // Random.Range(0,4);
    void Start()
    {

        int randlevel = Random.Range(0, levels.Count);
        Instantiate(levels[randlevel], transform.position, Quaternion.identity);
    
    }
}