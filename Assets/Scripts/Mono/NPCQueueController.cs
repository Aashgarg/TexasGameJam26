using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class NPCQueueController : MonoBehaviour
{
    public List<NPCData> NPCs;
    public Image portrait;
    public TextMeshProUGUI nameText;

    private int currentIndex = 0;

    private NPCData NPC;

    public UnityEvent<NPCData> onNPCChosen;

    void Start()
    {
        UpdateMugShot();
    }
    public void UpdateMugShot()
    {
        portrait.sprite = NPCs[currentIndex].portrait;
        nameText.text = NPCs[currentIndex].NPCName;
    }

    public void NextMugShot()
    {
        if (NPCs.Count > 0)
        {
            currentIndex++;
            if (currentIndex >= NPCs.Count)
            {
                currentIndex = 0;
            }
            UpdateMugShot();
            onNPCChosen?.Invoke(NPCs[currentIndex]);
        }
        else
        {
            Debug.Log("No NPCS");
        }
    }

    public void PrevMugShot()
    {
        if (NPCs.Count > 0)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = NPCs.Count - 1;
            }
            UpdateMugShot();
        }
        else
        {
            Debug.Log("No NPCS");
        }
    }
}
