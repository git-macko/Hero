using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDestroyedScript : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public static int detroyCount;

    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        detroyCount = 0;
    }
    void Update()
    {
        textMeshPro.text = "Enemy Destroy Count: " + detroyCount;
    }
}

