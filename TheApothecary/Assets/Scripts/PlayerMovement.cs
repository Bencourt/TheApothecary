using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer PlayerSprite;

    //player movement variables
    private float xVel;
    private float yVel;
    public float speed = 0.01f;
    public float accel = 0.0002f;


    private static GameObject playerInstance;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (playerInstance == null)
        {
            playerInstance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //set movement variables to default values
        xVel = 0.0f;
        yVel = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //call the move player function
        MovePlayer();
        UpdatePlayerSprite();
    }

    //move player default function
    public void MovePlayer()
    {
        //get input vector and normalize it
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            accel = .06f * Time.deltaTime;
            speed = 3f * Time.deltaTime;
        }
        else
        {
            accel = .03f * Time.deltaTime;
            speed = 2f * Time.deltaTime;
        }

        //check if x input received
        if (.1 < Mathf.Abs(inputVector.x))
        {
            //increase the xVel by accel until a maximum of +-speed
            xVel += inputVector.x * accel;
            xVel = Mathf.Clamp(xVel, -Mathf.Abs(inputVector.x * speed), Mathf.Abs(inputVector.x * speed));
        }
        //if no x input
        else
        {
            //decrease xVel and set to 0 if small enough
            xVel = xVel * .99f;
            if (Mathf.Abs(xVel) < .0000001f)
            {
                xVel = 0.0f;
            }
        }

        //check if y input received
        if (.1 < Mathf.Abs(inputVector.y))
        {
            //increase the yVel by accel unitl a maximum of +-speed
            yVel += inputVector.y * accel;
            yVel = Mathf.Clamp(yVel, -Mathf.Abs(inputVector.y * speed), Mathf.Abs(inputVector.y * speed));
        }
        //if no y input
        else
        {
            //decrease yVel and set to 0 if small enough
            yVel = yVel * .99f;
            if (Mathf.Abs(yVel) < .00000001f)
            {
                yVel = 0.0f;
            }
        }
        /*
        if (transform.position.x > 49.5f)
        {
            xVel = -.001f;
        }
        else if (transform.position.x < -49.5f)
        {
            xVel = .001f;
        }

        if (transform.position.y > 49.5f)
        {
            yVel = -.001f;
        }
        else if (transform.position.y < -49.5f)
        {
            yVel = .001f;
        }*/
        //update the player's transform with the x and y velocity
        transform.position = new Vector3(transform.position.x + xVel, transform.position.y + yVel);
    }

    public void UpdatePlayerSprite()
    {
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > .01f)
        {
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                PlayerSprite.flipX = true;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                PlayerSprite.flipX = false;
            }
        }
    }
}
