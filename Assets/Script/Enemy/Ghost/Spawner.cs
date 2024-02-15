using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject prefab; // 指向您的预制体

    void Start()
    {
        SpawnPrefab(new Vector3(-5, 0, 0), new Vector3(5, 0, 0));
        SpawnPrefab(new Vector3(-5, 2, 0), new Vector3(5, 2, 0));
        // 可以继续添加更多实例化预制体的调用，每个都有不同的pointA和pointB
    }

    void SpawnPrefab(Vector3 pointA, Vector3 pointB)
    {
        GameObject instance = Instantiate(prefab, pointA, Quaternion.identity);
        PingPongMovement movementScript = instance.GetComponent<PingPongMovement>();
        if (movementScript != null)
        {
            movementScript.pointA = pointA;
            movementScript.pointB = pointB;
        }
    }
}