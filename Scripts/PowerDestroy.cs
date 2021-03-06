﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDestroy : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' scrip");
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Boundary" || other.tag == "PowerUp" || other.tag == "Player")
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        Destroy(other.gameObject);
    }
}
