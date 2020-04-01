using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockMovement : MonoBehaviour
{
  public GameObject Player;
  public float Force = 150;
  private float DistanceTrigger = 10;
  private float Distance;
  private Vector3 moveDirection;
  void Update()
  {
    Distance = Vector3.Distance(Player.transform.position, transform.position);
    Vector3 Direction = Player.transform.position - transform.position;
    moveDirection = -Direction.normalized * (Force * Time.deltaTime);
  }

  void FixedUpdate()
  {
    if (Distance < DistanceTrigger)
    {
      Rigidbody rb = GetComponent<Rigidbody>();
      Debug.Log(DistanceTrigger / Distance);
      rb.AddForce(moveDirection * (DistanceTrigger / Distance));
    }
    Debug.DrawLine(transform.position, transform.position + moveDirection, Color.red);
  }
}
