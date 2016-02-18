using UnityEngine;
using System.Collections;

public class player_gameOver : MonoBehaviour {

	void Start () {
        this.GetComponent<Animator>().Play("player_death");
    }

}
