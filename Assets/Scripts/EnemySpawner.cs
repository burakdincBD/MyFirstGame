using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField]
    private GameObject[] monsterReference;
    private GameObject SpawnedMonsters;

    private int randomSide;
    private int randomIndex;

    [SerializeField]
    private Transform leftPos , rightPos;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
    
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters() 
    {
       while(true)
       {
         yield return new WaitForSeconds(Random.Range(1,5));
        randomIndex = Random.Range(0 , monsterReference.Length);
        randomSide = Random.Range(0,2);

        SpawnedMonsters = Instantiate(monsterReference[randomIndex]);
        
        //left side
        if(randomSide == 1)
        {
            SpawnedMonsters.transform.position = leftPos.position;
            SpawnedMonsters.GetComponent<EnemyScriipt>().speed = Random.Range(2,6);
            spriteRenderer = SpawnedMonsters.GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true;
            
        }
        //right side
        else 
        {
            SpawnedMonsters.transform.position = rightPos.position;
            SpawnedMonsters.GetComponent<EnemyScriipt>().speed = -Random.Range(2,6);
            
        }
        }
    }






} //class
