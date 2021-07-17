using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float missileSpeed;
    [SerializeField] private float missileEveryXSecond;
    private Camera mainCamera;
    private float timer=0;
    private bool canShoot = false;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(canShoot){
            if (Touchscreen.current.press.isPressed){
                Vector2 touchPos = Touchscreen.current.position.ReadValue();
                Vector2 worldPos = mainCamera.ScreenToWorldPoint(touchPos);
                Vector2 direction = worldPos - (new Vector2(transform.position.x, transform.position.y));
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
                Vector3 realWorldPos = new Vector3(worldPos.x, worldPos.y, 0);
                direction.Normalize();

                GameObject missile = Instantiate(projectile, transform.position, rotation) as GameObject;

                missile.GetComponent<Rigidbody>().velocity = direction*missileSpeed;
                canShoot=false;
                timer = 0;
            }
        }
        if(!canShoot){
            timer+=Time.deltaTime;
        }
        if(timer >=missileEveryXSecond) canShoot=true;
    }
}
