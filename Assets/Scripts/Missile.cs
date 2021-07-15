using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Asteroid")){
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
