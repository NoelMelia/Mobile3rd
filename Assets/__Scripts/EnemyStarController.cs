using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStarController : MonoBehaviour
{
    public float speed;
    [SerializeField]private float damage;
    [SerializeField]private MobileHealthController healthController;
    public PlayerMovement player;
    //public GameObject enemyDaethEffect;
    public GameObject impactEffect;
    //public int pointsForKill;
    public float rotationSpeed;
    public int damageToGive;
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
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Player")
        {
            healthController.playerHealth = healthController.playerHealth - damage;
            healthController.UpdateHealth();
            this.gameObject.SetActive(false);
        }

        Instantiate(impactEffect,transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
