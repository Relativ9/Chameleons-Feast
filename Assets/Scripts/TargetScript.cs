using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{

    public float grappleSpeed;
    public float eatSpeed;
    public float maxDistance;
    public int tokensCollected;

    public GameObject player;
    public GameObject cameraBase;
    public Camera tpCamera;
    public GameObject targetToEat;
    public Transform canvas;
    public GameObject quizGiver;
    public Slider tokenBar;

    private bool hooked;

    public bool shoot;
    public bool eat;
    public bool quizMenu;
    public bool quizMenu2;
    public bool quizMenu3;



    private Vector3 grapplePoint;

    Rigidbody charRB;

    void Start()
    {
        shoot = false;
        eat = false;
        quizMenu = false;
        charRB = player.GetComponent<Rigidbody>();
        
        

    }

    void upodate ()
    {
        
    }

    private void FixedUpdate()
    {
        
        ActionRay();

        if (shoot)
        {
            GrappleTo();
            
        }
        if (eat)
        {
            GrapplePull();
        }


    }

    void ActionRay()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(tpCamera.transform.position, tpCamera.transform.forward, out hit, maxDistance))
        {

            if(hit.collider.tag == "hookable")
            {
                shoot = true;
                grapplePoint = hit.point;
                
            } else 
            {
                shoot = false;
            }

            if (hit.collider.tag == "target")
            {
                eat = true;
                targetToEat = hit.collider.gameObject;
            }

            if (hit.collider.tag == "NPC")
            {
                quizGiver = hit.collider.gameObject;
                quizMenu = true;

            } else
            {
                quizMenu = false;
            }
            if (hit.collider.tag == "NPC2")
            {
                quizGiver = hit.collider.gameObject;
                quizMenu2 = true;

            }
            else
            {
                quizMenu2 = false;
            }

            if (hit.collider.tag == "NPC3")
            {
                quizGiver = hit.collider.gameObject;
                quizMenu3 = true;

            }
            else
            {
                quizMenu3 = false;
            }
        }

    }

    void GrappleTo()
    {
        
        Vector3 normalized = (grapplePoint - transform.position).normalized;

        charRB.velocity = Vector3.Lerp(charRB.velocity, normalized * grappleSpeed, 8.0f);

        float distance = Vector3.Distance(player.transform.position, grapplePoint);

        if(distance <= 12.0f)
        {
            shoot = false;
        }
    }

    void GrapplePull()
    {
        targetToEat.transform.position = Vector3.MoveTowards(targetToEat.transform.position, player.transform.position, eatSpeed * Time.fixedDeltaTime);

        float eatDistance = Vector3.Distance(targetToEat.transform.position, player.transform.position);

        if(eatDistance <= 2.0f)
        {
            Object.Destroy(targetToEat);
            targetToEat = null;
            eat = false;
            tokensCollected++;
            tokenBar.value = tokensCollected;
        }
    }

}
