using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    public Image Recticle;
    float FullTime = 0.5f;
    bool RecticleStatus = false;
    float RecticleTime = 0f;
    
    public Transform MyPos;
    bool isGrab = false;
    public GameObject[] onTablePosition;
    
    bool isPlay = false;
    public GameObject startText;
    public GameObject stopText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (RecticleStatus == true)
        {
            //Recticle.fillAmount = 0;
            RecticleTime += Time.deltaTime;
            Recticle.fillAmount = RecticleTime / FullTime;
        }

        if (isGrab == true)
        {
            for (int i = 0; i < onTablePosition.Length; i++)
            {
                onTablePosition[i].layer = 8;
                onTablePosition[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < onTablePosition.Length; i++)
            {
                onTablePosition[i].layer = 0;
                onTablePosition[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }

        if (isPlay ==true)
        {
            startText.SetActive(false);
            stopText.SetActive(true);
        }
        else
        {
            startText.SetActive(true);
            stopText.SetActive(false);
        }

        RayCasting();
    }

    void RayCasting()
    {
        
        RaycastHit Hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray,out Hit,30f,1<<8))
        {
            RecticleON();

            if (Hit.transform.tag == "_Teleport" && Recticle.fillAmount == 1)
            {
                Hit.transform.GetComponent<Teleport>()._Teleport();
                RecticleOFF();
            }
            if (Hit.transform.tag == "_Sit" && Recticle.fillAmount == 1)
            {
                Hit.transform.GetComponent<Character>()._Sit();
                RecticleOFF();
            }
            if (Hit.transform.tag == "_Videostart" && Recticle.fillAmount == 1 && isPlay == false)
            {
                Hit.transform.GetComponent<Video_Trigger>()._VideoStart();
                isPlay = true;
                RecticleOFF();
            }
            else if (Hit.transform.tag == "_Videostop" && Recticle.fillAmount ==1 && isPlay == true)
            {
                Hit.transform.GetComponent<Video_Trigger>()._VideoStop();
                isPlay = false;
                RecticleOFF();
            }
            if (Hit.transform.tag == "_Pickup" && Recticle.fillAmount == 1 && isGrab == false)
            {
                Hit.transform.parent = MyPos;
                MyPos.GetChild(0).localPosition = new Vector3(0, 0, 0);
                isGrab = true;
                RecticleOFF();
            }
            else if (Hit.transform.tag == "_onTable" && Recticle.fillAmount == 1 && isGrab == true)
            {
                MyPos.GetChild(0).position = Hit.transform.position;
                MyPos.GetChild(0).eulerAngles = new Vector3(0, -90, 0);
                MyPos.GetChild(0).parent = null;

                isGrab = false;
                RecticleOFF();
            }
        }
        else
        {
            RecticleOFF();
        }
        Debug.DrawRay(transform.position, transform.forward * 30f, Color.red);
    }
    void RecticleON()
    {
        RecticleStatus = true;
    }
    void RecticleOFF()
    {
        RecticleStatus = false;
        RecticleTime = 0f;
        Recticle.fillAmount = 0f;
    }
}
