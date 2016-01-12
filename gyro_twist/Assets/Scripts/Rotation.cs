using System;
using System.Collections;
using UnityEngine;

public class Rotation : MonoBehaviour {

    void detectClick()
    {
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed left click.");

        if (Input.GetMouseButtonDown(1))
            Debug.Log("Pressed right click.");

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");
    }

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

    /*
    public static event Action<Vector2> OnResolutionChange;
    public static event Action<DeviceOrientation> OnOrientationChange;
    public static float CheckDelay = 0.5f;        // How long to wait until we check again.

    static Vector2 resolution;                    // Current Resolution
    static DeviceOrientation orientation;        // Current Device Orientation
    static bool isAlive = true;                    // Keep this script running?

    void Start()
    {
        StartCoroutine(CheckForChange());
    }

    IEnumerator CheckForChange()
    {
        resolution = new Vector2(Screen.width, Screen.height);
        orientation = Input.deviceOrientation;

        while (isAlive)
        {

            // Check for a Resolution Change
            if (resolution.x != Screen.width || resolution.y != Screen.height)
            {
                resolution = new Vector2(Screen.width, Screen.height);
                if (OnResolutionChange != null) OnResolutionChange(resolution);
            }

            // Check for an Orientation Change
            switch (Input.deviceOrientation)
            {
                case DeviceOrientation.Unknown:            // Ignore
                case DeviceOrientation.FaceUp:            // Ignore
                case DeviceOrientation.FaceDown:        // Ignore
                    break;
                default:
                    if (orientation != Input.deviceOrientation)
                    {
                        orientation = Input.deviceOrientation;
                        if (OnOrientationChange != null) OnOrientationChange(orientation);
                    }
                    break;
            }
            Debug.Log(orientation);
            yield return new WaitForSeconds(CheckDelay);
        }
    }

    void OnDestroy()
    {
        isAlive = false;
    }
    */


    // Update is called once per frame
    void Update () {

        //Imprimindo o valor de rotacao do celular
        Debug.Log(Input.acceleration.x);

    }
}
