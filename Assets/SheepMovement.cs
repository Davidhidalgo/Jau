using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour
{
  public float Force = 200;
  public GameObject Player;
  public GameObject MagnetPoint;
  private float Distance;
  private Vector3 moveDirection;

  void Update()
  {
    Distance = Vector3.Distance(MagnetPoint.transform.position, transform.position);
    Vector3 Direction = MagnetPoint.transform.position - transform.position;
    moveDirection = Direction.normalized * (Force * Time.deltaTime);
    transform.rotation = MagnetPoint.transform.rotation;
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
