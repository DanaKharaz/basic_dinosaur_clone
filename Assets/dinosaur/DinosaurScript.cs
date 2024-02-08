using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float strength = 1;

    public SpriteRenderer mySpriteRenderer;
    public Sprite still;
    public Sprite running1;
    public Sprite running2;
    public Sprite dodging1;
    public Sprite dodging2;
    public Sprite dead;

    private PolygonCollider2D stillCollider;
    private PolygonCollider2D runCollider1;
    private PolygonCollider2D runCollider2;
    private PolygonCollider2D dodgeCollider1;
    private PolygonCollider2D dodgeCollider2;

    private bool running = true;
    private bool dodging = false;
    private bool jumping = false;

    private float timer = 0;
    public float timePeriod = 0;

    private bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        // define colliders
        stillCollider = transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>();
        runCollider1 = transform.GetChild(1).gameObject.GetComponent<PolygonCollider2D>();
        runCollider2 = transform.GetChild(2).gameObject.GetComponent<PolygonCollider2D>();
        dodgeCollider1 = transform.GetChild(3).gameObject.GetComponent<PolygonCollider2D>();
        dodgeCollider2 = transform.GetChild(4).gameObject.GetComponent<PolygonCollider2D>();

        // start motion
        mySpriteRenderer.sprite = running1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            gameOver();
        }
 
        // change sprite every n seconds
        if (timer < timePeriod)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            // change sprite
            if (jumping)
            {
                mySpriteRenderer.sprite = still;
                stillCollider.enabled = true;
                runCollider1.enabled = false;
                runCollider2.enabled = false;
                dodgeCollider1.enabled = false;
                dodgeCollider2.enabled = false;
            }
            else if (running)
            {
                if (mySpriteRenderer.sprite == running1)
                {
                    mySpriteRenderer.sprite = running2;
                    stillCollider.enabled = false;
                    runCollider1.enabled = false;
                    runCollider2.enabled = true;
                    dodgeCollider1.enabled = false;
                    dodgeCollider2.enabled = false;
                }
                else if (mySpriteRenderer.sprite == running2)
                {
                    mySpriteRenderer.sprite = running1;
                    stillCollider.enabled = false;
                    runCollider1.enabled = true;
                    runCollider2.enabled = false;
                    dodgeCollider1.enabled = false;
                    dodgeCollider2.enabled = false;
                }
                else
                {
                    mySpriteRenderer.sprite = running1;
                    stillCollider.enabled = false;
                    runCollider1.enabled = true;
                    runCollider2.enabled = false;
                    dodgeCollider1.enabled = false;
                    dodgeCollider2.enabled = false;
                }
            }
            else if (dodging)
            {
                if (mySpriteRenderer.sprite == dodging1)
                {
                    mySpriteRenderer.sprite = dodging2;
                    stillCollider.enabled = false;
                    runCollider1.enabled = false;
                    runCollider2.enabled = false;
                    dodgeCollider1.enabled = false;
                    dodgeCollider2.enabled = true;
                }
                else if (mySpriteRenderer.sprite == dodging2)
                {
                    mySpriteRenderer.sprite = dodging1;
                    stillCollider.enabled = false;
                    runCollider1.enabled = false;
                    runCollider2.enabled = false;
                    dodgeCollider1.enabled = true;
                    dodgeCollider2.enabled = false;
                }
            }
            
            // reset timer
            timer = 0;
        }

        // jump
        if (Input.GetKeyDown(KeyCode.Space) && !jumping && !dodging && active)
        {
            jumping = true;
            running = false;

            // change sprite
            mySpriteRenderer.sprite = still;
            stillCollider.enabled = true;
            runCollider1.enabled = false;
            runCollider2.enabled = false;
            dodgeCollider1.enabled = false;
            dodgeCollider2.enabled = false;
            // go up
            myRigidbody.velocity = Vector2.up * strength;
        }
        // when jump is finished
        if (transform.position.y < -2.1 && !dodging)
        {
            jumping = false;
            running = true;

            // change sprite
            mySpriteRenderer.sprite = running1;
            stillCollider.enabled = false;
            runCollider1.enabled = true;
            runCollider2.enabled = false;
            dodgeCollider1.enabled = false;
            dodgeCollider2.enabled = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad0) && !jumping && active)
        {
            dodging = true;
            transform.position = new Vector3((float) -7, (float) -2.475, 0);
            running = false;

            // dodge
            mySpriteRenderer.sprite = dodging1;
            stillCollider.enabled = false;
            runCollider1.enabled = false;
            runCollider2.enabled = false;
            dodgeCollider1.enabled = true;
            dodgeCollider2.enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Keypad0) && !jumping && active)
        {
            dodging = false;
            transform.position = new Vector3((float) -7, (float) -2.1, 0);
            running = true;

            // change sprite
            mySpriteRenderer.sprite = running1;
            stillCollider.enabled = false;
            runCollider1.enabled = true;
            runCollider2.enabled = false;
            dodgeCollider1.enabled = false;
            dodgeCollider2.enabled = false;
        }
    }

    //!!!collision!!!
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            jumping = false;
            running = false;
            dodging = false;
            active = false;

            mySpriteRenderer.sprite = dead;
            stillCollider.enabled = false;
            runCollider1.enabled = false;
            runCollider2.enabled = false;
            dodgeCollider1.enabled = false;
            dodgeCollider2.enabled = false;
        }
    }

    // end game
    void gameOver()
    {
        // change sprite
        mySpriteRenderer.sprite = dead;
        // freeze everything
        Time.timeScale = 0;

        // display game over screen
        //!!!show screen
        //!!!save high score if needed
    }
}
