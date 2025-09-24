using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject body;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("up", true);
        }
        else animator.SetBool("up", false);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("down", true);
        }
        else animator.SetBool("down", false);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("side", true);
            body.transform.localScale = new Vector3(1, 1, 1);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("side", true);
            body.transform.localScale = new Vector3(-1,1,1);
        }
        else animator.SetBool("side", false);
    }
}
