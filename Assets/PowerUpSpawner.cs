using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] powerupPrefabs;
    [SerializeField] private float spawnRateBySeconds = 10f;
    private Camera mainCamera;
    private float timer;
    private int count = 0;

    void Start()
    {
        mainCamera = Camera.main;
    }


    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0){
            SpawnPowerUp();
            timer+=spawnRateBySeconds;
            count++;
        }
    }

    private void SpawnPowerUp(){
        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;
        spawnPoint.x = Random.value;
        spawnPoint.y = Random.value;


        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;
        GameObject selectedPowerUp = powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];
        GameObject powerUpInstance = Instantiate(selectedPowerUp, worldSpawnPoint, Quaternion.identity);
        Rigidbody rb = powerUpInstance.GetComponent<Rigidbody>();
        
    }
}
