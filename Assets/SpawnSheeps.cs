using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSheeps : MonoBehaviour
{
  public GameObject SheepPrefab;
  public GameObject SheepMagnetPoint;
  public int Size = 1;

  void Start()
  {
    for (int i = 0; i < Size; i++)
    {
      Vector3 Position = new Vector3(transform.position.x, 1, transform.position.z);
      GameObject Sheep = Instantiate(SheepPrefab, Position, Quaternion.identity);
      GameObject MagnetPoint = Instantiate(SheepMagnetPoint, transform.position, Quaternion.identity, gameObject.transform);
      Sheep.GetComponent<SheepMovement>().SetMagnetPoint(MagnetPoint);
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
