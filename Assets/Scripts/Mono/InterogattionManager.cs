using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class InterogattionManager : MonoBehaviour
{
    public NPCData currentSuspect;

    public DialogueManager dm;

    public UnityEvent<float> onStressChanged;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNPC(NPCData npc)
    {
        currentSuspect = npc;
    }

    public void Ask()
    {

    }

    public void Pressure()
    {
        float stress = Random.Range(20, 30);
        currentSuspect.currentStress += stress;
        onStressChanged?.Invoke(currentSuspect.currentStress);
    }

    public void Withdraw()
    {
        float stress = Random.Range(10, 15);
        currentSuspect.currentStress -= stress;
        onStressChanged?.Invoke(currentSuspect.currentStress);
    }
}
