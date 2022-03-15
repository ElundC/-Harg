using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public List<GameObject> tiles;
    float waitTime = 0;

    void Start()
    {
        if( transform.position.z == 0)
        {
            waitTime = 0;
        }
        else if(transform.position.z == 60)
        {
            waitTime = 0.7f;
        }
        else if(transform.position.z == 120)
        {
            waitTime = 1.4f;
        }
        else if (transform.position.z == 180)
        {
            waitTime = 2.1f;
        }
        else { waitTime = 2.8f;}

        StartCoroutine(WaitThenGenerate(waitTime));
    }
  
    private IEnumerator WaitThenGenerate ( float waitTime)
    {
        yield return new WaitForSeconds (waitTime);
        int rand = Random.Range(0, tiles.Count);
        Instantiate(tiles[rand], transform.position, Quaternion.identity);
    }

}