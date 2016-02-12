using UnityEngine;
using System;

public class player : MonoBehaviour {

    int life;
    Vector2 updatableGravity;

    void Start()
    {
        //life = 3;
        updatableGravity = Physics2D.gravity;
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
        }
    }

    //Detect when player stops colliding with another object
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            //Debug.Log("Player not grounded!");
            this.GetComponent<Animator>().Play("player_fall");
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

    
    void FixedUpdate () {
        //Updates the gravity according to mobile orientation
        updateGravity(Input.deviceOrientation.ToString());

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(5.0f, this.GetComponent<Rigidbody2D>().velocity.y);
    }
}
