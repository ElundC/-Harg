using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public List<GameObject> tiles;

    public GameObject SpawnerLevel;
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

    public void GenerateLevel()
    {
        int rand = Random.Range(0, tiles.Count);

        int rulenum = SpawnerLevel.GetComponent<SpawnLevels>().rand;

        


        if(transform.parent.CompareTag("Level")) {
           rand = ChooseRule(rulenum, null,null, rand) -1;

        }
        else if (transform.parent !=null && !transform.parent.CompareTag("Level")) {
        
            GameObject parentgo = gameObject.transform.parent.gameObject;
            string parenttiles = parentgo.tag;
            
            if( transform.parent.transform.parent == null || transform.parent.transform.parent.transform.parent == null || transform.parent.transform.parent.transform.parent.transform.parent == null || transform.parent.transform.parent.transform.parent.transform.parent.transform.parent == null)  {
            
                rand = ChooseRule(rulenum, parenttiles, null, rand) -1;       
            }
            else {
                GameObject parent5 = transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.gameObject;
                string parent5tiles = parent5.tag;

                rand = ChooseRule(rulenum, parenttiles, parent5tiles, rand) -1;
            }
        }
        

        if(rand < 0) { rand =0;}

        Debug.Log( rand + "   " + tiles.Count);
        Instantiate(tiles[rand], transform.position, Quaternion.identity);

        string currenttiles = tiles[rand].tag;

        gameObject.tag = currenttiles;
    
        if(transform.childCount > 0) {

            StartCoroutine(WaitThenGenerate(0.2f)); 
        }

    }
    IEnumerator WaitThenGenerate ( float waitTime)
    {
        yield return new WaitForSeconds (waitTime);
        GameObject child = gameObject.transform.GetChild(0).gameObject;
        child.SetActive(true);
    }


    int ChooseRule(int num , string parent, string parent5, int rand)
    {
        int finalrand =0;

        if(num == 1)
        {
            finalrand = NoSameNeigbhours(parent, parent5, rand);
        }
       /* if(num == 2)
        {
            Rule2();
        }
        if(num == 3)
        {
            Rule3();
        }
        else { NoRule(); }*/

        return finalrand;
    }


    int  NoSameNeigbhours(string parent, string parent5, int rand) {

        int lentghRemove = 0;
        int newrand = rand;

        if( parent != null && parent5 != null){
            for(int x = 0; x < tiles.Count; x++)
            {
                if (tiles[x].CompareTag(parent) || tiles[x].CompareTag(parent5))
                {
                    tiles.Remove(tiles[x]);
                    x--;
                    lentghRemove++;

                }
            }
            if( rand > tiles.Count)
            {
                newrand = tiles.Count - lentghRemove;

                if( newrand < 0)
                {
                     newrand = 0;
                }
            }
        }
        else if( parent != null && parent5 == null){
            for(int x = 0; x < tiles.Count; x++)
            {
                if (tiles[x].CompareTag(parent))
                {
                    tiles.Remove(tiles[x]);
                    x--;
                    lentghRemove++;

                }
            }
            if( rand > tiles.Count)
            {
                newrand = tiles.Count - lentghRemove;

                if( newrand < 0)
                {
                     newrand = 0;
                }
            }
        }
        else {}

      //  Debug.Log(newrand + "   " + lentghRemove + "   "+ tiles.Count);
        return newrand;
        
    }
}