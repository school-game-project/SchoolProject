using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    public float speedMultiplicator;
    public float stamina;
    public float staminaLostPerFrame;
    public float maxStamina;

    private bool singleplay;
    private Rigidbody rb;
    private bool walking;
    private bool running;

    private GameObject Compass;

    public delegate void StaminaChanged();
    public event StaminaChanged OnStaminaChanged;


    private void Start()
    {
        Compass = GameObject.FindWithTag("Compass");
        this.singleplay = false;
        rb = GetComponent<Rigidbody>();

        stamina = maxStamina;
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
            running = false;
        }

        //checks on running and reduce stamina if active or increase it when player isnt running
        if (running && stamina > 0.0f)
        {
            stamina -= staminaLostPerFrame * Time.deltaTime;
            stamina = Mathf.Clamp(stamina, -1.0f, maxStamina);

            if(OnStaminaChanged != null)
                OnStaminaChanged();
        }
        else
        {
            if (stamina < maxStamina)
            {
                stamina += staminaLostPerFrame / 15 * Time.deltaTime;
                stamina = Mathf.Clamp(stamina, 0, maxStamina);

                if(OnStaminaChanged != null)
                    OnStaminaChanged();
            }
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
        float multiplicator;

        if (Input.GetKey(KeyCode.LeftShift) && stamina >= 0.0f)
        {
            multiplicator = speedMultiplicator;
        }
        else
        {
            multiplicator = 1;
            running = false;
        }


        if (Input.GetKey(KeyCode.W))
        {
            walking = true;
            rb.velocity = (transform.forward * movespeed) * multiplicator;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            walking = true;
            rb.velocity = (transform.forward * -movespeed) * multiplicator;
        }
        else
        {
            walking = false;
        }

        if (walking && multiplicator != 1)
        {
            running = true;
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
