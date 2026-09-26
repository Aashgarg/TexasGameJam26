using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class NotebookManager : MonoBehaviour
{
    private List<ClueData> clues;
    public UnityEvent<ClueData> onClueAdded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddClue(ClueData clue)
    {
        if (!clues.Contains(clue)){
            clues.Add(clue);
            onClueAdded?.Invoke(clue);
        }
    }
}
