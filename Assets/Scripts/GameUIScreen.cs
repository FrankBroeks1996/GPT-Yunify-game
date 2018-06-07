using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIScreen : MonoBehaviour {

    public Text ScoreText;
	
	// Update is called once per frame
	void Update () {
        string text = "";

        foreach (GameObject player in GameManagerScript.instance.PlayerUnits)
        {
            int score = player.GetComponent<PlayerStatsScript>().Score;
            text += "Score: " + score + "\n";
        }

        ScoreText.text = text;
	}
}
