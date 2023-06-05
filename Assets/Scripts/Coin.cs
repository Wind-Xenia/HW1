using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
