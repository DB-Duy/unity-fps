using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
  private ParticleSystem _muzzleFlash;
  [SerializeField]
  private Light _muzzleLight;

  private void OnValidate()
  {
    _muzzleFlash = GetComponent<ParticleSystem>();
  }
  public void DisplayMuzzleFlash()
  {
    _muzzleFlash.Play();
  }
}
