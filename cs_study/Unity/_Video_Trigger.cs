using UnityEngine;
using UnityEngine.Video;

public class _Video_Trigger : monobehaviour
{
    public GameObject screen;

    void Start
    {
        screen = GameObject.Find("Screen");
        screen.SetActive(false);
    }
    void Update
    {

    }

    private void OnTriggerEnter(collider other)
    {
        if (other)
        {
            screen.SetActive(true);
        }
    }
    private void OnTriggerExit(collider other)
    {
        if(other)
        {
            screen.SetActive(false);
        }
    }


}