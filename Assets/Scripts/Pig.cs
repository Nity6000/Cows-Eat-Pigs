using UnityEngine.UI;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource ExplosionSound;
    public Sprite Explosion;
    public GameObject CowObject;
    public Transform cow;
    public Transform pig;
    public Vector3 pos;
    private float speedForce;
    private bool move = false;
    public GameObject GameOver;

    void Start()
    {
        move = true;

        GameOver.SetActive(false);

        // Easy Mode
        if (UIControl.difficulty.Equals(1))
        {
            speedForce = 19f;
        }
        // Normal Mode
        if (UIControl.difficulty.Equals(2))
        {
            speedForce = 25f;
        }
        // Hard Mode
        if (UIControl.difficulty.Equals(3))
        {
            speedForce = 35f;
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name.Equals("BackBorder"))
        {
            pig.transform.localPosition = pos;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cow.transform.localScale != new Vector3(1.05f, 1.1f, 1))
            {
                cow.transform.localScale += new Vector3(0.05f, 0.05f, 0);
                pig.transform.localPosition = pos;
            }
            else
            {
                Explode();
            }
        }
    }

    public void Explode()
    {
        if (CowObject.gameObject.GetComponent<SpriteRenderer>().sprite != Explosion)
        {
            CowObject.gameObject.GetComponent<SpriteRenderer>().sprite = Explosion;
            ExplosionSound.Play();
            foreach (Transform child in CowObject.transform) {
                GameObject.Destroy(child.gameObject);
            }
            Music.volume = 0.15f;
            Destroy(gameObject);
            move = false;
            GameOver.SetActive(true);
            Main data = gameObject.AddComponent<Main>();
            data.StopTimer();
            data.SaveData();
        }
        else
        {
            
        }

    }

    void Update()
    {

        if (move == true)
        {
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-speedForce, rb.velocity.y);
        }
    }
}
