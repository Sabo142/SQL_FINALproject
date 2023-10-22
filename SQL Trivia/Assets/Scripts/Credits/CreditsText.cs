using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditsText : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private int Speed;
    private void OnEnable()
    {
        transform.position = new Vector3(0, -350, -100);
    }
    private void Update()
    {
        
        transform.Translate(_camera.transform.up * Time.deltaTime * Speed);
    }
}
