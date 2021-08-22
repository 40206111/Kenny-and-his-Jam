using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropVisual : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> Stages = new List<GameObject>();
    int CurrentStage = -1;
    int CurrentDay = -1;
    int FinalDay = -1;

    private int[] Milestones;
    int CurrentMilestoneToHit = 0;

    public void CropPlanted(int growthTime)
    {
        FinalDay = growthTime;
        CurrentDay = 0;
        CurrentStage = -1;
        CalculateMilestones();
    }

    private void CalculateMilestones()
    {
        Milestones = new int[Stages.Count];
        Milestones[0] = 1;
        Milestones[Milestones.Length - 1] = FinalDay;

        if (Stages.Count <= 2)
        {
            return;
        }

        for (int i = 1; i < Milestones.Length - 1; ++i)
        {
            float fraction = (FinalDay - 1) / (float)(Milestones.Length - 1);
            Milestones[i] = 1 + (int)(fraction * i);
        }

        CurrentMilestoneToHit = 0;
    }

    public void AdvanceDay()
    {
        Debug.Log("Advancing day.");
        if(CurrentMilestoneToHit == Milestones.Length)
        {
            return;
        }
        CurrentDay++;
        if (CurrentDay == Milestones[CurrentMilestoneToHit])
        {
            Debug.Log($"Advancing milestone: {CurrentMilestoneToHit}.");
            AdvanceStage();
            CurrentMilestoneToHit++;
        }
    }

    private void AdvanceStage()
    {
        if (CurrentStage == (Stages.Count - 1))
        {
            return;
        }
        CurrentStage++;
        Stages[CurrentStage].SetActive(true);
    }

    public int GetCurrentDay { get { return CurrentDay; } }
    public int GetCurrentStage { get { return CurrentStage; } }
    public int GetTotalStages { get { return Stages.Count; } }
    public bool IsComplete { get { return CurrentDay == FinalDay; } }
}
