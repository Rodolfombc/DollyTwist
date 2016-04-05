using UnityEngine;
using System.Collections;

public class camera_movement : MonoBehaviour {

    public Transform player;
    float repositionCamera;
    float offsetX;

    AudioSource audio;

    void Start()
    {
        repositionCamera = 0.0f;
        offsetX = 5.0f;

        audio = GetComponent<AudioSource>();
    }
	
	void FixedUpdate () {
        if(player.transform.position.x > 0)
        {
            if (repositionCamera < offsetX)
            {
                repositionCamera += 0.05f;
            }

            transform.position = new Vector3(player.transform.position.x + repositionCamera, 0, this.transform.position.z);
        }

    }
}
