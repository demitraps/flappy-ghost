using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    const float MIN_ANGLE = -7;
    const float MAX_ANGLE = 5;

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
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !GameManager.gameOver)//checks for tapping on screen & if the game isn't over
        {
            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(rb.velocity.x, speed);

        }
        GhostRotation();
    }

    void GhostRotation() 
    {
        if(rb.velocity.y > 0)
        {  if (angle <= MAX_ANGLE)
        {
            angle += 0.5f;
        }
            
        } else if (rb.velocity.y < 0.5)
        {
            if (angle >= MIN_ANGLE)
            {
             angle -= 0.3f;
            }
            
        }
        if(!touchedGround)//rotate only if we have not touched the ground
        {
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
