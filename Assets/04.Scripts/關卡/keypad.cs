
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keypad : MonoBehaviour
{
    
    [Header("Objects to Hide/Show")]

    public GameObject objectToEnable;


    //[Header("Keypad Settings")]
    [Header("密碼設定")]
    public string curPassword = "123";
    public string input;
    public Text displayText;
    //public AudioSource audioData;

    //Local private variables
    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;

    public bool 開啟密碼鎖開關;
    public int index;

    public Image black;
    public Animator anim;

    public GameObject 亮光;

    // Start is called before the first frame update
    void Start()
    {
        btnClicked = 0; // No of times the button was clicked
        numOfGuesses = curPassword.Length; // Set the password length. 
    }

    // Update is called once per frame
    void Update()
    {
        鍵盤操作();
        if (btnClicked == numOfGuesses)
        {
            if (input == curPassword)
            {
                //Load the next scene
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
                // LOG message that password is correct
                Debug.Log("密碼正確!");
                input = ""; //Clear Password
                btnClicked = 0;
                StartCoroutine(Fading());
                keypadScreen = false;
            }
            else
            {
                //Reset input varible
                Debug.Log("密碼錯誤!");
                input = "";
                displayText.text = input.ToString();
                SoundManager.instance.FalseAnswerSource();
                btnClicked = 0;
            }

        }


        if (Input.GetKey(KeyCode.E) && 開啟密碼鎖開關)
        {
            keypadScreen = true;
        }

        
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }

    void OnTriggerEnter2D(Collider2D Password)
    {
        if (Password.CompareTag("Player"))
        {
            開啟密碼鎖開關 = true;
            亮光.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D Password)
    {
        if (Password.CompareTag("Player"))
        {
            開啟密碼鎖開關 = false;
            亮光.SetActive(false);
        }
    }

    void OnGUI()
    {
        // Action for clicking keypad( GameObject ) on screen
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var selection = hit.transform;

                if (selection.CompareTag("keypad")) // Tag on the gameobject - Note the gameobject also needs a box collider
                {
                    keypadScreen = true;

                    var selectionRender = selection.GetComponent<Renderer>();
                    if (selectionRender != null)
                    {
                        keypadScreen = true;
                    }
                }

            }
        }
        
        // Disable sections when keypadScreen is set to true
        
        if (keypadScreen && !GameManager.正在時停)
        {
            objectToEnable.SetActive(true);
            Time.timeScale = 0f;
            Gun_fire.可開火開關 = false;
        }

        else if(!keypadScreen && !Item_on_off.門禁卡 && !GameManager.正在時停)
        {
            objectToEnable.SetActive(false);
            Time.timeScale = 1f;
            Gun_fire.可開火開關 = true;
        }
        
    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q": // QUIT
                //objectToEnable.SetActive(false);
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

    public void 鍵盤操作()
    {
        if (keypadScreen)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                SoundManager.instance.ButtonClickSource();
                input += 1;
                btnClicked++;
                displayText.text = input.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                SoundManager.instance.ButtonClickSource();
                input += 2;
                btnClicked++;
                displayText.text = input.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                SoundManager.instance.ButtonClickSource();
                input += 3;
                btnClicked++;
                displayText.text = input.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                SoundManager.instance.ButtonClickSource();
                input += 4;
                btnClicked++;
                displayText.text = input.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                SoundManager.instance.ButtonClickSource();
                input += 6;
                btnClicked++;
                displayText.text = input.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                SoundManager.instance.ButtonClickSource();
                input += 6;
                btnClicked++;
                displayText.text = input.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                SoundManager.instance.ButtonClickSource();
                input += 7;
                btnClicked++;
                displayText.text = input.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                SoundManager.instance.ButtonClickSource();
                input += 8;
                btnClicked++;
                displayText.text = input.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                SoundManager.instance.ButtonClickSource();
                input += 9;
                btnClicked++;
                displayText.text = input.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                SoundManager.instance.ButtonClickSource();
                input += 0;
                btnClicked++;
                displayText.text = input.ToString();
            }

            else if (Input.GetKeyDown(KeyCode.Delete)|| Input.GetKeyDown(KeyCode.Backspace))
            {
                input ="";
                btnClicked = 0;
                displayText.text = input.ToString();
            }

            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                input = "";
                btnClicked = 0;
                displayText.text = input.ToString();
                keypadScreen = false;
            }
        }
            

    }
}
