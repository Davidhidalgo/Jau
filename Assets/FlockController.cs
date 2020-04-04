using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockController : MonoBehaviour
{
  public float Force = 150;
  public float DistanceTrigger = 10;
  private GameObject Player;
  private float Distance;
  private Vector3 moveDirection;
  private List<GameObject> MagnetPointsList;

  void Update()
  {
    CalcRepelPlayer();
  }

  void FixedUpdate()
  {
    RepelPlayer();
  }

  public void SetPlayer(GameObject player)
  {
    Player = player;
  }

  void CalcRepelPlayer()
  {
    Distance = Vector3.Distance(Player.transform.position, transform.position);
    Vector3 Direction = Player.transform.position - transform.position;
    moveDirection = -Direction.normalized * (Force * Time.deltaTime);
    moveDirection.y = 0;
    Quaternion newRotation = Quaternion.LookRotation(moveDirection);
    transform.rotation = newRotation;
    Gizmos.color = Color.blue;
  }

  void RepelPlayer()
  {
    if (Distance < DistanceTrigger)
    {
      Rigidbody rb = GetComponent<Rigidbody>();
      rb.AddForce(moveDirection * (DistanceTrigger / Distance));
    }
    Debug.DrawLine(transform.position, transform.position + moveDirection, Color.red);
  }

  public void AsignMagnetPoints(List<GameObject> MagnetPoints)
  {
    MagnetPointsList = MagnetPoints;
    foreach (GameObject MagnetPoint in MagnetPoints)
    {
      MagnetPoint.transform.parent = gameObject.transform;
    }
    ReorganizeMagnetPoints();
  }

  void ReorganizeMagnetPoints()
  {

  }
}