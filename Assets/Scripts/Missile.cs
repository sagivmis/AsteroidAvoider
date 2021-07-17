using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // [SerializeField] private PlayerHealth playerHealth;
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Asteroid")){
            PlayerHealth.increaseLifeByFloat(5f); // NOT WORKING
            Destroy(gameObject);
        }
    }
    private void Start() {
        // playerHealth = gameObject.GetComponent<PlayerHealth>();
    }
    void Update()
    {
        
    }
}
