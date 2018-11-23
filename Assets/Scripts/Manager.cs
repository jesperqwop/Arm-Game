using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject hpBar;
    public GameObject player;
    int hp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.GetComponent<Slider>().value = player.GetComponent<PlayerHealth>().hp;
        if (Input.GetKeyDown("r")) {
            SceneManager.LoadScene(1);
        }
    }
}
