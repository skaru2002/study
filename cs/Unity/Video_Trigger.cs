using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video_Trigger : MonoBehaviour
{

    public GameObject screen;
    public GameObject startText;
    public GameObject stopText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    private void OnTriggerEnter(Collider other)
    { 
        
        if (other)
        {
            screen.SetActive(true);
        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    VideoPlayer vp = screen.GetComponent<VideoPlayer>();
    //    if (other)
    //    {
    //        vp.Play();
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {

        if (other)
        {
            startText.SetActive(true);
            stopText.SetActive(false);
            screen.SetActive(false);
        }
    }
    public void _VideoStart()
    {
        VideoPlayer vp = screen.GetComponent<VideoPlayer>();
        vp.Play();
    }
    public void _VideoStop()
    {
        VideoPlayer vp = screen.GetComponent<VideoPlayer>();
        vp.Stop();
    }
}
