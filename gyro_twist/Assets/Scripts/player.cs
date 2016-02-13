using UnityEngine;
using System;

public class player : MonoBehaviour {

    int life;
    Vector2 updatableGravity;
    Quaternion playerRotation;

    bool collidingWithFloor;

    void Start()
    {
        life = 3;
        updatableGravity = Physics2D.gravity;
        playerRotation =  transform.rotation;

        collidingWithFloor = false;
    }

    //Detect when player collides with another object
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            //Debug.Log("Player grounded!");
            this.GetComponent<Animator>().Play("player_run");
        }

    }

    //Detect when player still collides with another object
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            this.GetComponent<Animator>().Play("player_run");
            transform.rotation = playerRotation;
            collidingWithFloor = true;
        }
    }

    //Detect when player stops colliding with another object
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            //Debug.Log("Player not grounded!");
            this.GetComponent<Animator>().Play("player_fall");
            transform.rotation = playerRotation;
            collidingWithFloor = false;
        }
            

    }

    void updateGravity(String orientation)
    {
        Vector2 theScale = this.GetComponent<Transform>().localScale;

        switch (orientation)
        {
            case "LandscapeRight":
                updatableGravity = new Vector2(0.0f, -9.8f);
                Physics2D.gravity = updatableGravity;
                theScale.y = 4;
                this.GetComponent<Transform>().localScale = theScale;
                break;
            case "LandscapeLeft":
                updatableGravity = new Vector2(0.0f, 9.8f);
                Physics2D.gravity = updatableGravity;
                theScale.y = -4;
                this.GetComponent<Transform>().localScale = theScale;
                break;
        }
        //Debug.Log(Physics2D.gravity);
    }

    void runPlayer()
    {
        // Check if the body's current velocity will result in a collision
        if ((transform.position.y < -4 || transform.position.y > 4) && collidingWithFloor)
        {
            // If so, stop the movement
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
            this.GetComponent<Animator>().Play("player_fall");
            this.GetComponent<Animator>().Stop();
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(5.0f, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void checkLife()
    {
        if(transform.position.y < -5.0f || transform.position.y > 5.0f || life < 1)
        {
            Debug.Log("MORREUUU");
        }
    }
    
    void FixedUpdate () {
        //Updates the gravity according to mobile orientation
        updateGravity(Input.deviceOrientation.ToString());

        runPlayer();

        checkLife();

        //Correcting the player rotation 
        if(transform.rotation != playerRotation)
        {
            transform.rotation = playerRotation;
        }
    }
}
