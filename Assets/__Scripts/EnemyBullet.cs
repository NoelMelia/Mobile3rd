using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // == private fields ==
    [SerializeField] private EnemyBullet projectile;
    // add a public method that can be called as an event
    // from the animation
    public  void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
