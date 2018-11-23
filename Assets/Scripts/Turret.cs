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
    bool canSee;
    LineRenderer lr;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = transform.GetChild(2).GetComponent<Animator>();
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.transform.position -transform.position, out hit, Mathf.Infinity)) {
            Debug.DrawRay(transform.position, (player.transform.position - transform.position) * hit.distance, Color.red);
            if (hit.collider.tag == "Player")
            {
                canSee = true;
            }
            else {
                canSee = false;
            }
        }

        if (inRange && canSee == true)
        {
            lr.enabled = true;
            anim.SetBool("active", true);
            Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            if (canFire == true)
            {
                StartCoroutine(Fire());
            }
        }
        else {
            anim.SetBool("active", false);
            lr.enabled = false;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && canSee == true)
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            inRange = false;
        }
    }

    public void TakeDamage(float damage) {
        hp -= damage;
        if(hp <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
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

