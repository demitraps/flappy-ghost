using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsSpawner : MonoBehaviour
{
    //variable for arms prefab
    public GameObject arm;
    //variable for the max and min height of arms - will be set within the editor
    public float maxY, minY;
    //variable for random position of arms
    float randY; 

    //variable of how often the arms will respawn in seconds
    public float maxTime;
    // variable for timer that starts at 0 and increases up to maxTime
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   //add the time difference between frames to the timer
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            if(!GameManager.gameOver && GameManager.gameHasStarted)//check if is not game over and game has started
            {
                //respawn arm
            InstantiateArm();
            //reset timer
            timer =0;
            } 
        }
    }

    //method for creating a copy of an arm and setting its position
    public void InstantiateArm()
    {
        //Random.Range provides a random number between 2 numbers provided
        randY = Random.Range(minY, maxY);
        //Instantiate creates a copy of prefab arm, which we assign to newArm
        GameObject newArm = Instantiate(arm);
        //set newArm position: x the x of ArmsSpawner, y the randy
        newArm.transform.position = new Vector2(transform.position.x, randY); //transform.position.x refers to the position x of the ArmsSpawner (the object of this script)


    }
}
