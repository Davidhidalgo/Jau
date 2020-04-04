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
  private List<GameObject> SheepsList = new List<GameObject>();

  void Start()
  {
    GameObject firstFlock = AddNewFlock();
    InitSheeps();
    AsignSheepsToFlock(SheepsList, firstFlock);
  }

  void AsignSheepsToFlock(List<GameObject> Sheeps, GameObject Flock)
  {
    Flock.GetComponent<FlockController>().AsignSheeps(Sheeps);
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
      SheepsList.Add(NewSheep);
    }
  }
}
