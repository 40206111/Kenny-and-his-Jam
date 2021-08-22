/*
 * Rotation order:
 * Legumes (nitrogen fix)
 * Leaf (nitrogen consume)
 * Fruit (phosphorous consume)
 * Roots (potassium consume)
*/
public enum eCrop { none = -1, GreenBean, Corn, Melon, Carrot }

public enum eResource { none = -1, Nitrogen, Potassium, Phosphorous, Water, ResourceCount };

public class CropData
{
    public readonly float[] ResourceConsumptions = new float[(int)eResource.ResourceCount];
    public readonly float[] ResourcesPerDay = new float[(int)eResource.ResourceCount];
    public readonly int GrowthTime = 0;
    public readonly eCrop CropType = eCrop.none;

    private CropData(int growthTime, float[] resValues)
    {
        GrowthTime = growthTime;

        for (int i = 0; i < resValues.Length; ++i)
        {
            ResourceConsumptions[i] = resValues[i];
        }

        for (int i = 0; i < ResourceConsumptions.Length; ++i)
        {
            ResourcesPerDay[i] = ResourceConsumptions[i] / GrowthTime;
        }
    }

    public CropData(eCrop cropType) : this(CropGrowthValues(cropType), CropResourceValues(cropType))
    {
        CropType = cropType;
    }

    private static int CropGrowthValues(eCrop cropType)
    {
        int outVal = -1;

        switch (cropType)
        {
            case eCrop.GreenBean:
                outVal = 5;
                break;
            case eCrop.Corn:
                outVal = 5;
                break;
            case eCrop.Melon:
                outVal = 5;
                break;
            case eCrop.Carrot:
                outVal = 5;
                break;
            default:
                outVal = 5;
                break;
        }

        return outVal;
    }

    private static float[] CropResourceValues(eCrop cropType)
    {
        float[] values = new float[(int)eResource.ResourceCount];

        switch (cropType)
        {
            case eCrop.GreenBean:
                values[(int)eResource.Nitrogen] = -1.5f;
                values[(int)eResource.Potassium] = 0.1f;
                values[(int)eResource.Phosphorous] = 0.1f;
                values[(int)eResource.Water] = 1.0f;
                break;
            case eCrop.Corn:
                values[(int)eResource.Nitrogen] = 1.0f;
                values[(int)eResource.Potassium] = 0.1f;
                values[(int)eResource.Phosphorous] = 0.1f;
                values[(int)eResource.Water] = 1.0f;
                break;
            case eCrop.Melon:
                values[(int)eResource.Nitrogen] = 0.1f;
                values[(int)eResource.Potassium] = 0.1f;
                values[(int)eResource.Phosphorous] = 1.0f;
                values[(int)eResource.Water] = 1.0f;
                break;
            case eCrop.Carrot:
                values[(int)eResource.Nitrogen] = 0.1f;
                values[(int)eResource.Potassium] = 1.0f;
                values[(int)eResource.Phosphorous] = 0.1f;
                values[(int)eResource.Water] = 1.0f;
                break;
            default:
                values[(int)eResource.Nitrogen] = 0.0f;
                values[(int)eResource.Potassium] = 0.0f;
                values[(int)eResource.Phosphorous] = 0.0f;
                values[(int)eResource.Water] = 0.0f;
                break;
        }
        return values;
    }
}
