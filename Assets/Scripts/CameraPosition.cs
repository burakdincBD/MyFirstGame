using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    public float minX, maxX;

   // GameManager gamemanager = new GameManager(); 
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; 

    
        print("Player Değeri: "+ GameManager.instance.CharIndex);

        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!player)
        return;
        
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if(tempPos.x > maxX)
           tempPos.x = maxX;
           
        if(tempPos.x < minX)
           tempPos.x = minX;
        
        transform.position  = tempPos;
    }

} //class




















