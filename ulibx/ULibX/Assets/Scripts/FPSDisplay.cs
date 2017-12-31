using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(ULibXFPSCounter))]
public class FPSDisplay : MonoBehaviour {

    public Text FPS;
    public Text AVG_FPS;
    public Text H_FPS;
    public Text L_FPS;

    ULibXFPSCounter FPSCounter;

    void Awake()
    {
        FPSCounter = GetComponent<ULibXFPSCounter>();
    }

    void Update()
    {
        FPS.text = FPSCounter.FPS.ToString();
        AVG_FPS.text = FPSCounter.AVG_FPS.ToString();
        H_FPS.text = FPSCounter.H_FPS.ToString();
        L_FPS.text = FPSCounter.L_FPS.ToString();
    }

}
