using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class EnemyStarController : MonoBehaviour
{
    public float speed;
    
    //[SerializeField]private MobileHealthController healthController;
    public PlayerMovement player;
    //public GameObject enemyDaethEffect;
    public GameObject impactEffect;
    //public int pointsForKill;
    public float rotationSpeed;
    
    [SerializeField] private float explosionDuration = 1.0f;
    private Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        
        player = FindObjectOfType<PlayerMovement>();

        myRb = GetComponent<Rigidbody2D>();

        if(player.transform.position.x < transform.position.x)
        {
            speed = -speed;
            rotationSpeed = - rotationSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        myRb.velocity = new Vector2(speed, myRb.velocity.y);

        myRb.angularVelocity = rotationSpeed;

        Destroy(gameObject, 4.0f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        var player = other.GetComponent<PlayerMovement>();
        var border = other.GetComponent<BoundaryCollider>();

        if(player)
        {
            GameObject explosion = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(explosion, explosionDuration);
            Destroy(gameObject);
        }
     
    }
    
}
