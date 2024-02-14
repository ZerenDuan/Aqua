using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float mySpeed;
    public float jumpForce;
    public GameObject attackCollider;

    [HideInInspector]
    public Animator myAnim;
    Rigidbody2D myRigi;
    SpriteRenderer mySr;

    [HideInInspector]
    public bool isJumpPressed, canJump, isHurt,canBeHurt;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        myRigi = GetComponent<Rigidbody2D>();
        mySr = GetComponent<SpriteRenderer>();

        isJumpPressed = false;
        canJump = true;
        isHurt = false;
        canBeHurt = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        mySpeed = 5f;
        jumpForce = 9f;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump == true && isHurt == false) 
        {
            isJumpPressed = true;
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.J) && isHurt == false)
        {
            myAnim.SetTrigger("Attack");
        }
    }
    private void FixedUpdate()
    {
        float a = Input.GetAxisRaw("Horizontal");
        
        if (a > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (a < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        myAnim.SetFloat("Run",Mathf.Abs(a));

        if(isJumpPressed) 
        { 
            myRigi.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumpPressed = false;

            myAnim.SetBool("Jump", true);
        }
        if (!isHurt)
        {
            myRigi.velocity = new Vector2(a * mySpeed, myRigi.velocity.y);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && isHurt == false && canBeHurt == true)
        {
            isHurt = true;
            canBeHurt = false;
            mySr.color = new Color(mySr.color.r,mySr.color.g,mySr.color.b, 0.5f);
            myAnim.SetBool("Hurt", true);

            if(transform.localScale.x == 1.0f)
            {
                myRigi.velocity = new Vector2(-2.0f, 5f);
            }
            else if(transform.localScale.x == -1.0f)
            {
                myRigi.velocity = new Vector2(2.0f, 5f);
            }
            myRigi.velocity = new Vector2(-2.0f, 5f);

            StartCoroutine("SetIsHurtFalse");
        }
    }

    IEnumerator SetIsHurtFalse()
    {
        yield return new WaitForSeconds(1.0f);
        isHurt = false;
        mySr.color = new Color(mySr.color.r, mySr.color.g, mySr.color.b, 1.0f);
        myAnim.SetBool("Hurt", false);

        yield return new WaitForSeconds(1.0f);
        canBeHurt = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && isHurt == false && canBeHurt == true)
        {
            isHurt = true;
            canBeHurt = false;
            mySr.color = new Color(mySr.color.r, mySr.color.g, mySr.color.b, 0.5f);
            myAnim.SetBool("Hurt", true);

            if (transform.localScale.x == 1.0f)
            {
                myRigi.velocity = new Vector2(-2.0f, 5f);
            }
            else if (transform.localScale.x == -1.0f)
            {
                myRigi.velocity = new Vector2(2.0f, 5f);
            }
            myRigi.velocity = new Vector2(-2.0f, 5f);

            StartCoroutine("SetIsHurtFalse");
        }
    }

    public void ForIsHurtSetting()
    {
        attackCollider.SetActive(false);
    }

    public void setAttackColliderOn()
    {
        attackCollider.SetActive(true);
    }

    public void setAttackColliderOff()
    {
        attackCollider.SetActive(false);
    }


}