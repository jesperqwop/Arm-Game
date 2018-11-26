using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelTurn : MonoBehaviour
{
    public Sprite[] sprites;
    GameObject player;
    GameObject attack1;
    GameObject jump1;
    GameObject shield1;
    GameObject attack2;
    GameObject jump2;
    GameObject shield2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attack1 = transform.GetChild(0).gameObject;
        jump1 = transform.GetChild(1).gameObject;
        shield1 = transform.GetChild(2).gameObject;
        attack2 = transform.GetChild(3).gameObject;
        jump2 = transform.GetChild(4).gameObject;
        shield2 = transform.GetChild(5).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if(player.GetComponent<UNGA>().p1Arm == 1)
        {
            attack1.GetComponent<Image>().sprite = sprites[1];
            jump1.GetComponent<Image>().sprite = sprites[2];
            shield1.GetComponent<Image>().sprite = sprites[4];
        }
        if (player.GetComponent<UNGA>().p1Arm == 2)
        {
            attack1.GetComponent<Image>().sprite = sprites[0];
            jump1.GetComponent<Image>().sprite = sprites[3];
            shield1.GetComponent<Image>().sprite = sprites[4];
        }
        if (player.GetComponent<UNGA>().p1Arm == 3)
        {
            attack1.GetComponent<Image>().sprite = sprites[0];
            jump1.GetComponent<Image>().sprite = sprites[2];
            shield1.GetComponent<Image>().sprite = sprites[5];
        }
        if (player.GetComponent<UNGA>().p2Arm == 1)
        {
            attack2.GetComponent<Image>().sprite = sprites[1];
            jump2.GetComponent<Image>().sprite = sprites[2];
            shield2.GetComponent<Image>().sprite = sprites[4];
        }
        if (player.GetComponent<UNGA>().p2Arm == 2)
        {
            attack2.GetComponent<Image>().sprite = sprites[0];
            jump2.GetComponent<Image>().sprite = sprites[3];
            shield2.GetComponent<Image>().sprite = sprites[4];
        }
        if (player.GetComponent<UNGA>().p2Arm == 3)
        {
            attack2.GetComponent<Image>().sprite = sprites[0];
            jump2.GetComponent<Image>().sprite = sprites[2];
            shield2.GetComponent<Image>().sprite = sprites[5];
        }

        }
}
