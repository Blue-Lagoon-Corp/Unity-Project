using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;

    public Transform generationPoint;

    public float distanceBetweenEachPlatform;

    private float platformWidth;

    public float distanceBetweenMin;

    public float distanceBetweenMax;

    private CoffeeCupsGenerator coffeeCupsGenerator;

    //public GameObject[] platforms;

    private int platformSelector;

    private float[] platformWidths;

    public ObjectPooler[] objectPools;

    private float minimumHeight;

    public Transform maximumHeightPoint;

    private float maximumHeight;

    public float maximumHeightChange;

    private float heightChange;

    public float randomCoffeeCupThreshold;

    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[objectPools.Length];

        for (int i = 0; i< objectPools.Length; i++)
        {
            platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minimumHeight = transform.position.y;
        maximumHeight = maximumHeightPoint.position.y;

        coffeeCupsGenerator = FindObjectOfType<CoffeeCupsGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetweenEachPlatform = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, objectPools.Length);

            heightChange = transform.position.y + Random.Range(maximumHeightChange, -maximumHeightChange);

            if(heightChange > maximumHeight)
            {
                heightChange = maximumHeight;
            }

            else if(heightChange < minimumHeight)
            {
                heightChange = minimumHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetweenEachPlatform,
                heightChange,
                transform.position.z);


            //Instantiate(/*platform*/platforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = objectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if(Random.Range(0f,100f) < randomCoffeeCupThreshold)
            {
                coffeeCupsGenerator.SpawnCoffeCups(new Vector3(transform.position.x, transform.position.y + 100f, transform.position.z));

            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2),
                transform.position.y,
                transform.position.z);
        }
    }
}
