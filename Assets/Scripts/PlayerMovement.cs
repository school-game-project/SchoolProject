using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float defaultSpeed;
    [SerializeField]
    private bool diagonal;

    private Rigidbody rb;


    void Start() 
    {
        rb = this.GetComponent<Rigidbody>();
    }


    void Update() 
    {
        if (rb.velocity.x != 0 && rb.velocity.z != 0)
        {
            speed = defaultSpeed / 2;
        }
        else 
        {
            speed = defaultSpeed;
        }

        Walk();
    }

    private void Walk() 
    {
        //Walk Forward
        if (Input.GetKey(KeyCode.W)) 
        {
            Debug.Log("test");
            rb.velocity = new Vector3(rb.velocity.x, 0, speed);
        }

        //Walk Backward
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, -speed);
        }

        //Walk Left
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, 0, rb.velocity.z);
        }

        //Walk Right
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, 0, rb.velocity.z);
        }
    }
}
