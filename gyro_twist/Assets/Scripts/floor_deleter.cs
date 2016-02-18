using UnityEngine;
using System.Collections;

public class floor_deleter : MonoBehaviour {

    public Transform player;

    //Detect when floorDeleter collides with a floor object
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            Destroy(coll.gameObject);
            //Debug.Log("bateu");
        }

    }

    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x - 15, 0, this.transform.position.z);
    }
}
