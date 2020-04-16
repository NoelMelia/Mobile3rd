using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitFinishLine : MonoBehaviour
{
    //Assigning a level to the impact of finish line
    [SerializeField] private string newLevel;
    private MobileHealthController healthController;

    void Start()
    {
        healthController = MobileHealthController.FindHealthController();
        //Tried to Update health on each level but couldnt
        //healthController.currentHealth = healthController.UpdateHealth();
        //Debug.Log(healthController.currentHealth);
    }
    //Trogger for object
    void OnTriggerEnter2D(Collider2D other) {
        //health.currentHealth = health.playerHealth;
        //Debug.Log(health.playerHealth);
        //weapon.bulletPrefab = weapon.bulletPrefab;

        //Once player meets the line the player starts on new level
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(newLevel);
        }
    }
}
