using TMPro;
using UnityEngine;

public class Selection : MonoBehaviour
{
    private TMP_Text selectionText;

    private void Start()
    {
        selectionText = GetComponent<TMP_Text>();
    }
    void Update()
    {
        selectionText.text = $"level {GameManager.Instance.selectedLevelIndex} selected";
    }
}
