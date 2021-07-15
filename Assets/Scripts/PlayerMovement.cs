using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;
    [SerializeField] private int incrementSpeedRotationEveryXScoreBy1;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private float drawBack;
    // [SerializeField] private TM_Text ;
    private Rigidbody rb;
    private Camera mainCamera;
    private Vector3 moveDirection;
    private int score;
    private Vector3 velocity;
    
    private Vector3 prevPos;
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        score = scoreSystem.getScore();
        maxVelocity = Mathf.FloorToInt(score /incrementSpeedRotationEveryXScoreBy1)+6;
        rotationSpeed = Mathf.FloorToInt(score /incrementSpeedRotationEveryXScoreBy1)+15;
        forceMagnitude = Mathf.FloorToInt(score /incrementSpeedRotationEveryXScoreBy1 * 100)+1500;
        proccessInput();
        keepPlayerOnScreen();
        rotateToFaceVelocity();
        drawBackShip();
        float magnitude = rb.velocity.magnitude;

        // VelocityBarScript.setVelocityBarValue(magnitude/maxVelocity);
        velocity = (transform.position - prevPos) / Time.deltaTime;
        prevPos = transform.position;
        Debug.Log(rb.velocity.magnitude); //VELOCITY
    }

    void drawBackShip(){
        if(rb.velocity.magnitude> 0.25)
            rb.velocity *= drawBack;
        else
        {
            rb.velocity = new Vector3(0f,0f,0f);
        }
    }

    public float getMagnitude(){
        return rb.velocity.magnitude;
    }
    public float getMaxVelocity(){
        return maxVelocity;
    }

    void FixedUpdate() {
        if(moveDirection == Vector3.zero){return;}
        rb.AddForce(moveDirection*forceMagnitude*Time.deltaTime, ForceMode.Force);
        rb.velocity= Vector3.ClampMagnitude(rb.velocity, maxVelocity);    
    }

    private void proccessInput(){
        if(Touchscreen.current.press.isPressed){
            Vector2 touchPos = Touchscreen.current.position.ReadValue();
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(touchPos);

            moveDirection = worldPos - transform.position;
            moveDirection.z = 0f;
            moveDirection.Normalize();
        }
        else{
            moveDirection = Vector3.zero;
        }
    }
    private void keepPlayerOnScreen(){
        Vector3 newPos = transform.position;

        Vector3 viewPortPos=mainCamera.WorldToViewportPoint(transform.position);
        if(viewPortPos.x > 1){
            newPos.x = -newPos.x+0.1f;
        }
        if(viewPortPos.x < 0){
            newPos.x = -newPos.x-0.1f;
        }
        if(viewPortPos.y > 1){
            newPos.y = -newPos.y+0.1f;
        }
        if(viewPortPos.y < 0){
            newPos.y = -newPos.y-0.1f;
        }
        transform.position = newPos;
    }
    private void rotateToFaceVelocity(){
        if(rb.velocity == Vector3.zero){return;}
        Quaternion targetRotation = Quaternion.LookRotation(rb.velocity,Vector3.back);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed*Time.deltaTime);

    }
}
