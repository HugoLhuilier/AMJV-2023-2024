using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    private TMP_Text timerText;

    private void Start()
    {
        timerText = GetComponent<TMP_Text>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (Mathf.FloorToInt(timer / 60) == 0 )
        {
            timerText.text = $"{Mathf.FloorToInt(timer % 60)}s";
        } else
        {
            timerText.text = $"{Mathf.FloorToInt(timer / 60)}m {Mathf.FloorToInt(timer % 60)}s";
        }
    }
}
