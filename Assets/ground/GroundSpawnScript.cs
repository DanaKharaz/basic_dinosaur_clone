using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnScript : MonoBehaviour
{
    public GameObject ground;
    public float spawnPeriod = 1;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnPeriod)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            // add ground
            spawn();

            // reset timer
            timer = 0;
        }
    }

    // adding ground
    void spawn()
    {
        Instantiate(ground, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }
}
