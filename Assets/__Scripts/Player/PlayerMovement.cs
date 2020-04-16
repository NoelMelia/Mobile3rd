using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //Public Fields

    //Private Fields
    private Rigidbody2D rb;
    [SerializeField]private Camera cam;
    [SerializeField]private float speed = 5.0f;
    //Public Methods
    Vector2 movement;//Movement following the mouse
    Vector2 mousePos;
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Moving the Player with W,A,S and D
        //if the player presses the up arrow then move
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        //Apply a force, get the player moving        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        
    }

    void FixedUpdate()
    {
        //Using Mouse 
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        //Looking at the direction of mouse 
        Vector2 lookDir = mousePos - rb.position;
        //Getting the angle of direction the player is looking
        float angle = Mathf.Atan2(lookDir.y,lookDir.x)* Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        
    }

    
}
