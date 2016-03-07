using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System;
using System.Text;

public class internet_connection : MonoBehaviour {

    private string url = "http://rmbcdev.comli.com/teste.php?score=";

    public Text scoreText;

    private string filename;

    void Start () {
        url += PlayerPrefs.GetInt("score").ToString();

        scoreText.text = "Conectando...";

        filename = "scores.txt";

        //Uploading scores
        //StartCoroutine(UploadScores());

        StartCoroutine(GetScores());
    }

    private IEnumerator GetScores()
    {
        WWW file = new WWW(url);

        yield return file;


        if (file.error != null)
        {
            //Debug.Log("Error .. " + file.error);
            scoreText.text = "Erro: Falha de conexão!";
            // for example, often 'Error .. 404 Not Found'
        }
        else
        {
            Debug.Log(file.text);
            scoreText.text = file.text;
        }
    }
    
}

