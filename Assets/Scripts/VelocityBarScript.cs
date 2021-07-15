using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VelocityBarScript : MonoBehaviour
{
    
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private TMP_Text velocityText;
    [SerializeField] private TMP_Text maxVelocityText;

    private static Image velocityBarImage;
    public static void setVelocityBarValue(float value=0){
        velocityBarImage.fillAmount = value;
        if(velocityBarImage.fillAmount < 0.2f)
        {
            setVelocityBarColor(Color.red);
        }
        else if(velocityBarImage.fillAmount < 0.4f)
        {
            setVelocityBarColor(Color.yellow);
        }
        else
        {
            setVelocityBarColor(Color.green);
        }
    }
    public static float getVelocityBarValue(){
        return velocityBarImage.fillAmount;
    }
    
    public static void setVelocityBarColor(Color velocityColor){
        velocityBarImage.color = velocityColor;
    }
    void Start()
    {
        velocityBarImage = GetComponent<Image>();
    }
    // public void increaseVelocityByFloat(float value){
    //     if(life <150-value) life+=value;
    //     HealthBarScript.setHealthBarValue(life/divideByThisToSetHealthBar);
    // }
    void Update()
    {
        maxVelocityText.text = "MAX:\n"+playerMovement.getMaxVelocity().ToString();
        velocityText.text = Mathf.FloorToInt(playerMovement.getMagnitude()).ToString();
        setVelocityBarValue(playerMovement.getMagnitude()/playerMovement.getMaxVelocity());
    }
}
