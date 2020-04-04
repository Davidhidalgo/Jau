using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour
{
  public GameObject MagnetPoint;
  public float Force = 200;
  private float Distance;
  private Vector3 moveDirection;

  void Update()
  {
    Distance = Vector3.Distance(MagnetPoint.transform.position, transform.position);
    Vector3 Direction = MagnetPoint.transform.position - transform.position;
    moveDirection = Direction.normalized * (Force * Time.deltaTime);
    // Quaternion newRotation = transform.rotation;
    // newRotation.y = MagnetPoint.transform.rotation.y;
    // transform.rotation = newRotation;
    // Debug.Log(newRotation);
  }

  void FixedUpdate()
  {
    Rigidbody rb = GetComponent<Rigidbody>();
    rb.AddForce(moveDirection * Distance);
  }

  public void SetMagnetPoint(GameObject mp)
  {
    MagnetPoint = mp;
  }
}
