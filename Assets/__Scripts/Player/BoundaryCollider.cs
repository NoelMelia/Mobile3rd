using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class BoundaryCollider : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D whatHitMe)
   {
       var enemy = whatHitMe.GetComponent<Enemy>();
       var bullet = whatHitMe.GetComponent<Bullet>();
       if(bullet)
       {
           Destroy(bullet.gameObject);
       }

       if(enemy)
       {
           Destroy(enemy.gameObject);
       }
   }
}
