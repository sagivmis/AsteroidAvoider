using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private Collider colliderObject;
    public GameObject pickupEffect;
    private float timer = 0;
    private void OnTriggerEnter(Collider other) {
        colliderObject = other;
        if(other.CompareTag("Player")){
            StartCoroutine(Pickup(colliderObject));
        }
    }
    IEnumerator Pickup(Collider player)
    {
        GameObject animation =Instantiate(pickupEffect, transform.position, transform.rotation);
        if(gameObject.tag == "Expand"){
            player.transform.localScale *= 1.4f;
        }
        if(gameObject.tag == "Shrink"){
            player.transform.localScale /= 1.4f;
        }
        if(gameObject.tag == "Armor"){
            PlayerHealth.increaseLifeByFloat(12f);
            Destroy(animation);
            Destroy(gameObject);
        }

        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(4f);

        if(gameObject.tag == "Expand"){    
            player.transform.localScale/=1.4f;
            Destroy(animation);
            Destroy(gameObject);
        }
        if(gameObject.tag == "Shrink"){    
            player.transform.localScale*=1.4f;
            Destroy(animation);
            Destroy(gameObject);
        }
        if(gameObject.tag == "Armor"){    
            Destroy(animation);
            Destroy(gameObject);
        }
    }

    void destroyPowerUp(){
        if(gameObject.tag == "Shrink"){
            colliderObject.transform.localScale *= 1.4f;
        }
        if(gameObject.tag == "Expand"){
            colliderObject.transform.localScale /= 1.4f;
        }
        colliderObject.transform.localScale/=1.4f;
        Destroy(gameObject);
    }
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
    
    private void Spin(){
        gameObject.transform.Rotate(0f,2f,0f, Space.Self);
    }
    private void Update() {
        Spin();
        timer+=Time.deltaTime;
        if(timer>10) Destroy(gameObject);
    }
}

