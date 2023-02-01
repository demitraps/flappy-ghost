using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    //variable for accessing ghost's physics Rigidbody2D
    Rigidbody2D rb;
    //variable for ghost's upward speed when clicked
    //public so it can be accessed by Unity editor
    public float speed;

    //constant variables for min and max angle rotation of ghost when going down or up
    const float MIN_ANGLE = -9;
    const float MAX_ANGLE = 7;

    //angle of ghost when going up or down
    float angle = 0;

    //create a new object with class ScoreControl so we can call its method Scored()
    //public to have access from the editor
    public ScoreControl score;

    //create a new object with class GameManager so we can call its method GameOver()
    //public to have access from the editor
    public GameManager gameManager;

    //variable to check when ghost touches ground to pop up menu
    bool touchedGround;
    // Start is called before the first frame update
    void Start()
    {
        //get Component Rigidbody2D from ghost and assign it to rb at start
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetMouseButtonDown with 0 for right click/tap on screen
        if(Input.GetMouseButtonDown(0) && !GameManager.gameOver)//checks for tapping on screen & if the game isn't over
        {
            //velocity of ghost: it accepts Vector2 values and we null the existing values each time screen is tapped
            //new Vector2(0,0) is equal to Vector2.zero;
            rb.velocity = Vector2.zero;
            //set velocity it to the original velocity on x, and speed(which is controlled on Editor) on y
            rb.velocity = new Vector2(rb.velocity.x, speed);

        }
        //call Ghost Rotation method per frame
        GhostRotation();
    }

    //method to control ghost's rotation
    void GhostRotation() 
    {
        //positive velocity on y means the ghost goes upwards
        if(rb.velocity.y > 0)
        {  //as long as angle is smaller than the MAX_ANGLE we increase it by 0.5
            if (angle <= MAX_ANGLE)
        {
            angle += 0.5f;
        }
          //negative velocity on y means the ghost goes downwards  
        } else if (rb.velocity.y < 0.5)
        {   //as long as angle is bigger than the MIN_ANGLE we decrease it by 0.3f
            if (angle >= MIN_ANGLE)
            {
             angle -= 0.3f;
            }
            
        }
        if(!touchedGround)//rotate only if we have not touched the ground
        {
            //apply angle on rotation of ghost
            transform.rotation = Quaternion.Euler(0,0,angle);
        }

        


    

    }
    //check if collision is with object arms to log score
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Arms"))//collision with collider next to arms
        {
            //we call the method Scored() from object score
            score.Scored();
        } else if (collision.CompareTag("SingleArm"))//collision with either arm
        {
            //call GameOver method to set gameOver to true;
            gameManager.GameOver();
        }
    }

    //check collision with ground
    //cannot use Trigger as we do not want player to go through ground
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        
        if (collision.gameObject.CompareTag("Ground"))//we cannot have immediate access to CompareTag directly as in OnTrigger
        {
            //check if there was a collision with arm before hitting the ground
            if (!GameManager.gameOver)
            {
                gameManager.GameOver();
            } else
            {
                touchedGround = true;
            }

        }
    }
}
