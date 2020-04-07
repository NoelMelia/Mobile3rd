using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileHealthDamageController : MonoBehaviour
{
    [SerializeField]private float damage;
    [SerializeField]private MobileHealthController healthController;

     void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            Damage();
        }

        
        
    }

     void Damage()
    {
        healthController.playerHealth = healthController.playerHealth - damage;
        healthController.UpdateHealth();
        this.gameObject.SetActive(false);
    }
}
