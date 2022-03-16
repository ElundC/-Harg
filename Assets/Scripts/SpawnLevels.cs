using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevels : MonoBehaviour
{
    public List<GameObject> levels;

    public RandomRule RuleNumber;
    
    void Start()
    {
        RuleNumber.value = Random.Range(0,13);

        int randlevel = Random.Range(0, levels.Count);
        Instantiate(levels[randlevel], transform.position, Quaternion.identity);
    }
}