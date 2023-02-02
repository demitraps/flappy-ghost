using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreControl : MonoBehaviour
{
    //variables for score and highscore;
    int score, highscore;
    //variable for TMPro object
    TextMeshProUGUI scoreText;
    //access PanelScore and PanelHighScore
    public TextMeshProUGUI panelScore, panelHighScore;
    //
    public GameObject newImg;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteKey("highscore"); //to reset highscore
        //set score to zero at game start
        score = 0;
        //get component TMPro and store it in scoreText
        scoreText = GetComponent<TextMeshProUGUI>();

        //set text of component to score *text expects string
        scoreText.text = score.ToString();
        //change panelScore.text
        panelScore.text = score.ToString();
        
        highscore = PlayerPrefs.GetInt("highscore");
        
        panelHighScore.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method must be public to be visible to GhostControl
    public void Scored()
    {
        //increase score
        score ++;
        //set text of component to score *text expects string
        scoreText.text = score.ToString();
        //set text of panel component to score
        panelScore.text = score.ToString();
        if(score > highscore)
        {
            highscore = score;
            panelHighScore.text = highscore.ToString();
            PlayerPrefs.SetInt("highscore", highscore);
            newImg.SetActive(true);
        } 
        

    }
}
