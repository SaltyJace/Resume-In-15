using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("Prompt")]
    [SerializeField]
    private TextMeshProUGUI promptText;

    [Header("List of Tasks")]
    [SerializeField]
    private TextMeshProUGUI task1;
    [SerializeField]
    private TextMeshProUGUI task2;
    [SerializeField]
    private TextMeshProUGUI task3;

    //Checks for completion status
    private readonly float opacityOfCompletion = 0.2f;

    public void UpdateText(string promptString)
    {
        promptText.text = promptString;
    }

    public bool allTasksComplete()
    {
        if (task1.color.a == opacityOfCompletion && task2.color.a == opacityOfCompletion && task3.color.a == opacityOfCompletion)
        {
            return true;
        }

        return false;
    }
}
