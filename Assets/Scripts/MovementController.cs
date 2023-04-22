
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float reverseSpeed = 3f;
    public float strafeSpeed = 4.5f;
    public float height = 0.2f;
    public float gravity = 5f;
    public float jumpPower = 10f;

    public float vert;
    public float morphDelay;

    public bool grounded;
    public bool hasMoved;
    public bool finishedLevel;

    public Animator anim;
    private Rigidbody charRB;

    

    public GameObject feet;
    public Camera tpCamera;
    public GameObject CameraBase;

    private Color skinColor;
    public GameObject chameleon;
    public GameObject rightEye;
    public GameObject leftEye;

    



    void Start()
    {
        charRB = GetComponent<Rigidbody>();
        charRB.isKinematic = false;
        anim = GetComponentInChildren<Animator>();
        hasMoved = false;
        finishedLevel = false; 



    }

    private void Update()
    {
        animationControl();
        transform.localEulerAngles = new Vector3(0, CameraBase.transform.localEulerAngles.y, 0 * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray groundRay = new Ray(feet.transform.position, Vector3.down);

        
        if (Physics.Raycast(groundRay, out hit, height))
        {
            if (hit.collider.tag == "victory")
            {
                finishedLevel = true;

            }
            grounded = true;
            if (hit.collider.tag != "victory")
            {
                chameleon.GetComponent<Renderer>().material.color = Color.Lerp(chameleon.GetComponent<Renderer>().material.color, hit.collider.GetComponent<Renderer>().material.color, Mathf.PingPong(Time.fixedDeltaTime, morphDelay));
                rightEye.GetComponent<Renderer>().materials[1].color = Color.Lerp(rightEye.GetComponent<Renderer>().materials[1].color, hit.collider.GetComponent<Renderer>().material.color, Mathf.PingPong(Time.fixedDeltaTime, morphDelay));
                leftEye.GetComponent<Renderer>().materials[1].color = Color.Lerp(leftEye.GetComponent<Renderer>().materials[1].color, hit.collider.GetComponent<Renderer>().material.color, Mathf.PingPong(Time.fixedDeltaTime, morphDelay));
            }
        }
        else
        {
            grounded = false;
        }


        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if (!grounded)
        {

            charRB.velocity += Vector3.up * Physics.gravity.y * (gravity - 1) * Time.fixedDeltaTime;
        }
        movement();


    }

    //private void LateUpdate()
    //{
        
    //    transform.localEulerAngles = new Vector3(0, CameraBase.transform.localEulerAngles.y, 0 * Time.deltaTime);
    //}

    public void Jump()
    {
        charRB.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
    }

    public void movement()
    {

        if (Input.GetKey(KeyCode.W))
        {
            anim.speed = 1f;
            hasMoved = false;
            charRB.AddForce(transform.forward * forwardSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
            hasMoved = true;
        }
        else if (hasMoved == true)
        {

            StartCoroutine(stopMidWalk());
            hasMoved = false;
        }

        if (Input.GetKey(KeyCode.S))
        {

            charRB.AddForce(transform.forward * -reverseSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            charRB.AddForce(transform.right * -strafeSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
        }


        if (Input.GetKey(KeyCode.D))
        {
            charRB.AddForce(transform.right * strafeSpeed * Time.fixedDeltaTime, ForceMode.Impulse); 
        }


    }

    public void animationControl()
    {
        if(grounded)
        {
            vert = Input.GetAxis("Vertical");
            anim.SetFloat("Walk", vert);
        }
        
    }

    IEnumerator stopMidWalk()
    {
        anim.speed = 0f;
        yield return new WaitForSeconds(1);
        anim.speed = 1f;
            
    }
}
