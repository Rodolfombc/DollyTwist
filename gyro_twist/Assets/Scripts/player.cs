using UnityEngine;
using System;
using UnityEngine.UI;

public class player : MonoBehaviour {

    //meterText variables
    public Text metersText;
    int meters;
    float metersUpdater;

    //goalText variables
    public Text goalsText;
    float goalUpdater;
    float goalShowTimer;
    float goalTextScaleX, goalTextScaleY;
    bool increaseScaleX, increaseScaleY;

    Vector2 updatableGravity;

    //player variables
    Quaternion playerRotation;
    int life;
    public float speed;
    bool collidingWithFloor;

    void Start()
    {
        //player variables
        life = 3;
        speed = 5.0f;

        //metersText variables
        meters = 0;
        metersUpdater = 0.0f;

        //goalText variables
        goalUpdater = 0;
        goalShowTimer = 0.0f;
        goalTextScaleX = goalsText.GetComponent<Transform>().localScale.x;
        goalTextScaleY = goalsText.GetComponent<Transform>().localScale.y;
        increaseScaleX = true;
        increaseScaleY = true;

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

    void checkGoal()
    {
        goalUpdater += 0.1f;

        //Every x meters
        if (goalUpdater > 100.1f)
        {
            goalUpdater = 0.0f;
            
            if(speed < 20)
            {
                speed += 1.0f;
            }
            Debug.Log(speed);
            

            goalsText.GetComponent<Text>().text = meters + " meters run!";
            goalsText.GetComponent<Text>().color = new Color(255, 255, 255, 1);
        }

        //Animation of the text 
        if(goalsText.GetComponent<Text>().color.a > 0)
        {
            //Animating x scale
            if (goalTextScaleX > 0.035f)
            {
                increaseScaleX = false;
            }
            else if (goalTextScaleX < 0.025f)
            {
                increaseScaleX = true;
            }

            if (increaseScaleX)
            {
                goalTextScaleX += 0.00066f;
            }
            else
            {
                goalTextScaleX -= 0.00066f;
            }
            
            //Animating y scale
            if (goalTextScaleY > 0.10f)
            {
                increaseScaleY = false;
            }
            else if(goalTextScaleY < 0.04f)
            {
                increaseScaleY = true;
            }
            if (increaseScaleY)
            {
                goalTextScaleY += 0.004f;
            }
            else
            {
                goalTextScaleY -= 0.004f;
            }

            goalsText.GetComponent<Transform>().localScale = new Vector3(goalTextScaleX, goalTextScaleY, 1);

            //Animation will occur during 1 second
            goalShowTimer += Time.deltaTime;
            if(goalShowTimer > 2.0f)
            {
                goalsText.GetComponent<Text>().color = new Color(255, 255, 255, 0);
                goalShowTimer = 0.0f;
            }
        }
    }

    void runPlayer()
    {
        metersUpdater += 0.1f;
        meters = (int)metersUpdater;
        metersText.GetComponent<Text>().text = meters + " meters";

        checkGoal();

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
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void checkLife()
    {
        if(transform.position.y < -5.0f || transform.position.y > 5.0f || life < 1)
        {
            //Debug.Log("MORREUUU");
            Application.LoadLevel("gameOver");
        }
    }
    
    void FixedUpdate () {
        //Updates the gravity according to mobile orientation
        updateGravity(Input.deviceOrientation.ToString());

        runPlayer();

        checkLife();

        //Debug.Log(goalUpdater);

        //Correcting the player rotation 
        if(transform.rotation != playerRotation)
        {
            transform.rotation = playerRotation;
        }
    }
}
