using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    int current;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, Time.deltaTime * speed);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else {
            current = (current + 1) % target.Length;
        }
    }
}
