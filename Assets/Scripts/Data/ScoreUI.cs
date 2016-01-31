using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreUI : MonoBehaviour {
    Text scoreText;
	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        string tempScore = GameData.Score.ToString();
        var stringLength = tempScore.Length;
        if(stringLength != 7)
        {
            var diff = 7 - stringLength;
            for (int i = 0; i <= diff; i++)
                tempScore = "0" + tempScore;

            tempScore = "$" + tempScore;
            scoreText.text = tempScore;
        }
	}
}
