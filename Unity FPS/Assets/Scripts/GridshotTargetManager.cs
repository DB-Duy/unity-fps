using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridshotTargetManager : TargetManager
{
  [SerializeField]
  private int _targetCount = 3;
  [SerializeField]
  private int _randomSeed = 0;

  private bool _disabled = true;

  private Target[] _targets;

  private Target _nextTarget;

  override public void Initialize()
  {
    _disabled = false;
    Random.InitState(_randomSeed);
    _targets = FindObjectsOfType<Target>();

    _nextTarget = GetRandomTarget();

    InitializeRandomTargets();
  }

  private void InitializeRandomTargets()
  {
    Target[] targets = GetRandomTargets(_targetCount);

    for (int i = 0; i < targets.Length; i++)
    {
      targets[i].SetActive(true);
    }

  }

  private Target[] GetRandomTargets(int targetNum)
  {
    if (targetNum < _targetCount)
    {
      return new Target[] { _targets[0] };
    }

    List<Target> targetList = new List<Target>();

    List<int> indexes = new List<int>();
    for (int i = 0; i < _targets.Length; i++)
    {
      indexes.Add(i);
    }
    for (int i = 0; i < targetNum; i++)
    {
      int randIndex = indexes[Random.Range(0, indexes.Count)];
      targetList.Add(_targets[randIndex]);
      indexes.Remove(randIndex);
    }
    return targetList.ToArray();
  }

  private Target GetRandomTarget()
  {
    return _targets[Random.Range(0, _targets.Length)];
  }

  private void Update()
  {
    if (_disabled)
    {
      return;
    }

    if (VisibleTargetsCount() < _targetCount)
    {
      _nextTarget.SetActive(true);
    }
    while (_nextTarget.IsActive)
    {
      _nextTarget = GetRandomTarget();
    }
  }
  private int VisibleTargetsCount()
  {
    int visibleCount = 0;
    for (int i = 0; i < _targets.Length; i++)
    {
      if (_targets[i].IsActive)
      {
        visibleCount++;
      }
    }
    return visibleCount;
  }
  override public void EndRound()
  {
    _disabled = true;
    for (int i = 0; i < _targets.Length; i++)
    {
      _targets[i].SetActive(false);
    }
  }
}
