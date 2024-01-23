using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Life life;
    [SerializeField] GameObject unit;
    [SerializeField] TextMeshPro textMeshPro;
    [SerializeField] string color;
    private void Start()
    {
        life = unit.GetComponent<Life>();
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform.position);

        // 1xI = 5 pv
        string displayedText = $"{color}";
        for (int i = 0; i < life.life; i += 5)
        {
            displayedText += "I";
        }
        textMeshPro.text = displayedText;
    }
}
