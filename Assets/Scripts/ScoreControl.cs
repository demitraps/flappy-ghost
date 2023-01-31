using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreControl : MonoBehaviour
{
    //variable for score;
    int score;
    //variable for TMPro object
    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //set score to zero at game start
        score = 0;
        //get component TMPro and store it in scoreText
        scoreText = GetComponent<TextMeshProUGUI>();
        //set text of component to score *text expects string
        scoreText.text = score.ToString();
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
        

    }
}
