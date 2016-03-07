using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class randomizeColor : MonoBehaviour {

    private Text textObj;
    private Color textColor;

    // Use this for initialization
    void Start () {
        textObj = this.GetComponent<Text>();
	}

    //Metodo para gerar uma cor aleatoria
    Color RandomColor()
    {
        return new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }

    // Update is called once per frame
    void Update ()
    {
        //Colorindo o texto jogar
        textColor = RandomColor();
        textObj.color = textColor;
    }
}
