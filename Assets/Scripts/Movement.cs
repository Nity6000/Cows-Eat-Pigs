using UnityEngine;

public class Movement : MonoBehaviour {

    private float speedForce = 5f;

    void Update ()
    {


        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = new Quaternion(0, 0, 90, 90);
            rb.velocity = new Vector2(-speedForce, rb.velocity.y);

        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = new Quaternion(90, 90, 0, 0);
            rb.velocity = new Vector2(speedForce, rb.velocity.y);
        }
        
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.localRotation = new Quaternion(0, 360, 0, 0);
            rb.velocity = new Vector2(rb.velocity.x, speedForce);
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.localRotation = new Quaternion(0, 0, 360, 0);
            rb.velocity = new Vector2(rb.velocity.x, -speedForce);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
