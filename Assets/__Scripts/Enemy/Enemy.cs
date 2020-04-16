using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//use to manage collisons
public class Enemy : MonoBehaviour
{
    //set this up to publish an event to the system
    //when killed
    [SerializeField] private GameObject explosionFX;
    [SerializeField]private AudioClip crashSound;
    [SerializeField]private AudioClip dieSound;
    [SerializeField] private float explosionDuration = 1.0f;
    private SoundController sc;
    //public fields
    [SerializeField]private int scoreValue = 10;
    private void Start()
    {
        //sc = FindObjectOfType<SoundController>();
        sc = SoundController.FindSoundController();//Find Sound Controller 
    }
    //private Methods
    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        //para = what ran into me
        //if the player hit, then destroy the player
        //and the current enemy rectangle

        var player = whatHitMe.GetComponent<PlayerMovement>();
        var bullet = whatHitMe.GetComponent<Bullet>();

        //Debug.Log("Hit Something");
        if(player)//if(player != null)
        {          
            PlaySound(crashSound);
            //play crash sound here
            //destroy the player and the rectangle
            //give the player points/coins
            //Destroy(player.gameObject);
            Destroy(gameObject);
        }

        if(bullet)
        {
            //Score Value to be added to the total score
            ScoreScript.scoreValue += scoreValue;//Was 10
            //Play sound
            PlaySound(dieSound);
            //Destroy object
            Destroy(bullet.gameObject);
            //play die sound   
            //give player points
            //destroy bullet
            GameObject explosion = Instantiate(explosionFX, transform.position, transform.rotation);
            //destroy the game object
            Destroy(explosion, explosionDuration);
            Destroy(gameObject);
            //Destroy(explosion);
        }
    }
    private void PlaySound(AudioClip clip)
    {//Playing the sound and checking to see if soundcontoller is in level
        if(sc)
        {
            sc.PlayOneShot(clip);
        }
    }
    
}
