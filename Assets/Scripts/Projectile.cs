using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class Projectile : MonoBehaviour
{
    public float damage;  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.tag == "Enemy")
        {
            other.GetComponent<Turret>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.tag == "Shield") {
            Destroy(gameObject);
        }
    }

}
