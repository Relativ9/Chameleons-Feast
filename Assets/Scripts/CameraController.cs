using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float followSpeed = 120f;
    public float angleClamp = 80f;
    public float inputSense = 150f;

    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;

    private float rotX = 0;
    private float rotY = 0;

    Vector3 followTransform;
    private Vector3 velocity = Vector3.zero;

    public GameObject tpCamera;
    public GameObject Player;
    public GameObject bigCanvas;
    public GameObject VictoryText;

    public GameObject chameleon;
    public GameObject rightEye;
    public GameObject leftEye;
    public GameObject pauseMenu;


    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;

        rotX = rot.x;
        rotY = rot.y;
        VictoryText.SetActive(false);
    }

    void Update()
    {
        if (tpCamera.GetComponent<TargetScript>().quizMenu == false && tpCamera.GetComponent<TargetScript>().quizMenu2 == false && tpCamera.GetComponent<TargetScript>().quizMenu3 == false && bigCanvas.GetComponent<pauseMenu>().isPaused == false)
        {
            freeLook();
        } else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
        finished();

        CameraUpdater();
    }

    private void LateUpdate()
    {
        

        float inputX = Input.GetAxis("StickHorizontal");
        float inputZ = Input.GetAxis("StickVertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotX += finalInputZ * inputSense * Time.deltaTime;
        rotY += finalInputX * inputSense * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -50, 60);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0f);
        transform.rotation = localRotation;


    }

    public void CameraUpdater()
    {

        Transform target = Player.transform;

        float chase = followSpeed * Time.deltaTime;
        transform.position = Vector3.Slerp(this.transform.position, target.position, chase);
    }

    public void freeLook()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void finished()
    {
        if (Player.GetComponent<MovementController>().finishedLevel == true)
        {
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            //Time.timeScale = 0.1f;
            pauseMenu.GetComponent<pauseMenu>().Pause();
            VictoryText.SetActive(true);
            chameleon.GetComponent<Renderer>().materials[0].color = Random.ColorHSV(0f, 1f, 1f, 0f);
            rightEye.GetComponent<Renderer>().materials[1].color = Random.ColorHSV();
            leftEye.GetComponent<Renderer>().materials[1].color = Random.ColorHSV();

        }
    }

    //IEnumerator victoryRainbow()
    //{

    //}
}
