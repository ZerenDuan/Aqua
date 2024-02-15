using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject prefab; // ָ������Ԥ����

    void Start()
    {
        SpawnPrefab(new Vector3(-5, 0, 0), new Vector3(5, 0, 0));
        SpawnPrefab(new Vector3(-5, 2, 0), new Vector3(5, 2, 0));
        // ���Լ�����Ӹ���ʵ����Ԥ����ĵ��ã�ÿ�����в�ͬ��pointA��pointB
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