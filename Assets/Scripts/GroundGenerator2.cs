using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator2 : MonoBehaviour
{
    // Start is called before the first frame update
     public float a=10f;

    public GameObject Gorund2;
    //private float  a = 1.14895f;
    Vector3 sonVektor = new Vector3(13.246f,-1.6641f,0f);
    Vector3 ilkVektor = new Vector3(-12.25f,-1.6641f,0f);
    Vector3 f = new Vector3(0.84717f,0f,0f);
    
    void Start()
    { 
        while ( ilkVektor.x < sonVektor.x )
        {
        Instantiate(Gorund2, ilkVektor + f, Quaternion.identity);
        ilkVektor += f;
        }
    }
    void Update()
    {
        
    }
}
