using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;


        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;

        }
    }

}
