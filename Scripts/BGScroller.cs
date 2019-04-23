﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizedZ;

    private Vector3 startPosition;

  //  private ParticleSystem ps;
    


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        //ps = GetComponent<ParticleSystem>(StarField);
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizedZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (GameController.Instance.gameOver == true)
        {
            scrollSpeed = -20;
            float winPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizedZ);
            transform.position = startPosition + Vector3.forward * newPosition;

          //  simulationSpeed = -100;
        }
    }

}
