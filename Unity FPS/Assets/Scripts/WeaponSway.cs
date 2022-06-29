using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
  [SerializeField]
  private Transform weaponHolder;
  [Header("Sway Settings")]
  [SerializeField]
  private float _smoothness;
  [SerializeField]
  private float _swayMultiplier;

  private void Update()
  {
    float mouseX = Input.GetAxisRaw("Mouse X") * _swayMultiplier;
    float mouseY = Input.GetAxisRaw("Mouse Y") * _swayMultiplier;

    Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
    Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

    Quaternion targetRotation = rotationX * rotationY;

    weaponHolder.transform.localRotation = Quaternion.Slerp(weaponHolder.transform.localRotation, targetRotation, _smoothness * Time.deltaTime);
  }
}
