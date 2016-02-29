using UnityEngine;
using UnityEngine.UI;

public class highscore : MonoBehaviour {

    public Text score;

    void OnMouseDown()
    {
        //Debug.Log("Ver scores");
        Application.LoadLevel("scores");
    }

    
    void Start () {
        score.text = PlayerPrefs.GetInt("score").ToString() + " metros";
    }
}
