using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public bool inRange;
    public float fireCooldown;
    public float projectileSpeed;
    public float rotationSpeed;
    public GameObject projectile;
    GameObject player;
    bool canFire = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.transform.position -transform.position, out hit, Mathf.Infinity)) {
            Debug.DrawRay(transform.position, (player.transform.position - transform.position) * hit.distance, Color.red);
            if (hit.collider.tag == "Player")
            {
                inRange = true;
            }
            else {
                inRange = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && inRange == true)
        {
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(player.transform.position - transform.position), Time.deltaTime * rotationSpeed);
            Quaternion targetRotation = Quaternion.LookRotation( player.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            if (canFire == true) {
                StartCoroutine(Fire());
            }
        }
    }

    IEnumerator Fire() {
        canFire = false;
        var bullet = (GameObject)Instantiate(projectile, transform.GetChild(2).position,transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * projectileSpeed;
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }

}

