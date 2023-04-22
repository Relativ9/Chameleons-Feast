using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputAnswer3 : MonoBehaviour
{
    [SerializeField]
    private InputField playerInput;

    public bool correct3 = false;

    public string fasit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getInput(string guess)
    {
        Debug.Log("You Entered " + guess);
        


        if (guess == fasit)
        {
            correct3 = true;
            Debug.Log("Correct Answer!");

        }
        else
        {
            correct3 = false;
        }
    }
}
