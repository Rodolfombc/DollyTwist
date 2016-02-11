using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class menuBg_Animation : MonoBehaviour {

    
    public int framesPerSecond = 10;

    private Sprite sprite1, sprite2, sprite3, sprite4;
    private Sprite[] frames;

    void Start()
    {
        frames = new Sprite[4];
        sprite1 = Resources.Load<Sprite>("mainMenu/menuBg1");
        sprite2 = Resources.Load<Sprite>("mainMenu/menuBg2");
        sprite3 = Resources.Load<Sprite>("mainMenu/menuBg3");
        sprite4 = Resources.Load<Sprite>("mainMenu/menuBg4");
        frames[0] = sprite1;
        frames[1] = sprite2;
        frames[2] = sprite3;
        frames[3] = sprite4;
        //Debug.Log(sprite1);
    }

    // Update is called once per frame
    void Update ()
    {
        int index = (int)(Time.time * framesPerSecond) % frames.Length;
        if(this.GetComponent<Image>())
        {
            this.GetComponent<Image>().sprite = frames[index];
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = frames[index];
        }
        
    }
}
