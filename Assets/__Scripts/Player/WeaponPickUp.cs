using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField]private AudioClip sound;
    public Weapon weapon;//Calling the Weapon class
    private SoundController sc;
    private void Start()
    {
        //sc = FindObjectOfType<SoundController>();
        sc = SoundController.FindSoundController();//Find Sound Controller
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag =="Player")
        {//Once impact with player   
            PlaySound(sound);
            other.GetComponent<WeaponsController>().currentWeapon = weapon;
            other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon.currentWeaponSpt;
            //Assigned the Sprite to the firepoint of the player and using it to create an object and gun
            //for the player to use
            //SaveWeapon();
            Destroy(gameObject);
        }
        //SaveWeapon();
        
    }
    public void SaveWeapon()
    {//Saving weapon to use for next level
        //currentWeapon = weapon.currentWeaponSpt;
        //Debug.Log("Saved");
    }
    private void PlaySound(AudioClip clip)
    {//Play Method
        if(sc)
        {
            sc.PlayOneShot(clip);
        }
    }
}
