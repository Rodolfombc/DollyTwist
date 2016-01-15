using UnityEngine;
using System.Collections;
using System;

public class gravityHandler : MonoBehaviour {

    public static event Action<Vector2> OnResolutionChange;
    public static event Action<DeviceOrientation> OnOrientationChange;
    public static float CheckDelay = 0.1f;        // How long to wait until we check again.

    static Vector2 resolution;                    // Current Resolution
    static DeviceOrientation orientation;        // Current Device Orientation
    static bool isAlive = true;                    // Keep this script running?

    Vector2 updatableGravity;

    void Start()
    {
        StartCoroutine(CheckForChange());
        updatableGravity = Physics2D.gravity;
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

            //Debug.Log(orientation);

            updateGravity(orientation.ToString());

            yield return new WaitForSeconds(CheckDelay);
        }
    }

    void OnDestroy()
    {
        isAlive = false;
    }


    void updateGravity(String orientation)
    {
        switch (orientation)
        {
            case "Portrait":
                //Debug.Log("Gravidade para esquerda!");
                updatableGravity = new Vector2(-9.8f, 0.0f);
                Physics2D.gravity = updatableGravity;
                break;
            case "PortraitUpsideDown":
                //Debug.Log("Gravidade para direita!");
                updatableGravity = new Vector2(9.8f, 0.0f);
                Physics2D.gravity = updatableGravity;
                break;
            case "LandscapeRight":
                //Debug.Log("Gravidade para baixo!");
                updatableGravity = new Vector2(0.0f, -9.8f);
                Physics2D.gravity = updatableGravity;
                break;
            case "LandscapeLeft":
                //Debug.Log("Gravidade para cima!");
                updatableGravity = new Vector2(0.0f, 9.8f);
                Physics2D.gravity = updatableGravity;
                break;
        }
        //Debug.Log(Physics2D.gravity);
    }
}
