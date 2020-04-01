using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockMovement : MonoBehaviour
{
  public Rigidbody rb;
  public GameObject Player;
  public float Force = 150;
  private float DistanceTrigger = 5;
  void Update()
  {
    float Distance = Vector3.Distance(Player.transform.position, transform.position);
    Vector3 Direction = Player.transform.position - transform.position;
    Vector3 DirectionApplied = -Direction.normalized * (Force * Time.deltaTime);
    Debug.Log(Distance);
    Debug.Log(DistanceTrigger);
    if (Distance < DistanceTrigger)
    {
      rb.AddForce(DirectionApplied);
    }
    Debug.DrawLine(transform.position, transform.position + DirectionApplied, Color.red);
  }
}
