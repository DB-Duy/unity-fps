using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameModeManager : MonoBehaviour
{
  [SerializeField]
  private float _roundTimeInSeconds = 30;
  public int _roundScore
  {
    private set; get;
  } = 0;

  public bool _isPlaying = true;

  private float _startTime;

  [SerializeField]
  private GameObject _roundCompletePanel;

  [SerializeField]
  private TMP_Text _scoreText;
  [SerializeField]
  private TMP_Text _timeText;

  private void Start()
  {
    _startTime = Time.time;
  }
  private void Update()
  {
    if (!_isPlaying)
    {
      return;
    }
    UpdateScore();
    UpdateTime();
  }
  private void UpdateScore()
  {
    _scoreText.text = $"Score: {_roundScore}";
  }
  private void UpdateTime()
  {
    int TimeLeft = Mathf.CeilToInt(_roundTimeInSeconds - (Time.time - _startTime));
    _timeText.text = $"Time: {(TimeLeft)}";

    if (TimeLeft <= 0)
    {
      _isPlaying = false;
      DisplayRoundComplete();
    }
  }

  private void DisplayRoundComplete()
  {
    _roundCompletePanel.SetActive(true);
    _roundCompletePanel.GetComponentInChildren<TMP_Text>().text = $"Your final score: {_roundScore}";
  }

  public void IncrementScore()
  {
    _roundScore++;
  }
}
