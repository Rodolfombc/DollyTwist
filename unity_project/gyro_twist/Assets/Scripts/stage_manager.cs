using UnityEngine;
using System.Collections;

public class stage_manager : MonoBehaviour {

    public Transform player;

    public GameObject floor;
    Vector2 instanceScale;

    float nextPositionX; //x position of next floor to be instantiated
    float bottomPositionY, topPositionY; //y position of next floor to be instantiated

    void Start()
    {
        bottomPositionY = -4.5f;
        topPositionY = 4.5f;

        nextPositionX = 25.9f;
    }

    //Creating the infinite stage
    void choosePosition()
    {
        int posY = UnityEngine.Random.Range(0, 2);

        if (posY > 0)
        {
            GameObject obj = Instantiate(floor, new Vector3(nextPositionX, topPositionY, 1), Quaternion.identity) as GameObject;
            instanceScale = obj.GetComponent<Transform>().localScale;
            instanceScale.y = -3;
            obj.GetComponent<Transform>().localScale = instanceScale;
            //Debug.Log("Floor at the top");
        }
        else
        {
            GameObject obj = Instantiate(floor, new Vector3(nextPositionX, bottomPositionY, 1), Quaternion.identity) as GameObject;
            instanceScale = obj.GetComponent<Transform>().localScale;
            instanceScale.y = 3;
            obj.GetComponent<Transform>().localScale = instanceScale;
            //Debug.Log("Floor at the bottom");
        }

        //Updating the x position of next floor object
        nextPositionX += 7.4f;
        //Debug.Log(posY);
    }


    //Detect when floorDeleter collides with a floor object
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            Destroy(coll.gameObject);
            choosePosition();
            //Debug.Log("bateu");
        }

    }

    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x - 15, 0, this.transform.position.z);
    }
}
