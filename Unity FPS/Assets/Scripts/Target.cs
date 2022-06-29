using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
  public bool IsVisible = false;

  [SerializeField]
  private Transform _targetTransform;

  private Renderer _renderer;


  private void OnValidate()
  {
    _targetTransform = GetComponent<Transform>();
    _renderer = GetComponent<Renderer>();
  }
  public void Hit()
  {
    Debug.Log("Target Hit!");
  }
  public void SetVisible(bool status)
  {
    _renderer.enabled = status;
  }
  private void Update()
  {
    SetVisible(IsVisible);
  }
}
