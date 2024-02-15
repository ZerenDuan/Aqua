using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPrefab : MonoBehaviour
{
    public GameObject prefab;// ��Inspector��ָ������Ԥ����
    public Vector3 spawnPosition = new Vector3(0, 1.5f, 0);
    public Vector3 pointA = new Vector3(-4, 0, 0); // ʵ����Ԥ���������
    public Vector3 pointB = new Vector3(4, 0, 0); // ʵ����Ԥ�������յ�



    void Start()
    {
        
        GameObject instance = Instantiate(prefab, spawnPosition, Quaternion.identity);
        PingPongMovement movementScript = instance.GetComponent<PingPongMovement>();
        if (movementScript != null)
        {
            movementScript.pointA = pointA;
            movementScript.pointB = pointB;
            movementScript.SetNextPosition(); // ȷ�����ô˷����Գ�ʼ��nextPosition
        }
    }

    
}


