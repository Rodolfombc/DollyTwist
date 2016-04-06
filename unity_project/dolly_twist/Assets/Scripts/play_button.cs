using UnityEngine;
using System.Collections;

public class play_button : MonoBehaviour {

    void OnMouseDown()
    {
        //Debug.Log("Going to the game");
        Physics2D.gravity = new Vector2(0.0f, -9.8f);
        Application.LoadLevel("game");
    }
}
