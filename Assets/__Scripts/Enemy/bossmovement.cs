using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmovement : MonoBehaviour
{[SerializeField] private GameObject explosionFX;
    [SerializeField]private AudioClip crashSound;
    [SerializeField]private AudioClip dieSound;
    [SerializeField] private float explosionDuration = 1.0f;
    private SoundController sc;
     private Transform Player;
     [SerializeField]public float MoveSpeed = 1;
     
    private void Start() {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sc = SoundController.FindSoundController();
        
    }
     void Update()
     {
         transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * Time.deltaTime);
     }
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
            Destroy(player.gameObject);
            Destroy(gameObject);
        }

        if(bullet)
        {
            ScoreScript.scoreValue += 250;
            PlaySound(dieSound);
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
    {
        if(sc)
        {
            sc.PlayOneShot(clip);
        }
    }
    
 }