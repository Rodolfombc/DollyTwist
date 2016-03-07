using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Splash_To_Menu : MonoBehaviour {

    Image splashImage;
    Color splashColor;
    float currentOpacity;
    float timeToChange;

    void Start()
    {
        //Valor inicial da opacidade da splashscreen
        currentOpacity = 0.0f;

        //Tempo da duracao da variacao da opacidade
        timeToChange = 1.0f;

        //Obtendo a splashscreen e setando o valor inicial da opacidade
        splashImage = GetComponent<Image>();
        splashColor = splashImage.color;
        splashColor.a = currentOpacity;
        splashImage.color = splashColor;

        Debug.Log(Screen.width);

    }

    void Update()
    {
        //Fade In
        if(Time.time < 1.0f)
        {
            currentOpacity += Time.deltaTime / timeToChange;
            splashColor.a = currentOpacity;
            splashImage.color = splashColor;
        }

        //Fade Out
        if(Time.time > 3.0f)
        {
            currentOpacity -= Time.deltaTime / timeToChange;
            splashColor.a = currentOpacity;
            splashImage.color = splashColor;
        }
        
        //Carregando o menu do jogo
        if(Time.time > 4.0f)
        {
            //Carregando proxima cena
            Application.LoadLevel("mainMenu");
        }
    }
}

