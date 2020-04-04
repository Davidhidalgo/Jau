using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockMovement : MonoBehaviour
{
  public GameObject Player;
  public float Force = 150;
  public float DistanceTrigger = 10;
  private float Distance;
  private Vector3 moveDirection;
  void Update()
  {
    Distance = Vector3.Distance(Player.transform.position, transform.position);
    Vector3 Direction = Player.transform.position - transform.position;
    moveDirection = -Direction.normalized * (Force * Time.deltaTime);
    moveDirection.y = 0;
    Quaternion newRotation = Quaternion.LookRotation(moveDirection);
    transform.rotation = newRotation;
    Gizmos.color = Color.blue;
    Gizmos.DrawSphere(transform.position, 40);
  }

  void FixedUpdate()
  {
    if (Distance < DistanceTrigger)
    {
      Rigidbody rb = GetComponent<Rigidbody>();
      rb.AddForce(moveDirection * (DistanceTrigger / Distance));
    }
    Debug.DrawLine(transform.position, transform.position + moveDirection, Color.red);
  }
}
