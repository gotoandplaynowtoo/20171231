using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Array helper class.
/// </summary>
public static class ULibXArrayHelper
{

    /// <summary>
    /// Convert array to string.
    /// </summary>
    /// <typeparam name="T">Generic wild card for type.</typeparam>
    /// <param name="arr">List object of type T.</param>
    /// <returns>Concatenated string array values.</returns>
    public static string ArrayToString<T>(List<T> arr)
    {
        string output = "";
        for (int i = 0; i < arr.Count; i++)
        {
            output += arr[i].ToString();
            if (i >= 0 && i != arr.Count - 1)
            {
                output += ", ";
            }
        }

        return output;
    }//END OF ArrayToString method

    /// <summary>
    /// Swaps an array value.
    /// </summary>
    /// <typeparam name="T">Generic wild card for type.</typeparam>
    /// <param name="arr">List object of type T.</param>
    /// <param name="idx1">First target index to swap with the second target index.</param>
    /// <param name="idx2">Second target index to swap with the first target index.</param>
    public static void Swap<T>(List<T> arr, int idx1, int idx2)
    {
        T temp = arr[idx1];
        arr[idx1] = arr[idx2];
        arr[idx2] = temp;
    }//END OF Swap method

    /// <summary>
    /// Shuffle an array
    /// </summary>
    /// <typeparam name="T">Generic wild card for type.</typeparam>
    /// <param name="arr">Array to shuffle.</param>
    public static void Shuffle<T>(List<T> arr)
    {
        int len = arr.Count;
        int i = 0;

        while (len > 0)
        {
            i = Mathf.FloorToInt(Random.value * len--);
            Swap<T>(arr, i, len);
        }

    }//END OF Shuffle method

}//END of class LXArrayHelper
