using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthPickUp : MonoBehaviour
{
    //Calling the MobileHealth Controller
    MobileHealthController Health;
    //Assigning 15 health to object
    [SerializeField]private float healthBonus = 15f;
    private SoundController sc;
    [SerializeField]private AudioClip sound;
    private void Start()
    {
        //sc = FindObjectOfType<SoundController>();
        sc = SoundController.FindSoundController();//Find Sound Controller
        //Finding the health Controller
        Health = FindObjectOfType<MobileHealthController>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //Making sure the player has less then 100
        if(Health.currentHealth < 100)
        {
            PlaySound(sound);
            //Destroy the game object
            Destroy(gameObject);
            Health.currentHealth += healthBonus;
            Health.healthText.text = Health.currentHealth.ToString("0");
            //Debug.Log(Health.healthText.text);
            if(Health.currentHealth > 100)
            {//Not Letting Health go past 100 on the health bar
                Health.currentHealth = 100;
                Health.healthText.text = Health.currentHealth.ToString("0");
                Debug.Log(Health.healthText.text);
            }
        }
    }
    private void PlaySound(AudioClip clip)
    {//Play Method
        if(sc)
        {
            sc.PlayOneShot(clip);
        }
    }
}
