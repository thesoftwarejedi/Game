using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ChaScript : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetAxis("Horizontal") != 0f || CrossPlatformInputManager.GetAxis("Vertical") != 0f)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }
}
