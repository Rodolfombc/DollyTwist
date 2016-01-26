using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

    /// <summary>
    /// Codigo de terceiros
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
    /// Codigo de terceiros
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







    public Image gameTitle;

    //Variaveis para o titulo do jogo
    private float gameTitleZRot;

    private bool objectsSpawned;

    void Start()
    {
        //Inicializando os botoes de jogar sem opacidade e gravidade
        foreach (GameObject button in GameObject.FindGameObjectsWithTag("jogarButton"))
        {
            Destroy(button.GetComponent<Rigidbody2D>());
            Destroy(button.GetComponent<randomizeColor>());
            button.GetComponent<Text>().color = new Color(0, 0, 0, 0);
        }
        objectsSpawned = false;

        //Valor da rotacao do texto do titulo do jogo
        gameTitleZRot = 0;
    }


    //Metodo para redimensionar o titulo do jogo
    void resizeGameTitle()
    {
        if (gameTitle.transform.localScale.x < 1.0f)
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

    void FixedUpdate () {
        //Imprimindo o valor de rotacao do celular
        //Debug.Log(Input.acceleration.x);

        animateGameTitle();

        //Quando a animacao do titulo do jogo acabar, apareceremos com os botoes
        if (gameTitleZRot <= -1080 && gameTitle.transform.localScale.x > 1.0f && gameTitle.transform.localScale.y > 1.0f)
        {
            if (!objectsSpawned)
            {
                //Debug.Log("SPAWNAR GERAL");
                foreach (GameObject button in GameObject.FindGameObjectsWithTag("jogarButton"))
                {
                    button.AddComponent<Rigidbody2D>();
                    button.AddComponent<randomizeColor>();
                }
                objectsSpawned = true;
            }
        }
        

    }
    
}
