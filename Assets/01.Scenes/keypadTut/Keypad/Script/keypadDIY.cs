//333333333333333333333333333333333333333333333333333333333333333333\\
//
//          Arthur: Cato Parnell
//          Description of script: control keypad button clicks and actions
//          Any queries please go to Youtube: Cato Parnell and ask on video. 
//          Thanks.
//
//33333333333333333333333333333333333333333333333333333333333333333\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keypadDIY : MonoBehaviour
{
    // *** CAN DELETE THESE ** \\
    // Used to hide joystick and slider
    [Header("Objects to Hide/Show")]
    public GameObject objectToDisable;
    public GameObject objectToDisable2;

    // Object to be enabled is the keypad. This is needed
    public GameObject objectToEnable;


    [Header("Keypad Settings")]
    public string curPassword = "123";
    public string input;
    public Text displayText;
    //public AudioSource audioData;

    //Local private variables
    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;

    public bool 開啟密碼鎖開關;



    // Start is called before the first frame update
    void Start()
    {
        btnClicked = 0; // No of times the button was clicked
        numOfGuesses = curPassword.Length; // Set the password length.
    }

    // Update is called once per frame
    void Update()
    {
        if (btnClicked == numOfGuesses)
        {
            if (input == curPassword)
            {
                //Load the next scene
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
                // LOG message that password is correct
                Debug.Log("Correct Password!");
                input = ""; //Clear Password
                btnClicked = 0;

            }
            else
            {
                //Reset input varible
                input = "";
                displayText.text = input.ToString();
                //audioData.Play();
                btnClicked = 0;
            }

        }

        if (Input.GetKey(KeyCode.E) && 開啟密碼鎖開關)
        {
            keypadScreen = true;
        }
        if (keypadScreen)
        {
            objectToDisable.SetActive(false);
            objectToDisable2.SetActive(false);
            objectToEnable.SetActive(true);
        }
    }

    

    void OnTriggerEnter(Collider Password)
    {
        if (Password.CompareTag("Player"))
        {
            開啟密碼鎖開關 = true;
        }

    }

    void OnTriggerExit(Collider Password)
    {
        if (Password.CompareTag("Player"))
        {
            開啟密碼鎖開關 = false;
        }
    }

    
    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q": // QUIT
                objectToDisable.SetActive(true);
                objectToDisable2.SetActive(true);
                objectToEnable.SetActive(false);
                btnClicked = 0;
                keypadScreen = false;
                input = "";
                displayText.text = input.ToString();
                break;

            case "C": //CLEAR
                input = "";
                btnClicked = 0;// Clear Guess Count
                displayText.text = input.ToString();
                break;

            default: // Buton clicked add a variable
                btnClicked++; // Add a guess
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }


    }
    
}
