using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PterodactylScript : MonoBehaviour
{
    private float timer = 0;
    public float timePeriod = 0;

    private float y;

    public SpriteRenderer mySpriteRenderer;
    public Sprite wingsUp;
    public Sprite wingsDown;

    public float moveSpeed = 1;

    private PolygonCollider2D colliderUp;
    private PolygonCollider2D colliderDown;

    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;

        colliderUp = transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>();
        colliderDown = transform.GetChild(1).gameObject.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timePeriod)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            // change sprite
            if (mySpriteRenderer.sprite == wingsUp)
            {
                mySpriteRenderer.sprite = wingsDown;
                transform.position = new Vector3(transform.position.x, y - (float) 0.421, 1);
            }
            else
            {
                mySpriteRenderer.sprite = wingsUp;
                transform.position = new Vector3(transform.position.x, y, 1);
            }
            // fix colliders
            colliderUp.enabled = !colliderUp.enabled;
            colliderDown.enabled = !colliderDown.enabled;

            // reset timer
            timer = 0;
        }

        // move to the side
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }
}
