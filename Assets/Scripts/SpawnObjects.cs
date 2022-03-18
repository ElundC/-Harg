using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public List<GameObject> tiles;
    public GameObject child;
    public GameObject parent1;
    public GameObject parent5;
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

        if(parent1 == null) {
           ChooseRule(rulenum, null,null, rand);

        }
        else {
        
            string parenttiles = parent1.tag;

            if( parent5 == null)  {
            
              ChooseRule(rulenum, parenttiles, null, rand);       
             
            }
            else {
                string parent5tiles = parent5.tag;
               
                ChooseRule(rulenum, parenttiles, parent5tiles, rand);
            }
        }
        
        rand = Random.Range(0, tiles.Count);

        Instantiate(tiles[rand], transform.position, Quaternion.identity);

        string currenttiles = tiles[rand].tag;

        gameObject.tag = currenttiles;
    
        if(child != null) {

            StartCoroutine(WaitThenGenerate(0.2f)); 
        }

    }
    IEnumerator WaitThenGenerate ( float waitTime)
    {
        yield return new WaitForSeconds (waitTime);
        child.SetActive(true);
    }


    void ChooseRule(int num , string parentTag, string parent5Tag, int rand)
    {
        string chosenrule ="No Rule";

        if(num > 0 && num < 5)
        {
            NoSameNeigbhours(parentTag, parent5Tag, rand);

            chosenrule = "Tiles can't be of the type of their neighbours";
        }
        if(num >= 5 && num < 9)
        {
            SameNeigbhourschanceincrease(parentTag, parent5Tag, rand);

            chosenrule = "More chance for tile to be of the same type of their neighbours";
        }
        if(num >= 9 && num < 13)
        {
            AllBlock(rand);
            chosenrule = "Tiles who can have walls will alays spawn a wall";
        }
        else {}  

        Debug.Log (chosenrule);
    }


    void NoSameNeigbhours(string parentTag, string parent5Tag, int rand) {

        if( parentTag != null && parent5Tag != null){
            for(int x = 0; x < tiles.Count; x++)
            {
                if (tiles[x].CompareTag(parentTag) || tiles[x].CompareTag(parent5Tag))
                {
                    tiles.Remove(tiles[x]);
                    x--;
                }
            }
        }
        else if( parentTag != null && parent5Tag == null){
            for(int x = 0; x < tiles.Count; x++)
            {
                if (tiles[x].CompareTag(parentTag))
                {
                    tiles.Remove(tiles[x]);
                    x--;
                }
            }
        }
        else {}
    }

    void SameNeigbhourschanceincrease(string parentTag, string parent5Tag, int rand)
    {
        int currenttilescount = tiles.Count;

        for(int y = 0; y < 3; y++) {

            if( parentTag != null && parent5Tag != null){
                for(int x = 0; x < currenttilescount; x++)
                {
                    if (tiles[x].CompareTag(parentTag) || tiles[x].CompareTag(parent5Tag))
                    {
                        tiles.Add(tiles[x]);
                    }
                } 
                
            }
            else if( parentTag != null && parent5Tag == null){
                for(int x = 0; x < currenttilescount; x++)
                {
                    if (tiles[x].CompareTag(parentTag))
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