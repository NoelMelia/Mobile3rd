using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class WeaponsController : MonoBehaviour
{
    //private Variables
    private GameObject bulletParent;
    [SerializeField]private AudioClip shootClip;//Asigning the Sound to game
    //Creating the necessary for Sound of gun
    private AudioSource audioSource;//Sound and range of sound
    [SerializeField][Range(0f, 1.0f)] private float shootVolume = 0.5f;
    private float firingRate;//Firerate of bullet and force
    private float bulletForce;
    private Transform firePoint;//Creating a firepoint 
    private Coroutine firingCoroutine;
    public Weapon currentWeapon;
    private void Start() {
        //Getting all the instances for fields assigned if null
        firePoint = GameObject.FindWithTag("FirePoint").transform;
        bulletParent = GameObject.Find("BulletParent");
        if (!bulletParent)
        {
            bulletParent = new GameObject("BulletParent");
        }
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(currentWeapon != null)//
        {
            if(currentWeapon.bulletForce > 0.00)//Checking to see if the bullet force is greater then zero
                {
                if(Input.GetKeyDown(KeyCode.Space))//When the space key is held and pressed
                {
                    // implement a coroutine to fire  
                    firingCoroutine = StartCoroutine(FireCoroutine());
                }
                if(Input.GetKeyUp(KeyCode.Space))//When the space bar button is off
                {
                    //StopAllCoroutines();    // not good, sledgehammer approach
                    StopCoroutine(firingCoroutine);
                }
            }
        }
        
    }
     private IEnumerator FireCoroutine()
    {//Method to repeat the command of keeping the button held
        while(true)
        {
            firingRate = currentWeapon.fireRate;//Calling the assigned variable values
            bulletForce = currentWeapon.bulletForce;
            //Instantiate Bullet
            GameObject bullet = Instantiate(currentWeapon.bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            audioSource.PlayOneShot(shootClip, shootVolume);//Shoot volume
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);//Adding force behind the bullet

            // sleep for short time
            yield return new WaitForSeconds(firingRate); // wait between buttons!!!
        }
    }
}
