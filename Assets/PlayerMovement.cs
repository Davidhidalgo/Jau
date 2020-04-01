using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float Force = 800f;

  void Update()
  {
    Rigidbody rb = GetComponent<Rigidbody>();
    if (Input.GetKey("w"))
    {
      rb.AddForce(0, 0, Force * Time.deltaTime);
    }
    if (Input.GetKey("s"))
    {
      rb.AddForce(0, 0, -Force * Time.deltaTime);
    }
    if (Input.GetKey("d"))
    {
      rb.AddForce(Force * Time.deltaTime, 0, 0);
    }
    if (Input.GetKey("a"))
    {
      rb.AddForce(-Force * Time.deltaTime, 0, 0);
    }
  }
}
