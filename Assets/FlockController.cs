using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockController : MonoBehaviour
{
  private GameObject Player;
  public void SetPlayer(GameObject player)
  {
    Player = player;
    gameObject.GetComponent<FlockMovement>().SetPlayer(player);
  }
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
