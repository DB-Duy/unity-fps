using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameModeManager : MonoBehaviour
{
  [SerializeField]
  private TargetManager _targetManager;
  [SerializeField]
  public float _roundTimeInSeconds = 30;

  [HideInInspector]
  public int RoundScore
  {
    private set; get;
  } = 0;
  [HideInInspector]
  public int ShotsFired = 0;

  [HideInInspector]
  public bool IsPlaying = false;
  [HideInInspector]
  public float StartTime;
  [HideInInspector]
  public float TimeLeft;


  [SerializeField]
  private TMP_Text _scoreText;
  [SerializeField]
  private TMP_Text _timeText;

  public void StartNewRound()
  {
    _targetManager.Initialize();
    RoundScore = 0;
    ShotsFired = 0;
    StartTime = Time.time;
    IsPlaying = true;
  }

  private void Update()
  {
    UpdateTimeLeft();
    if (TimeLeft <= 0)
    {
      EndRound();
    }
  }

  private void UpdateTimeLeft()
  {
    if (!IsPlaying)
    {
      TimeLeft = _roundTimeInSeconds;
    }
    else
    {
      TimeLeft = Mathf.CeilToInt(_roundTimeInSeconds - (Time.time - StartTime));
    }
  }

  public float GetAccuracy()
  {
    float accuracy = 0f;
    if (ShotsFired == 0)
    {
      accuracy = 0f;
    }
    else
    {
      accuracy = ((float)RoundScore / (float)ShotsFired) * 100;
    }
    return accuracy;
  }

  public void IncrementScore()
  {
    if (IsPlaying)
    {
      RoundScore++;
    }
  }
  public void IncrementShotsFired()
  {
    if (IsPlaying)
    {
      ShotsFired++;
    }
  }
  public void EndRound()
  {
    IsPlaying = false;
    _targetManager.EndRound();
  }

}
