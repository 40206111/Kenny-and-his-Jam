using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropBase : MonoBehaviour
{
    [SerializeField]
    protected eCrop CropType = eCrop.none;
    public eCrop GetCropType { get { return CropType; } }
    protected CropData CropData;

    [SerializeField]
    protected List<CropVisual> Plants = new List<CropVisual>();
    protected List<int> UnfinishedIndexes = new List<int>();

    // Start is called before the first frame update
    protected virtual void Start()
    {
        CropData = new CropData(CropType);
        for (int i = 0; i < Plants.Count; ++i)
        {
            UnfinishedIndexes.Add(i);
        }
        foreach (CropVisual cv in Plants)
        {
            cv.CropPlanted(CropData.GrowthTime);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoilData sd = new SoilData(0.1f);
            NewDay(ref sd);
        }
    }

    public virtual void NewDay(ref SoilData soilData)
    {
        int maxGrowths = Mathf.Min(Plants.Count, UnfinishedIndexes.Count);
        for (int i = 0; i < soilData.Resources.Length; ++i)
        {
            if (CropData.ResourcesPerDay[i] > soilData.Resources[i])
            {
                maxGrowths = Mathf.Min(maxGrowths, (int)((soilData.Resources[i] / CropData.ResourcesPerDay[i]) * Plants.Count));
            }
        }
        Debug.Log($"Plants grown: {maxGrowths}");

        if (maxGrowths < UnfinishedIndexes.Count)
        {
            List<int> availableIs = new List<int>(UnfinishedIndexes);

            for (int i = 0; i < maxGrowths; ++i)
            {
                int ran = Random.Range(0, availableIs.Count);
                AdvanceDayForPlant(availableIs[ran]);
                availableIs.RemoveAt(ran);
            }
        }
        else
        {
            List<int> availableIs = new List<int>(UnfinishedIndexes);
            foreach (int i in availableIs)
            {
                AdvanceDayForPlant(i);
            }
        }

        for (int i = 0; i < (int)eResource.ResourceCount; ++i)
        {
            float change = ((float)maxGrowths / (float)Plants.Count) * CropData.ResourcesPerDay[i];
            soilData.ChangeResourceLevel(i, -change);
        }
    }

    protected void AdvanceDayForPlant(int cropIndex)
    {
        Plants[cropIndex].AdvanceDay();
        if (Plants[cropIndex].IsComplete)
        {
            UnfinishedIndexes.Remove(cropIndex);
        }
    }
}
