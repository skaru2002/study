    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void _Sit()
    {
        anim.SetTrigger("_Sit");
    }
    public void _Idle()
    {
        anim.SetTrigger("_Idle");
    }
    public void _UP()
    {
        anim.SetTrigger("_UP");
    }
    public void _Talk()
    {
        if (true)
        {
            anim.SetTrigger("_Talk");
        }
        else
        {
            anim.SetTrigger("_Idle");
        }
    }
}
