using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTurn : MonoBehaviour
{
    public float speed;
    GameObject player;
    GameObject wheel1;
    GameObject wheel2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wheel1 = transform.GetChild(0).gameObject;
        wheel2 = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (player.GetComponent<UNGA>().p1Arm == 1) {
            wheel1.transform.rotation = Quaternion.RotateTowards(wheel1.transform.rotation, Quaternion.Euler(0, 0, 0),step);
        }
        if (player.GetComponent<UNGA>().p1Arm == 2)
        {
            wheel1.transform.rotation = Quaternion.RotateTowards(wheel1.transform.rotation, Quaternion.Euler(0, 0, 120), step);
        }
        if (player.GetComponent<UNGA>().p1Arm == 3)
        {
            wheel1.transform.rotation = Quaternion.RotateTowards(wheel1.transform.rotation, Quaternion.Euler(0, 0, 240), step);
        }
        if (player.GetComponent<UNGA>().p2Arm == 1)
        {
            wheel2.transform.rotation = Quaternion.RotateTowards(wheel2.transform.rotation, Quaternion.Euler(0, 0, 0), step);
        }
        if (player.GetComponent<UNGA>().p2Arm == 2)
        {
            wheel2.transform.rotation = Quaternion.RotateTowards(wheel2.transform.rotation, Quaternion.Euler(0, 0, -120), step);
        }
        if (player.GetComponent<UNGA>().p2Arm == 3)
        {
            wheel2.transform.rotation = Quaternion.RotateTowards(wheel2.transform.rotation, Quaternion.Euler(0, 0, -240), step);
        }

    }
}
