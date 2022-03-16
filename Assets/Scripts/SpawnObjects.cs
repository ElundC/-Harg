using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public List<GameObject> tiles;

    public GameObject SpawnerLevel;

    public RandomRule RuleNumber;
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

        int rulenum = RuleNumber.value;

        if(transform.parent.CompareTag("Level")) {
           ChooseRule(rulenum, null,null, rand);

        }
        else if (transform.parent !=null && !transform.parent.CompareTag("Level")) {
        
            GameObject parentgo = gameObject.transform.parent.gameObject;
            string parenttiles = parentgo.tag;
            
            if( transform.parent.transform.parent == null || transform.parent.transform.parent.transform.parent == null || transform.parent.transform.parent.transform.parent.transform.parent == null || transform.parent.transform.parent.transform.parent.transform.parent.transform.parent == null)  {
            
              ChooseRule(rulenum, parenttiles, null, rand);       
            }
            else {
                GameObject parent5 = transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.gameObject;
                string parent5tiles = parent5.tag;

                ChooseRule(rulenum, parenttiles, parent5tiles, rand);
            }
        }
        
        rand = Random.Range(0, tiles.Count);

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


    void ChooseRule(int num , string parent, string parent5, int rand)
    {
       // string chosenrule ="No Rule";

        if(num > 0 && num < 5)
        {
            NoSameNeigbhours(parent, parent5, rand);

            //chosenrule = "Tiles can't be of the type of their neighbours";
        }
        if(num >= 5 && num < 9)
        {
            SameNeigbhourschanceincrease(parent, parent5, rand);

           // chosenrule = "More chance for tile to be of the same type of their neighbours";
        }
        if(num >= 9 && num < 13)
        {
            AllBlock(rand);
           // chosenrule = "Tiles who can have walls will alays spawn a wall";
        }
        else {}  
    }


    void NoSameNeigbhours(string parent, string parent5, int rand) {

        if( parent != null && parent5 != null){
            for(int x = 0; x < tiles.Count; x++)
            {
                if (tiles[x].CompareTag(parent) || tiles[x].CompareTag(parent5))
                {
                    tiles.Remove(tiles[x]);
                    x--;
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
                }
            }
        }
        else {}
    }

    void SameNeigbhourschanceincrease(string parent, string parent5, int rand)
    {
        int currenttilescount = tiles.Count;

        for(int y = 0; y < 3; y++) {

            if( parent != null && parent5 != null){
                for(int x = 0; x < currenttilescount; x++)
                {
                    if (tiles[x].CompareTag(parent) || tiles[x].CompareTag(parent5))
                    {
                        tiles.Add(tiles[x]);
                    }
                } 
                
            }
            else if( parent != null && parent5 == null){
                for(int x = 0; x < currenttilescount; x++)
                {
                    if (tiles[x].CompareTag(parent))
                    {
                        tiles.Add(tiles[x]);
                    }
                }
                
                
            }
            else {}    
        }
    }

    void  AllBlock(int rand) {

        if(gameObject.layer == 7) {
            for(int x = 0; x < tiles.Count; x++)                
            {
                if(tiles[x].layer == 6)
                {
                    tiles.Remove(tiles[x]);
                    x--;;                                      
                }
            }
        }
    }
}