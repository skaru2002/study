using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameRate : MonoBehaviour
{
    float Frame = 0f;
    float Fps = 0f;
    float TextTime = 0f;
    public Text fpsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Frame += Time.unscaledDeltaTime - Frame;
        TextTime += Time.deltaTime;
        Fps = 1 / Frame;

        if(TextTime > 0.5f)
        {
            fpsText.text = string.Format("{0: 0. }fps", Fps);
            TextTime = 0f;
        }
    }
}
