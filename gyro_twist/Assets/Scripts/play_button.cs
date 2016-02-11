using UnityEngine;
using System.Collections;

public class play_button : MonoBehaviour {

    void OnMouseDown()
    {
        Debug.Log("Going to the game");
        Application.LoadLevel("game");
    }
}
