using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class fps_controller : MonoBehaviour
{
    public TextMeshProUGUI FPS_text;
    private float pollingTime = 1f;

  
    private float time;
    private int frameCount;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 90;




    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FPS_text.text = frameRate.ToString() + " FPS";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
