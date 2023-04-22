using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputAnswer : MonoBehaviour
{
    [SerializeField]
    private InputField playerInput;

    public bool correct = false;
    
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


        if(guess == fasit)
        {
            correct = true;
            Debug.Log("Correct Answer!");
            
        } else
        {
            correct = false;
        }
    }
}
