using UnityEngine;
using System.Collections;

public class stage_generator : MonoBehaviour {

    public GameObject floor;
    Vector2 instanceScale;

    float nextPositionX; //x position of next floor to be instantiated
    float bottomPositionY, topPositionY; //y position of next floor to be instantiated
	
	void Start () {
        bottomPositionY = -4.5f;
        topPositionY = 4.5f;

        nextPositionX = 18.5f;

        initGenerating();
	}

    void initGenerating()
    {
        InvokeRepeating("choosePosition", 1, 1.5f);
    }

    void choosePosition()
    {
        int posY = Random.Range(0, 2);

        if(posY > 0)
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
	
}
