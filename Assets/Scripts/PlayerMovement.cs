using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;

    private Rigidbody rb;
    private bool walking;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            Move();

            Rotate();
        }
        else
        {
            walking = false;
        }

        if(walking == true)
        {
            GetComponent<Animation>().Play("orcwalk");
        }
        else
        {
            GetComponent<Animation>().Play("orcattack");
        }
    }


    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            walking = true;
            rb.velocity = transform.forward * movespeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            walking = true;
            rb.velocity = transform.forward * -movespeed;
        }
        else
        {
            walking = false;
        }
    }


    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles -= new Vector3(0, 3, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += new Vector3(0, 3, 0);
        }

        Debug.Log(transform.rotation.y);
    }
}
