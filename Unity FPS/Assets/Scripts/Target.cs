using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
  public bool IsVisible = false;

  private Transform _targetTransform;

  private AudioSource _hitAudio;

  private Renderer _renderer;


  private void Start()
  {
    SetVisible(IsVisible);
  }
  private void OnValidate()
  {
    _targetTransform = GetComponent<Transform>();
    _renderer = GetComponent<Renderer>();
    _hitAudio = GetComponent<AudioSource>();
  }
  public void Hit()
  {
    if (!IsVisible)
    {
      return;
    }
    else
    {
      SetVisible(false);
      _hitAudio.Play();
    }
  }
  public void SetVisible(bool status)
  {
    _renderer.enabled = status;
    IsVisible = status;
  }

}
