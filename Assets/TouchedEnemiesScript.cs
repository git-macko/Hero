using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TouchedEnemiesScript : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public static int touchCount;

    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        touchCount = 0;
    }
    void Update()
    {
        textMeshPro.text = "Enemy Touched Count: " + touchCount;
    }
}
