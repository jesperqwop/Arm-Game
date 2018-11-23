using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float hp;
    public bool inRange;
    public float fireCooldown;
    public float projectileSpeed;
    public float rotationSpeed;
    public GameObject projectile;
    public GameObject explosion;
    GameObject player;
    Animator anim;
    bool canFire = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = transform.GetChild(2).GetComponent<Animator>();
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
            anim.SetBool("New Bool",true);
            Quaternion targetRotation = Quaternion.LookRotation( player.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            if (canFire == true) {
                StartCoroutine(Fire());
            }
        }
    }

    public void TakeDamage(float damage) {
        hp -= damage;
    }

    IEnumerator Fire() {
        canFire = false;
        var bullet = (GameObject)Instantiate(projectile, transform.GetChild(1).position,transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * projectileSpeed;
        Destroy(bullet, 2);
        yield return new WaitForSeconds(fireCooldown);
        canFire = true;
    }

}

