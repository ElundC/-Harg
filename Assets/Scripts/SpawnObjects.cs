using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public List<GameObject> tiles;
    float waitTime = 0;

    void Start()
    {
        /*for(int x = 0; x < tiles.Count ; x++)             enleve tout les tiles avec le bon tag; 
        {
            if (tiles[x].CompareTag("Grey"))
            {
                tiles.Remove(tiles[x]);
                x--;                                        si on enleve x-- une tile sur deux sera pas enlevé;
            }
    
        }
        
        int countList = tiles.Count;                        duplique toute les tiles du bon tag; 

        for(int x = 0; x < countList ; x++)
        {
            if (tiles[x].CompareTag("Snow"))
            {
                tiles.Add(tiles[x]);
                x++;                                        avec x++ un sur deux de dupliquer;
            }
    
        }
        for(int x = 0; x < tiles.Count; x++)                enleve les tiles avec le layer 7 soit block
        {
            if(tiles[x].layer == 7)
            {
                tiles.Remove(tiles[x]);
                x++;                                        sans rien enleve 1/2 avec x-- tout, avec x++ 1/3;
            }
        }
        
        int countList = tiles.Count;                       duplique les tiles avec le layer correspondant

        for(int x = 0; x < tiles.Count; x++){

            if(tiles[x].layer == 7)                        
            {
                tiles.Add(tiles[x]);                       !!!!! ne pas enlever x++ sinon crash car ajoute indefiniment des tiles dans la list
                x += 3;                                    x++ = toute copier / x +=2 = 1/2 copier / x +=3 = 1/3:
            }
        }*/
        
        GenerateLevel();
        
    }

        void GenerateLevel()
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