using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlocksController : MonoBehaviour
{
  public GameObject SheepPrefab;
  public GameObject FlockPrefab;
  public GameObject SheepMagnetPoint;
  public GameObject Player;
  public int FlockSize = 1;

  private List<GameObject> Flocks = new List<GameObject>();
  private List<GameObject> Sheeps = new List<GameObject>();

  void Start()
  {
    AddNewFlock();
    InitSheeps();
  }

  void AddNewFlock()
  {
    GameObject NewFlock = Instantiate(FlockPrefab, transform.position, Quaternion.identity, gameObject.transform);
    NewFlock.GetComponent<FlockMovement>().SetPlayer(Player);
    Flocks.Add(NewFlock);
  }

  void InitSheeps()
  {
    GameObject InitialFlock = Flocks[0];
    for (int i = 0; i < FlockSize; i++)
    {
      Vector3 Position = new Vector3(transform.position.x, 1, transform.position.z);
      GameObject NewSheep = Instantiate(SheepPrefab, Position, Quaternion.identity);
      GameObject MagnetPoint = Instantiate(SheepMagnetPoint, transform.position, Quaternion.identity, InitialFlock.transform);
      NewSheep.GetComponent<SheepMovement>().SetMagnetPoint(MagnetPoint);
      Sheeps.Add(NewSheep);
    }
  }
}
