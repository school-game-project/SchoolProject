using UnityEngine;
using System.Collections;

public class PlayerMovementTest : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float jumpHeight;

    private Rigidbody rb;

    void Start() 
    {
        this.rb = this.GetComponent<Rigidbody>();
    }


    void Update() 
    {
        if (Input.anyKey) 
        {
            Walk();

            Jump();
        }
    }

    private void Walk() 
    {
        if (Input.GetKey("d")) 
        {
            this.rb.velocity = new Vector3(this.speed, this.rb.velocity.y, this.rb.velocity.z);
        };

        if (Input.GetKey("a")) 
        {
            this.rb.velocity = new Vector3(-this.speed, this.rb.velocity.y, this.rb.velocity.z);
        };

        if (Input.GetKey("s")) 
        {
            this.rb.velocity = new Vector3(this.rb.velocity.x, this.rb.velocity.y, -this.speed);
        };

        if (Input.GetKey("w"))
        {
            this.rb.velocity = new Vector3(this.rb.velocity.x, this.rb.velocity.y, this.speed);
        }
    }

    private void Jump() 
    {
        if (Input.GetKey("space")) 
        {
            this.rb.velocity = new Vector3(this.rb.velocity.x, this.jumpHeight, this.rb.velocity.z);
        }
    }
}
