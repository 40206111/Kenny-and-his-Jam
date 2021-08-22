using UnityEngine;
public class SoilData
{
    public float[] Resources = new float[(int)eResource.ResourceCount];

    float ResourceMax = 2.0f;
    float ResourceMin = 0.0f;

    public SoilData() : this(0.0f) { }
    public SoilData(float initVal)
    {
        for (int i = 0; i < Resources.Length; ++i)
        {
            Resources[i] = initVal;
        }
    }

    public void ChangeResourceLevel(int resource, float change)
    {
        Resources[resource] = Mathf.Clamp(Resources[resource] + change, ResourceMin, ResourceMax);
    }
}
