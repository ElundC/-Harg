using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBridges : MonoBehaviour
{
    public List<GameObject> Bridges;
    bool wall = false;

    void Start()
    {
        
        StartCoroutine(WaitForLevel(5.0f));
        
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            wall = true;
        }
        else { }
    }

    IEnumerator  WaitForLevel (float waitTime)
    {
        yield return new WaitForSeconds (waitTime);
        int randlevel = Random.Range(0, Bridges.Count);

        if(!wall){
            Instantiate(Bridges[randlevel], transform.position, Quaternion.identity);
        }
        
    }
}

    