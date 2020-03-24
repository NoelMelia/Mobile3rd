using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponsController : MonoBehaviour
{
    //private Variables
    [SerializeField] private float bulletSpeed = 6.0f;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float firingRate = 0.25f;
    //Private Methods
    private GameObject bulletParent;
    public Transform firePoint;
    public float bulletForce = 20f;
    private Coroutine firingCoroutine;
    private void Start() {
        bulletParent = GameObject.Find("BulletParent");
        if (!bulletParent)
        {
            bulletParent = new GameObject("BulletParent");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // one way to fire
            //FireBullet();
            // implement a coroutine to fire
            firingCoroutine = StartCoroutine(FireCoroutine());
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            //StopAllCoroutines();    // not good, sledgehammer approach
            StopCoroutine(firingCoroutine);
        }
    }
     private IEnumerator FireCoroutine()
    {
        while(true)
        {
            //Instantiate Bullet
            Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            //give it the same position as the player
            
            
            // sleep for short time
            yield return new WaitForSeconds(firingRate); // pick a number!!!
        }
    }
}
