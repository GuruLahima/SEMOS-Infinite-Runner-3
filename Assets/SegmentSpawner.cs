using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentSpawner : MonoBehaviour
{
    public GameObject segmentPrefab;
    public float spawnInterval;
    public Transform spawnOrigin;
    public float moveSpeed;
    public float recyclingThreshold;

    private float timer;

    [SerializeField]
    private ObjectPoolingSystem poolSystem;

    // Start is called before the first frame update
    void Start()
    {
        poolSystem.InitPool(10, segmentPrefab, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnOnInterval();
        MoveSegments();
        RecycleSegments();
    }

    private void RecycleSegments()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.activeSelf == true)
            {
                if (child.position.z < recyclingThreshold)
                {
                    poolSystem.ReturnObject(child.gameObject);
                }
            }

        }
    }


    private void MoveSegments()
    {
        foreach (Transform child in this.transform)
        {
            child.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }


    private void SpawnOnInterval()
    {
        timer += Time.deltaTime;
        // todo: consider length of segments when spawning
        if (timer >= spawnInterval)
        {
            timer = 0;


            SpawnSegment();
        }

    }

    public void SpawnSegment()
    {
        // Instantiate(segmentPrefab, spawnOrigin.position, segmentPrefab.transform.rotation, spawnOrigin);
        GameObject newSegment = poolSystem.GetObject();

        if (newSegment == null)
        {
            return;
        }

        newSegment.transform.position = spawnOrigin.position;
        newSegment.transform.rotation = spawnOrigin.rotation;
        newSegment.transform.parent = spawnOrigin;

    }

}
