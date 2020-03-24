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
    [SerializeField]private AudioClip spawnSound;
    [SerializeField] private float explosionDuration = 1.0f;
    private SoundController sc;
    //public fields
    public int ScoreValue{get {return scoreValue;}}
    //delegete type to use in event
    public delegate void EnemyKilled(Enemy enemy);

    //create static method to be implemented in the listener
    public static EnemyKilled EnemyKilledEvent;
    //private 
    [SerializeField]private int scoreValue = 10;
  private void Start()
    {
        //sc = FindObjectOfType<SoundController>();
        sc = SoundController.FindSoundController();
        PlaySound(spawnSound);
    }
    private void PlaySound(AudioClip clip)
    {
        if(sc)
        {
            sc.PlayOneShot(clip);
        }
    }
    //private Methods
    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        //para = what ran into me
        //if the player hit, then destroy the player
        //and the current enemy rectangle

        var player = whatHitMe.GetComponent<PlayerMovement>();
        var bullet = whatHitMe.GetComponent<Bullet>();

        Debug.Log("Hit Something");

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
            ScoreScript.scoreValue += 10;
            PlaySound(dieSound);
           Destroy(bullet.gameObject);
            //play die sound
            PublishEnemyKilledEvent();
            //give player points
            //destroy bullet
            GameObject explosion = Instantiate(explosionFX, transform.position, transform.rotation);
            
            //destroy the game object
            Destroy(explosion, explosionDuration);
            Destroy(gameObject);
            //Destroy(explosion);
        }
    }
    private void PublishEnemyKilledEvent()
    {
        //make sure someone is listening
        if(EnemyKilledEvent != null)
        {
            EnemyKilledEvent(this); 
        }
        

    }
    
}
