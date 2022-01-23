using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float Speed = 100f;
    public float moveSpeed = 1f;

    float mouseX;
    float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");

            mouseX += h * Speed * Time.deltaTime;
            mouseY += v * Speed * Time.deltaTime;

            if (mouseX > 90)
            {
                mouseX = 90;
            }
            else if (mouseY <= -90)
            {
                mouseY = -90;
            }
            transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
        }
    }
}
