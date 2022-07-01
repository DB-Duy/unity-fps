using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
  public bool IsActive = false;

  private Transform _targetTransform;

  private AudioSource _hitAudio;

  private Renderer _renderer;
  private Collider _collider;


  private void Start()
  {
    SetActive(IsActive);
  }
  private void OnValidate()
  {
    _targetTransform = GetComponent<Transform>();
    _renderer = GetComponent<Renderer>();
    _hitAudio = GetComponent<AudioSource>();
    _collider = GetComponent<Collider>();
  }
  public void Hit()
  {
    if (!IsActive)
    {
      return;
    }
    else
    {
      SetActive(false);
      _hitAudio.Play();
    }
  }
  public void SetActive(bool status)
  {
    _renderer.enabled = status;
    _collider.enabled = status;
    IsActive = status;
  }

}
