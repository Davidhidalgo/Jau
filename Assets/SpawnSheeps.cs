using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSheeps : MonoBehaviour
{
  public GameObject sheepPrefab;
  public int Size = 1;
  // Start is called before the first frame update
  void Start()
  {
    for (int i = 0; i < Size; i++)
    {
      Vector3 Position = new Vector3(transform.position.x, 1, transform.position.z);
      GameObject Point = new GameObject("Thing");
      GameObject Sheep = Instantiate(sheepPrefab, Position, Quaternion.identity);
      Sheep.GetComponent<SheepMovement>().SetMagnetPoint(Instantiate(Point, transform.position, Quaternion.identity, gameObject.transform));
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
