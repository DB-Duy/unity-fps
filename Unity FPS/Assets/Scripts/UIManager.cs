using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
  public UnityEvent OnCountdownFinished;
  [SerializeField]
  private GameModeManager _gameModeManager;
  [SerializeField]
  private float _countdownIncrement = 0.5f;
  [SerializeField]
  private GameObject _roundCompletePanel;
  [SerializeField]
  private GameObject _roundStartPanel;
  [SerializeField]
  private TMP_Text _scoreText;
  [SerializeField]
  private TMP_Text _timeText;

  public void Start()
  {
    _roundCompletePanel.SetActive(false);
    StartCoroutine(InitRound());
    DisplayRoundUI(false);
    EnableGameCursor();
  }

  private IEnumerator InitRound()
  {
    yield return PlayRoundStartCountdown();
    OnCountdownFinished?.Invoke();
    yield return null;
  }

  public IEnumerator PlayRoundStartCountdown()
  {
    _roundStartPanel.SetActive(true);
    WaitForSeconds wait = new WaitForSeconds(_countdownIncrement);
    for (int i = 3; i > 0; i--)
    {
      _roundStartPanel.GetComponentInChildren<TMP_Text>().text = i.ToString();
      yield return wait;
    }
    _roundStartPanel.SetActive(false);
    yield return null;
  }
  private void LateUpdate()
  {
    if (_gameModeManager.TimeLeft <= 0 && !_gameModeManager.IsPlaying)
    {
      DisplayRoundUI(false);
      DisplayRoundComplete(_gameModeManager.RoundScore, _gameModeManager.GetAccuracy());
    }
    else
    {
      UpdateTimeDisplay(_gameModeManager.TimeLeft);
      UpdateScoreDisplay(_gameModeManager.RoundScore);
    }
  }

  public void UpdateTimeDisplay(float time)
  {
    time = (int)time;
    _timeText.text = $"Time: {time.ToString()}";
  }
  public void UpdateScoreDisplay(float score)
  {
    _scoreText.text = $"Score: {score.ToString()}";
  }

  public void DisplayRoundComplete(int finalScore, float accuracy)
  {
    DisableGameCursor();
    _roundCompletePanel.SetActive(true);
    string roundEndText = $"Your final score: {finalScore}\nYour accuracy: {(accuracy.ToString("0.00"))}%";
    _roundCompletePanel.GetComponentInChildren<TMP_Text>().text = roundEndText;

  }

  private void DisableGameCursor()
  {
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
  }
  private void EnableGameCursor()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  public void HideRoundStartPanel()
  {
    _roundStartPanel.SetActive(false);
  }
  public void DisplayRoundUI(bool state)
  {
    _scoreText.enabled = state;
    _timeText.enabled = state;
  }
}
