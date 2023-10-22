using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private GameObject Mainmenu;
    [SerializeField] private GameObject Game;

    public void GoToGameCanvas()
    {
        Mainmenu.SetActive(false);
        Game.SetActive(true);
    }
}
