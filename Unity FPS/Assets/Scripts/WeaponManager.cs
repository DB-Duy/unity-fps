using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
  [SerializeField]
  private Transform _camera;

  private float _range = 100;

  private void Update()
  {
    if (Input.GetButtonDown("Fire1"))
    {
      Shoot();
    }
  }

  private void Shoot()
  {
    if (Physics.Raycast(_camera.position, _camera.transform.forward, out RaycastHit hitInfo, _range))
    {
      Target target = hitInfo.transform.GetComponent<Target>();
      target?.Hit();
    }
  }
}
