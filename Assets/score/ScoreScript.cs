using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    //!!!flash when getting 100!!!

    private int hs1 = 0;
    private int hs2 = 0;
    private int hs3 = 0;
    private int hs4 = 0;

    private int cs1 = 0;
    private int cs2 = 0;
    private int cs3 = 0;
    private int cs4 = 0;

    // assign sprites
    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;
    private Sprite[] nums;

    // sprite renderers
    public SpriteRenderer srHS1;
    public SpriteRenderer srHS2;
    public SpriteRenderer srHS3;
    public SpriteRenderer srHS4;
    public SpriteRenderer srCS1;
    public SpriteRenderer srCS2;
    public SpriteRenderer srCS3;
    public SpriteRenderer srCS4;

    // changing score
    private float timer = 0;
    public float timePeriod = 1;

    // Start is called before the first frame update
    void Start()
    {
        nums = new Sprite[10];
        nums[0] = zero;
        nums[1] = one;
        nums[2] = two;
        nums[3] = three;
        nums[4] = four;
        nums[5] = five;
        nums[6] = six;
        nums[7] = seven;
        nums[8] = eight;
        nums[9] = nine;
        //Debug.Log(transform.GetChild(1).GetChild(3).gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        // current score
        if (timer < timePeriod)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            // increase current score
            if (cs1 == 9)
            {
                if (cs2 == 9)
                {
                    if (cs3 == 9)
                    {
                        if (cs4 == 9)
                        {
                            Debug.Log("Game Over");
                        }
                        else
                        {
                            cs4++;
                            cs3 = 0;
                            cs2 = 0;
                            cs1 = 0;
                        }
                    }
                    else
                    {
                        cs3++;
                        cs2 = 0;
                        cs1 = 0;
                    }
                }
                else
                {
                    cs2++;
                    cs1 = 0;
                }
            }
            else
            {
                cs1++;
            }

            // reset timer
            timer = 0;
        }

        // change highest score if needed
        if (cs1 + cs2 * 10 + cs3 * 100 + cs4 * 1000 > hs1 + hs2 * 10 + hs3 * 100 + hs4 * 1000)
        {
            hs1 = cs1;
            hs2 = cs2;
            hs3 = cs3;
            hs4 = cs4;
        }

        // display highest score
        srHS1.sprite = nums[hs1];
        srHS2.sprite = nums[hs2];
        srHS3.sprite = nums[hs3];
        srHS4.sprite = nums[hs4];

        // display current score
        srCS1.sprite = nums[cs1];
        srCS2.sprite = nums[cs2];
        srCS3.sprite = nums[cs3];
        srCS4.sprite = nums[cs4];

        //
    }
}
