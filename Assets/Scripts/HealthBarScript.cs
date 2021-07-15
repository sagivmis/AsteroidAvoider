using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private static Image healthBarImage;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private PlayerHealth playerHealth;
    public static void setHealthBarValue(float value){
        healthBarImage.fillAmount = value;
        if(healthBarImage.fillAmount < 0.2f)
        {
            setHealthBarColor(Color.red);
        }
        else if(healthBarImage.fillAmount < 0.4f)
        {
            setHealthBarColor(Color.yellow);
        }
        else
        {
            setHealthBarColor(Color.green);
        }
    }
    public static float getHealthBarValue(){
        return healthBarImage.fillAmount;
    }
    
    public static void setHealthBarColor(Color healthColor){
        healthBarImage.color = healthColor;
    }

    void Start()
    {
        healthBarImage = GetComponent<Image>();
    }

    void Update()
    {
        float playerLife = playerHealth.getLife();
        if(playerLife<0) playerLife=0;
        healthText.text = $"{playerLife} / {playerHealth.getMaxLife()} ";
    }
}
