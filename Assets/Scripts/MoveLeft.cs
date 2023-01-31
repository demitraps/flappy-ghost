using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour

{
    float speed = 1;
    BoxCollider2D box;
    float groundWidth;

    //variable for width of arm taken from radius of circle collider on arm
    float armWidth;
    // Start is called before the first frame update
    void Start()
    {
        //check the object's tag
        //*MoveLeft is applied to multiple gameObjects
        if (gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
        groundWidth = box.size.x;
        } else if (gameObject.CompareTag("Arms"))
        {
            //use GameObject class's method FindGameObjectWithTag to isolate one of the two arms
            //the get the Component's Circle Collider 2D with the GetComponent method and get the radius
            //assign the radius as armWidth when the game starts
            armWidth = GameObject.FindGameObjectWithTag("SingleArm").GetComponent<CircleCollider2D>().radius;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gameOver)//checks if the game is over
        {
            //moves items to the left
        transform.position = new Vector2(
            transform.position.x - speed *Time.deltaTime, transform.position.y);
        }
        

            if(gameObject.CompareTag("Ground"))
            {
               if(transform.position.x <= -groundWidth)
               {
               transform.position = new Vector2(transform.position.x + groundWidth*2, transform.position.y);
               } 
            } else if (gameObject.CompareTag("Arms"))
            {
                //we compare the position of the object to the 0,0 position + width of arm
                //Game manager and bottom left are public so we can access them from MoveLeft
                if(transform.position.x < GameManager.bottomLeft.x-armWidth)
                {
                    //destroys object
                    Destroy(gameObject);

                }
            }


            
    }
}
