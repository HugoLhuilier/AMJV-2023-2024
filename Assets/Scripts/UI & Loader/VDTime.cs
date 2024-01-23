using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VDTime : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] TMP_Text text;
    void Update()
    {
        if (Mathf.FloorToInt(timer.timer / 60) == 0)
        {
            text.text = $"{Mathf.FloorToInt(timer.timer % 60)}s";
        }
        else
        {
            text.text = $"{Mathf.FloorToInt(timer.timer / 60)}m {Mathf.FloorToInt(timer.timer % 60)}s";
        }
    }
}
