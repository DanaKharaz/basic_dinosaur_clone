using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMoveScript : MonoBehaviour
{
    public float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move ground
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        // delete ground out of frame
        if (transform.position.x < -12)
        {
            Debug.Log("Obsticle deleted");
            Destroy(gameObject);
        }        
    }
}
