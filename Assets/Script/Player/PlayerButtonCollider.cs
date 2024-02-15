using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**��������������غ�
 */

public class PlayerButtonCollider : MonoBehaviour
{
    Player playerScript;

    private void Awake()
    {
        playerScript = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            playerScript.canJump = true;
            playerScript.myAnim.SetBool("Jump", false);
        }
    }
}
