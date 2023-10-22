using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject credits;

    public void GobackToMenu()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
}
