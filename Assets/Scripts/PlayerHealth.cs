using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private static float life = 100;
    private float maxLife = 100;
    public const float divideByThisToSetHealthBar = 100;
    [SerializeField] private GameOverHandler gameOverHandler;
    public void Crash(){
        life-=34;
        HealthBarScript.setHealthBarValue(life/divideByThisToSetHealthBar);
    }
    public static void increaseLifeByFloat(float value){
        if(life <150-value) life+=value;
        HealthBarScript.setHealthBarValue(life/divideByThisToSetHealthBar);
    }
    private void Update() {
        if(life<=0){
            gameOverHandler.endGame();
            gameObject.SetActive(false);
        }
    }
    
    public float getLife(){
        return life;
    }
    public float getMaxLife(){
        return maxLife;
    }

    public void setLife(float v)
    {
        life = v;
    }
}
