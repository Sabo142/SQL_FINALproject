using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatingRoom : MonoBehaviour
{
    public APIManager _APIManager;
    public UIManager uiManager;
    [SerializeField] private GameObject gameRoom;
    void Update()
    {
        _APIManager.GetPlayer_2Run();
       if(uiManager.readyP2 == true)
        {
            gameObject.SetActive(false);
            gameRoom.SetActive(true);
        }
    }
}
