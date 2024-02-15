using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    public Vector3 pointA = new Vector3(-4, 0, 0); // 起点
    public Vector3 pointB = new Vector3(4, 0, 0); // 终点
    public float speed = 2.0f; // 移动速度

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
        // 翻转scale.x值来实现视觉上的转向
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SetNextPosition()
    {
        nextPosition = pointA; // 或根据您的逻辑选择pointA或pointB作为初始nextPosition
    }
}