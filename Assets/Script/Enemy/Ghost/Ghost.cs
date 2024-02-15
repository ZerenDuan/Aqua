using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Ghost : MonoBehaviour
{ 
    public Vector3 targetPosition;
    public float mySpeed;
   

    Animator myAnim;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();

        if (myAnim == null)
        {
            Debug.LogError("¼ÄÁË", this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            Debug.Log("Ã»¼Ä£¡");
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, mySpeed*Time.deltaTime);
        }
        
    }
}
