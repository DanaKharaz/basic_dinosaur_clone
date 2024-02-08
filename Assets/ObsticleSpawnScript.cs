using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawnScript : MonoBehaviour
{
    // game objects
    public GameObject pterodactyl;
    public GameObject oneCactusS1;
    public GameObject oneCactusS2;
    public GameObject oneCactusS3;
    public GameObject oneCactusT1;
    public GameObject oneCactusT2;
    public GameObject oneCactusT3;
    public GameObject oneCactusT4;
    public GameObject oneCactusT5;
    public GameObject twoCactiiS1;
    public GameObject twoCactiiS2;
    public GameObject twoCactiiT1;
    public GameObject twoCactiiT2;
    public GameObject threeCactiiS;
    public GameObject threeCactiiT;
    public GameObject fourCactii;

    // object creation
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

    // adding an obsticle
    void spawn()
    {
        int n = (int) Mathf.Round(Random.Range(0, 16));
        if (n == 1)
        {
            Instantiate(oneCactusS1, new Vector3(transform.position.x, (float) -2.385, transform.position.z), transform.rotation);
        }
        else if (n == 2)
        {
            Instantiate(oneCactusS2, new Vector3(transform.position.x, (float) -2.385, transform.position.z), transform.rotation);
        }
        else if (n == 3)
        {
            Instantiate(oneCactusS3, new Vector3(transform.position.x, (float) -2.385, transform.position.z), transform.rotation);
        }
        else if (n == 4)
        {
            Instantiate(oneCactusT1, new Vector3(transform.position.x, (float) -1.8, transform.position.z), transform.rotation);
        }
        else if (n == 5)
        {
            Instantiate(oneCactusT2, new Vector3(transform.position.x, (float) -1.85, transform.position.z), transform.rotation);
        }
        else if (n == 6)
        {
            Instantiate(oneCactusT3, new Vector3(transform.position.x, (float) -1.8, transform.position.z), transform.rotation);
        }
        else if (n == 7)
        {
            Instantiate(oneCactusT4, new Vector3(transform.position.x, (float) -1.85, transform.position.z), transform.rotation);
        }
        else if (n == 8)
        {
            Instantiate(oneCactusT5, new Vector3(transform.position.x, (float) -1.8, transform.position.z), transform.rotation);
        }
        else if (n == 9)
        {
            Instantiate(twoCactiiS1, new Vector3(transform.position.x,  (float) -2.385, transform.position.z), transform.rotation);
        }
        else if (n == 10)
        {
            Instantiate(twoCactiiS2, new Vector3(transform.position.x,  (float) -2.385, transform.position.z), transform.rotation);
        }
        else if (n == 11)
        {
            Instantiate(twoCactiiT1, new Vector3(transform.position.x, (float) -1.8, transform.position.z), transform.rotation);
        }
        else if (n == 12)
        {
            Instantiate(twoCactiiT2, new Vector3(transform.position.x, (float) -1.8, transform.position.z), transform.rotation);
        }
        else if (n == 13)
        {
            Instantiate(threeCactiiS, new Vector3(transform.position.x,  (float) -2.385, transform.position.z), transform.rotation);
        }
        else if (n == 14)
        {
            Instantiate(threeCactiiT, new Vector3(transform.position.x, (float) -1.8, transform.position.z), transform.rotation);
        }
        else if (n == 15)
        {
            Instantiate(fourCactii, new Vector3(transform.position.x, (float) -1.8, transform.position.z), transform.rotation);
        }
        else
        {
            if ((int) Mathf.Round(Random.Range(0, 2)) % 2 == 0)
            {
                Instantiate(pterodactyl, new Vector3(transform.position.x, (float) -1.3, transform.position.z), transform.rotation);
            }
            else
            {
                Instantiate(pterodactyl, new Vector3(transform.position.x, (float) -0.2, transform.position.z), transform.rotation);
            }
        }
    }
}
