using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour

{
    //variable speed of ground moving to the left
    float speed = 1;
    //variable of ground's box collider so we can access its size on the x
    BoxCollider2D box;
    //variable to assign the size
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
            //assign component of BoxCollider2D to box
            box = GetComponent<BoxCollider2D>();
            //assign size.x of box collider to groundWidth
            groundWidth = box.size.x;
        } else if (gameObject.CompareTag("Arms"))
        {
            //use GameObject class's method FindGameObjectWithTag to isolate one of the two arms
            //then get the Component's Circle Collider 2D with the GetComponent method and get the radius
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
            //position of item will be:
            //on the x axis: the current position minus the speed(we are moving to the left)*Time.deltaTime
            //on the y axis: the current position
        transform.position = new Vector2(
            transform.position.x - speed *Time.deltaTime, transform.position.y);
        }
        

            if(gameObject.CompareTag("Ground"))
            {
                //return to original position
                //check if it has moved past its size we want to move it back
               if(transform.position.x <= -groundWidth)
               {
                //move it to the right two spots
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
