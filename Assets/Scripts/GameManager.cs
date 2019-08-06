﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private bool m_restartScoreIfBossTouchesPlayer = true;
    
    [SerializeField]
    private int m_timerTime = 90;

    private float m_player1Score;

    private float m_player2Score;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }
    }

    private void Start()
    {
        Initialize();
        InitializeUI();
    }

    /// <summary>
    /// Initializes Game Manager
    /// </summary>
    private void Initialize()
    {
        m_player1Score = 0;
        m_player2Score = 0;
    }

    /// <summary>
    ///  Initializes UI relation to GM
    /// </summary>
    private void InitializeUI()
    {
        UIManager.Instance.SetPlayersScores(m_player1Score, m_player2Score);
        UIManager.Instance.InitTimer(m_timerTime);
    }

    /// <summary>
    /// Called when boss touches a player
    /// </summary>
    /// <param name="player"></param>
    public void BossTouchedPlayer(Enumerations.Player player)
    {
        if(m_restartScoreIfBossTouchesPlayer)
        {
            switch (player)
            {
                case Enumerations.Player.Player1:
                    m_player1Score = 0;
                    UIManager.Instance.SetPlayer1Score(m_player1Score);
                    break;

                case Enumerations.Player.Player2:
                    m_player2Score = 0;
                    UIManager.Instance.SetPlayer1Score(m_player2Score);
                    break;
            }
        }
        else
        {
            // 
        }
    }
}
