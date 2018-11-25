using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().pitch = Random.Range(0.75f, 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
