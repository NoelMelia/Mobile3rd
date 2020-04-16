using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileHealthDamageController : MonoBehaviour
{
    [SerializeField]private float damage;
    public MobileHealthController healthController;

    void Start()
    {
        healthController = MobileHealthController.FindHealthController();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            Damage();
        }  
    }

    public void Damage()
    {
        healthController.currentHealth = healthController.currentHealth - damage;
        healthController.UpdateHealth();
        this.gameObject.SetActive(false);
    }
    
}
