using UnityEngine;
using System.Collections;

public class ULibXWeightedRandom : MonoBehaviour {

    public WeightedObject[] weightedObjects;

    float overAllTotalWeight;

    [System.Serializable]
	public class WeightedObject
    {
        public GameObject gameObject;
        public float weight;
    }

    void Start()
    {
        for(int i = 0, len = weightedObjects.Length; i < len; i++)
        {
            overAllTotalWeight += weightedObjects[i].weight;
        }

    }//END OF start METHOD

    public GameObject getObject()
    {
        GameObject obj = null;
        float totalWeight = 0f;
        int len = weightedObjects.Length;

        if (len > 0)
        {
            float randValue = Random.Range(0, overAllTotalWeight);
            for(int i = 0; i < len; i++)
            {
                totalWeight += weightedObjects[i].weight;
                if(randValue <= totalWeight)
                {
                    return weightedObjects[i].gameObject;
                }
            }
        }

        return obj;
    }

}//END OF class ULibxWeightedRandom
