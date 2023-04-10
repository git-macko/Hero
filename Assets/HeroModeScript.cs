using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroModeScript : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public static string heroMode;

    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        heroMode = "";
    }
    void Update()
    {
        textMeshPro.text = "Hero Mode: " + heroMode;
    }
}
