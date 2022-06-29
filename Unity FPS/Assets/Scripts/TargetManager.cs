using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetManager : MonoBehaviour
{
  [SerializeField]
  private int _targetNumbers = 3;

  //   [SerializeField]
  //   private GameObject _targetPrefab;

  private Target[] _targets;


  private void Start()
  {
    _targets = FindObjectsOfType<Target>();
  }

  private void InitializeRandomTargets()
  {


  }

  private Target[] GetRandomTargets(int targetNum)
  {
    if (targetNum < _targetNumbers)
    {
      return new Target[] { _targets[0] };
    }

    List<Target> targetList = new List<Target>();


    List<int> indexes = new List<int>();
    for (int i = 0; i < _targetNumbers; i++)
    {
      indexes.Add(i);
    }

    //Continue here

    return targetList.ToArray();
  }
  private void Update()
  {

  }

  private int VisibleTargets()
  {
    int visibleCount = 0;
    for (int i = 0; i < _targets.Length; i++)
    {
      if (_targets[i].IsVisible)
      {
        visibleCount++;
      }
    }
    return visibleCount;
  }
}
