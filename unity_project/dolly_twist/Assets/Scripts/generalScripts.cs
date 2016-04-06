using UnityEngine;
using System.Collections;

public class generalScripts : MonoBehaviour {

    /// <summary>
    /// Metodo para detectar clicks/touchs na tela
    /// </summary>
    void detectClick()
    {
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed left click.");

        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed right click.");

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");
    }

    /// <summary>
    /// Metodo para detectar multitouch e o numero de dedos na tela
    /// </summary>
    void detectMultiTouch()
    {
        int fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                fingerCount++;

        }
        if (fingerCount > 0)
            print("User has " + fingerCount + " finger(s) touching the screen");
    }
}
