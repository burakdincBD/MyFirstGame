using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        Debug.Log(GroupTypes.ENEMY_TAG);
        collision.CompareTag(GroupTypes.ENEMY_TAG);
        Destroy(gameObject);
    }
}
