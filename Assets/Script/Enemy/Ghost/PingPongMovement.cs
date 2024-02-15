using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    public Vector3 pointA = new Vector3(-4, 0, 0); // ���
    public Vector3 pointB = new Vector3(4, 0, 0); // �յ�
    public float speed = 2.0f; // �ƶ��ٶ�

    private Vector3 nextPosition;

    void Start()
    {
        nextPosition = pointA;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, nextPosition) < 0.01f)
        {
            nextPosition = nextPosition == pointA ? pointB : pointA;
            FlipDirection();
        }
    }

    void FlipDirection()
    {
        // ��תscale.xֵ��ʵ���Ӿ��ϵ�ת��
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SetNextPosition()
    {
        nextPosition = pointA; // ����������߼�ѡ��pointA��pointB��Ϊ��ʼnextPosition
    }
}