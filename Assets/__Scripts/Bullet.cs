using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
   //for identification only

   private void OnTriggerEnter2D(Collider2D other) {
       
      Debug.Log(other.name);
      Destroy(gameObject);
   }
   private void OnBecameInvisible()  // disappear when out of view
    {
        Destroy(gameObject);
    }

   private void Update() // destroy after 3 seconds
   {
       Destroy(gameObject, 3.0f);

   }
}
