using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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



    public Image gameTitle;
    public Text textObj;

    private Color textColor;
    private float textTransform;

    //Variaveis para o titulo do jogo
    private float gameTitleZRot;

    void Start()
    {
        gameTitleZRot = 0;
    }


    //Metodo para gerar uma cor aleatoria
    Color RandomColor()
    {
        return new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    //Metodo para redimensionar o titulo do jogo
    void resizeGameTitle()
    {
        if(gameTitle.transform.localScale.x < 1.0f)
        {
            gameTitle.transform.localScale += new Vector3(0.01f, 0, 0);
        }

        if(gameTitle.transform.localScale.y < 1.0f)
        {
            gameTitle.transform.localScale += new Vector3(0, 0.01f, 0);
        }
    }

    //Metodo para rotacionar o titulo do jogo
    void rotateGameTitle()
    {
        if (gameTitleZRot > -1080)
        {
            gameTitleZRot -= 10;
            gameTitle.transform.Rotate(0, 0, -10);
        }
    }

    void animateGameTitle()
    {
        resizeGameTitle();
        rotateGameTitle();
    }

    // Update is called once per frame
    void FixedUpdate () {
        //Debug.Log(Input.acceleration.z);

        animateGameTitle();

        

        //Colorindo o texto jogar
        textColor = RandomColor();
        textObj.color = textColor;

        //Rotacionando o texto jogar
        //textTransform = Mathf.Abs(textObj.transform.rotation.y);
        //textObj.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 1), 4);

        //Imprimindo o valor de rotacao do celular
        //Debug.Log(Input.acceleration.x);

    }
    
}
