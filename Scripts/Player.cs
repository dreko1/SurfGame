using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity = 20.0f;
    public float jumpHeight = 2.5f;

    Rigidbody r;
    bool grounded = false;
    Vector3 defaultScale;
    bool crouch = false;
    public GameObject loseScreen;
    public bool hitObject = false;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        r.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        r.freezeRotation = true;
        r.useGravity = false;
        defaultScale = transform.localScale;
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            r.velocity = new Vector3(r.velocity.x, CalculateJumpVerticalSpeed(), r.velocity.z);
        }

        //Crouch
        crouch = Input.GetKey(KeyCode.S);
        if (crouch)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(defaultScale.x, defaultScale.y * 0.4f, defaultScale.z), Time.deltaTime * 7);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, Time.deltaTime * 7);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.A) && transform.localPosition.x > -3)
        {
            transform.localPosition += (3 * Vector3.left);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.D) && transform.localPosition.x < 3)
        {
            transform.localPosition += (3 * Vector3.right);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // We apply gravity manually for more tuning control
        r.AddForce(new Vector3(0, -gravity * r.mass, 0));

        grounded = false;
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            //print("GameOver!");
            GroundGenerator.instance.gameOver = true;
        }
        if(collision.gameObject.tag == "Obstacle") {
            hitObject = true;
            GroundGenerator.instance.gameOver = true;
            loseScreen.SetActive(true);
        }
    }
}