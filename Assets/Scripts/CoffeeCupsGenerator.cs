using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeCupsGenerator : MonoBehaviour
{
    public ObjectPooler objectPooler;

    public float distanceBetweenCoffeeCups;


    public void SpawnCoffeCups(Vector3 startPosition)
    {
        GameObject coffeeCup = objectPooler.GetPooledObject();
        coffeeCup.transform.position = startPosition;
        coffeeCup.SetActive(true);

        GameObject coffeeCup2 = objectPooler.GetPooledObject();
        coffeeCup2.transform.position = new Vector3(startPosition.x - distanceBetweenCoffeeCups, startPosition.y, startPosition.z);
        coffeeCup2.SetActive(true);

        GameObject coffeeCup3 = objectPooler.GetPooledObject();
        coffeeCup3.transform.position = new Vector3(startPosition.x + distanceBetweenCoffeeCups, startPosition.y, startPosition.z);
        coffeeCup3.SetActive(true);
    }
}
