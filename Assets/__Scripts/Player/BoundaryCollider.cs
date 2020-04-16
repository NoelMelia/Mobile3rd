using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class BoundaryCollider : MonoBehaviour
{
    //An event for something to happen when an object meet this object
   private void OnTriggerEnter2D(Collider2D whatHitMe)
   {
       //Enemy, Bullet and bullet of enemy to be destroyed an impact
       var enemy = whatHitMe.GetComponent<Enemy>();
       var bullet = whatHitMe.GetComponent<Bullet>();
       var enemyBullet = whatHitMe.GetComponent<EnemyStarController>();
       if(bullet)
       {
           Destroy(bullet.gameObject);
       }

       if(enemy)
       {
           Destroy(enemy.gameObject);
       }
       if(enemyBullet)
       {
           Destroy(enemyBullet.gameObject);
       }
   }
}
