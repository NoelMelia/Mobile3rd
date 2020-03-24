using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //Public Fields

    //Private Fields
    public Rigidbody2D rb;
    public Camera cam;
    public float speed = 5.0f;
    //Public Methods
    
    //Private Methods
    Vector2 movement;
    Vector2 mousePos;
    
    
    
    // Update is called once per frame
    void Update()
    {
        //if the player presses the up arrow then move
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        //Apply a force, get the player moving        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y,lookDir.x)* Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        
    }

    
}
