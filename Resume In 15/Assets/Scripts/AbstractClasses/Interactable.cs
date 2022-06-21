using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Interactable : MonoBehaviour
{
    //This will show when player highlights an object 
    public string prompt;

    //Task associated with interactable
    public TextMeshProUGUI task;

    /// <summary>
    /// Player calls this
    /// </summary>
    public void BaseInteract()
    {
        Interact();
    }

    /// <summary>
    /// Player calls this
    /// </summary>
    public void BaseCompleteTask()
    {
        CompleteTask(task);
    }

    /// <summary>
    /// Meant to be overwritten by future objects
    /// </summary>
    protected virtual void Interact()
    {
        //Leave Empty
    }

    /// <summary>
    /// Meant to Signal that a task has been completed
    /// </summary>
    /// <param name="taskToComplete"></param>
    protected void CompleteTask(TextMeshProUGUI taskToComplete)
    {
        Color currentTextOpacity = taskToComplete.color;
        currentTextOpacity.a = 0.2f;
        taskToComplete.color = currentTextOpacity;
    }
}
