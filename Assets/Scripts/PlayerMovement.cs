using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    
    private bool singleplay;
    private Rigidbody rb;
    private bool walking;

    private GameObject Compass;


    private void Start()
    {
        Compass = GameObject.FindWithTag("Compass");
        this.singleplay = false;
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

		AudioSource audio = GetComponent<AudioSource>();
        if(walking == true)
		{
			GetComponent<Animation>().Play("orcwalk");

            if (singleplay == false)
            {
                audio.Play();
                singleplay = true;
            }
        }
        else
		{
			GetComponent<Animation>().Play("orcattack");
            if (singleplay == true)
            {
                audio.Stop();
                singleplay = false;
            }
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
            Compass.transform.eulerAngles -= new Vector3(0, 0, 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += new Vector3(0, 3, 0);
            Compass.transform.eulerAngles += new Vector3(0, 0, 3);
        }

        //Debug.Log(transform.rotation.y);
    }
}
