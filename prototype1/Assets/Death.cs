﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity SceneManagement is important to include if there is a function that called a change in scenes.
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject Player;
    // Score from the Food script
    public int Score
    {
        get { return Score; }
        set { Score = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    // When the sanke touches its own tail = Game over screen & resets the score to zero
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            // Game Over screen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            // Reset the score to zero
            Food.Score = 0;
        }
    }
}
