using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCountScript : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public static int enemyCount;

    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        enemyCount = 0;
    }
    void Update()
    {
        textMeshPro.text = "Enemy Spawn Count: " + enemyCount;
    }
}
