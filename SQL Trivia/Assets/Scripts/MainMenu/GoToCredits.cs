using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCredits : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject Credits;

    public void GoTocredits()
    {
        mainMenu.SetActive(false);
        Credits.SetActive(true);
    }
}
