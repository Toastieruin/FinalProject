using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    private ParticleSystem ps;


    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (GameController.Instance.gameOver == true)
        {
            var main = ps.main;
            main.simulationSpeed = 100;
        }
    }
}
