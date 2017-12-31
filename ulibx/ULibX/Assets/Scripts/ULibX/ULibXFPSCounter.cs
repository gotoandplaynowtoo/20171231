using UnityEngine;
using System.Collections;

/// <summary>
/// Class for measuring FPS(Frame per second).
/// </summary>
public class ULibXFPSCounter : MonoBehaviour
{

    public bool isDebug = false;
    public int maxFrame = 60;

    public int FPS { get; private set; }
    public int AVG_FPS { get; private set; }
    public int H_FPS { get; private set; }
    public int L_FPS { get; private set; }

    int[] FPSBuffer;
    int FPSBufferIdx;

    void Awake()
    {

        if (maxFrame <= 0)
        {
            maxFrame = 1;
        }

        FPSBuffer = new int[maxFrame];
        FPSBufferIdx = 0;

    }//END OF Awake method

    void Update()
    {
        UpdateFPS();
        UpdateFPSBuffer();
        UpdateAVG_FPS();

        if (isDebug)
        {
            Debug.Log(
                "FPS: " + FPS
                + ", AVG_FPS: " + AVG_FPS
                + ", L_FPS: " + L_FPS
                + ", H_FPS: " + H_FPS
                );
        }

    }//END OF Update method

    /// <summary>
    /// Updates the FPS property.
    /// </summary>
    void UpdateFPS()
    {
        FPS = (int)(1f / Time.unscaledDeltaTime);
    }//END OF updateFPS method

    /// <summary>
    /// Updates the FPS buffer property.
    /// </summary>
    void UpdateFPSBuffer()
    {
        FPSBuffer[FPSBufferIdx++] = (int)(1f / Time.unscaledDeltaTime);
        FPSBufferIdx = (int)(FPSBufferIdx % maxFrame);
    }//END OF UpdateFPSBuffer method

    /// <summary>
    /// Updates average FPS property. Also calculates the lowest and highest FPS.
    /// </summary>
    void UpdateAVG_FPS()
    {

        int sum = 0;
        int highest = 0;
        int lowest = int.MaxValue;
        int fps;

        for (int i = 0; i < maxFrame; i++)
        {
            fps = FPSBuffer[i];
            sum += fps;

            if (fps > highest)
            {
                highest = fps;
            }

            if (fps < lowest)
            {
                lowest = fps;
            }
        }//END OF FOR LOOP

        AVG_FPS = sum / maxFrame;
        H_FPS = highest;
        L_FPS = lowest;

    }//END OF UpdateAVG_FPS method

}//END OF class FPSCounter
