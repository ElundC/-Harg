using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevels : MonoBehaviour
{
    public List<GameObject> levels;
    public GameObject bridgespawner;
    public GameObject player;
    public RandomRule RuleNumber;

    public GameObject Kamera;
    
    void Start()
    {
        RuleNumber.value = Random.Range(0,13);

        int randlevel = Random.Range(0, levels.Count);

        Instantiate(levels[randlevel], transform.position, Quaternion.identity);
        Instantiate(bridgespawner, transform.position, Quaternion.identity);

        StartCoroutine(WaitLevel(7.0f));
    }

    IEnumerator  WaitLevel (float waitTime)
    {
        yield return new WaitForSeconds (waitTime);

        Vector3 pos = new Vector3(240,1,0);
        
        Instantiate(player, pos,Quaternion.identity);

        Kamera.SetActive(false);
    }
}