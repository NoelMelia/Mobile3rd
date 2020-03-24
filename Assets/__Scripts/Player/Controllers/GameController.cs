using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
     // == public fields ==
    public int StartingLives
    {
        get { return startingLives; }
    }


    // == private fields ==
    private int playerScore = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private int startingLives = 3;
    private int remainingLives;

    // == private methods ==
    private void Awake()
    {
        SetupSingleton();
    }
    private void Start()
    {
        UpdateScore();
        remainingLives = startingLives;
    }

    private void SetupSingleton()
    {
        // this method gets called on creation
        // check for any other objects of the same type
        // if there is one, then use that one.
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);    // destroy the current object
        }
        else
        {
            // keep the new one
            DontDestroyOnLoad(gameObject);  // persist across scenes
        }
    }

    private void OnEnable()
    {
        Enemy.EnemyKilledEvent += OnEnemyKilledEvent;
    }
    private void OnDisable()
    {
        Enemy.EnemyKilledEvent -= OnEnemyKilledEvent;
    }

    private void OnEnemyKilledEvent(Enemy enemy)
    {
        // add the score value for the enemy to the player score
        playerScore += enemy.ScoreValue;
        UpdateScore();
    }

    private void UpdateScore()
    {
        //Debug.Log("Score: " + playerScore);
        // display on screen
        scoreText.text = playerScore.ToString();
    }

    public void LoseOneLife()
    {
        remainingLives--;
    }


}
