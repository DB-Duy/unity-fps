using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
  [SerializeField]
  private Animator _animator;

  private int IsShootingHash = Animator.StringToHash("IsShooting");

  public void PlayShootAnim()
  {
    _animator.SetBool(IsShootingHash, true);
  }
  public void PlayIdleAnim()
  {
    _animator.SetBool(IsShootingHash, false);
  }
}
