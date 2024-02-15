using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPrefab : MonoBehaviour
{
    public GameObject prefab;// 在Inspector中指向您的预制体
    public Vector3 spawnPosition = new Vector3(0, 1.5f, 0);
    public Vector3 pointA = new Vector3(-4, 0, 0); // 实例化预制体后的起点
    public Vector3 pointB = new Vector3(4, 0, 0); // 实例化预制体后的终点



    void Start()
    {
        
        GameObject instance = Instantiate(prefab, spawnPosition, Quaternion.identity);
        PingPongMovement movementScript = instance.GetComponent<PingPongMovement>();
        if (movementScript != null)
        {
            movementScript.pointA = pointA;
            movementScript.pointB = pointB;
            movementScript.SetNextPosition(); // 确保调用此方法以初始化nextPosition
        }
    }

    
}


