using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//managing scenes
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // variable for position of bottom left corner
    //we make this variable public & static so it is available for other scripts
    public static Vector2 bottomLeft;

    //variable for gameOver, publicly accessed
    public static bool gameOver;
    //variable to check if game has started;
    public static bool gameHasStarted;
    //public variable for gameover panel/tomb menu to add from Unity Editor

    public static bool gameIsPaused;
    public GameObject gameOverPanel;
    //public variable for score object to add from Unity Editor
    public GameObject score;
    //
    public GameObject getReadyImg;
    // Awake is called before Start
    void Awake()
    {
        //access main Camera and convert pixels to Unity units
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        print(bottomLeft);
    }

    void Start() 
    {
        //setting gameOver false when the game starts
        gameOver = false;
        //setting gameHasStarted false when the game starts until click on screen
        gameHasStarted = false;
        //
        gameIsPaused = false;
    }

    //public method that sets gameOver to true;
    public void GameOver() 
    {
        gameOver = true;
        //enable tomb/menu panel
        gameOverPanel.SetActive(true);
        //disable score from top left
        score.SetActive(false);
    }


    //method to load the scene again
    public void OnOkBtnPressed()
    {
        //loads open scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void GameHasStarted()
    {
        //change variable to true when game starts
        gameHasStarted = true;
        //make score appear
        score.SetActive(true);
        getReadyImg.SetActive(false);
    }


}
