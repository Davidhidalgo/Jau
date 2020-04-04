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
  private List<GameObject> FlocksList = new List<GameObject>();
  private List<GameObject> SheepList = new List<GameObject>();
  private List<GameObject> MagnetPointList = new List<GameObject>();

  void Start()
  {
    GameObject firstFlock = AddNewFlock();
    InitSheeps();
    AsignMagnetPointsToFlock(MagnetPointList, firstFlock);
  }

  void AsignMagnetPointsToFlock(List<GameObject> MagnetPoints, GameObject Flock)
  {
    Flock.GetComponent<FlockController>().AsignMagnetPoints(MagnetPoints);
  }

  GameObject AddNewFlock()
  {
    GameObject NewFlock = Instantiate(FlockPrefab, transform.position, Quaternion.identity, gameObject.transform);
    NewFlock.GetComponent<FlockController>().SetPlayer(Player);
    FlocksList.Add(NewFlock);

    return NewFlock;
  }

  void InitSheeps()
  {
    for (int i = 0; i < FlockSize; i++)
    {
      Vector3 Position = new Vector3(transform.position.x, 1, transform.position.z);
      GameObject NewSheep = Instantiate(SheepPrefab, Position, Quaternion.identity);
      GameObject MagnetPoint = Instantiate(SheepMagnetPoint, transform.position, Quaternion.identity);
      NewSheep.GetComponent<SheepMovement>().SetMagnetPoint(MagnetPoint);
      SheepList.Add(NewSheep);
      MagnetPointList.Add(MagnetPoint);
    }
  }
}
