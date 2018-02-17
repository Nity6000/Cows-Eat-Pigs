using UnityEngine;

public class Movement : MonoBehaviour {

    private float speedForce = 5f;
    public Animator AnimLeg1;
    public Animator AnimLeg2;
    public Animator AnimLeg3;
    public Animator AnimLeg4;

    private void AnimLegs() {
        AnimLeg1.enabled = true;
        AnimLeg2.enabled = true;
        AnimLeg3.enabled = true;
        AnimLeg4.enabled = true;
    }

    void Update ()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = new Quaternion(0, 0, 90, 90);
            rb.velocity = new Vector2(-speedForce, rb.velocity.y);
            AnimLegs();
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = new Quaternion(0, 0, 90, -90);
            rb.velocity = new Vector2(speedForce, rb.velocity.y);
            AnimLegs();
        }
        
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.localRotation = new Quaternion(0, 0, 0, 0);
            rb.velocity = new Vector2(rb.velocity.x, speedForce);
            AnimLegs();
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.localRotation = new Quaternion(0, 0, 360, 0);
            rb.velocity = new Vector2(rb.velocity.x, -speedForce);
            AnimLegs();
        }
        else
        {
            if (AnimLeg1 != null) {
                AnimLeg1.enabled = false;
                AnimLeg2.enabled = false;
                AnimLeg3.enabled = false;
                AnimLeg4.enabled = false;
                
            } else {
                speedForce = 0.8f;
            }
            
            rb.velocity = new Vector2(0, 0);
        }
    }
}
