using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // variable for position of bottom left corner
    //we make this variable public & static so it is available for other scripts
    public static Vector2 bottomLeft;

    //variable for gameOver, publicly accessed
    public static bool gameOver;
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
    }

    //public method that sets gameOver to true;
    public void GameOver() 
    {
        gameOver = true;
        print("GameOver");
    }


}
