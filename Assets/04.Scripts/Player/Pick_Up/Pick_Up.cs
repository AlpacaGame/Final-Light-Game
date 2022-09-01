using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    public bool UI_open = false;
    public GameObject EmptyHand;
    public GameObject GunHand;
    public GameObject AccessCard;
    public GameObject Password;
    public static bool PickGun = false;
    public static bool PickAccessCard = false;
    public static bool PickPassword = false;
    void Update()
    {
        if(PickGun)
        {
            EmptyHand.SetActive(false);
            GunHand.SetActive(true);
        }

        if (PickAccessCard)
        {
            AccessCard.SetActive(true);
            UI_open = true;
            Time.timeScale = 0;
        }

        if (PickPassword)
        {
            Password.SetActive(true);
            UI_open = true;
            Time.timeScale = 0;
        }

        if(Input.GetKey(KeyCode.Escape) && UI_open)
        {
            PickAccessCard = false;
            PickPassword = false;
            Password.SetActive(false);
            AccessCard.SetActive(false);
            UI_open = false;
            Time.timeScale = 1;
        }
    }
}
