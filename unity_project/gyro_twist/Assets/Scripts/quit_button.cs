using UnityEngine;
using System.Collections;

public class quit_button : MonoBehaviour {

    void OnMouseDown()
    {
        //Debug.Log("Quiting the game");
        Application.Quit();
    }
}
