using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazardFloor : MonoBehaviour
{
    bool shock = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(shock == true)
            {
                StartCoroutine("Damage",other.gameObject);
            }
        }
    }

    IEnumerator Damage(GameObject player)
    {
        shock = false;
        player.GetComponent<PlayerHealth>().hp -= 1;
        yield return new WaitForSeconds(0.5f);
        shock = true;
    }

}
