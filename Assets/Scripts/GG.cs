using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GG : MonoBehaviour
{
    public float a=10f;

    public GameObject Background_ex1;
    //private float  a = 1.14895f;
    Vector3 ilkVektor = new Vector3(-35.57317f,3.125f,0f);
    Vector3 sonVektor = new Vector3(-8.576f,3.125f,0f);
    Vector3 fark = new Vector3(0.84717f,0f,0f);
    //float _Fark = 0.84717f;

    void Start()
    { 
        while ( ilkVektor.x < sonVektor.x )
        {
        Instantiate(Background_ex1, ilkVektor + fark, Quaternion.identity);
        //Instantiate(tileset_sliced_3, ilkVektor + fark, Quaternion.identity);
        ilkVektor += fark;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }











}   

