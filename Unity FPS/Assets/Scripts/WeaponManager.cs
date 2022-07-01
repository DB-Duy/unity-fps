using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{
  [SerializeField]
  private Transform _camera;

  [SerializeField]
  private UnityEvent OnShoot;

  [SerializeField]
  private UnityEvent OnTargetHit;

  [SerializeField]
  private UnityEvent OnIdle;

  private AudioSource _gunShotAudio;

  private float _range = 100;


  private void OnValidate()
  {
    _gunShotAudio = GetComponent<AudioSource>();
  }
  private void Update()
  {
    if (Input.GetButtonDown("Fire1"))
    {
      Shoot();
    }
    else
    {
      OnIdle?.Invoke();
    }
  }

  private void Shoot()
  {
    ExecuteRaycast();
    PlayShootAudio();
    OnShoot?.Invoke();
  }

  private void PlayShootAudio()
  {
    _gunShotAudio.Play();
  }

  private void ExecuteRaycast()
  {
    if (Physics.Raycast(_camera.position, _camera.transform.forward, out RaycastHit hitInfo, _range))
    {
      Target target = hitInfo.transform.GetComponent<Target>();
      if (target != null)
      {
        target.Hit();
        OnTargetHit?.Invoke();
      }
    }
  }
}
