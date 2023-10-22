using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsHolder : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private void OnEnable()
    {
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
    }
    private void OnDisable()
    {
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
    }
}
