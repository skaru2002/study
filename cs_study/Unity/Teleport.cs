using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject Player;
    public GameObject Character;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Character = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void _Teleport()
    {
        Player.transform.position = new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z);
    }
    public void _Sit()
    {
        Character.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Character.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        Character.GetComponent<Character>()._Sit();
    }
    public void _VideoStart()
    {

    }
}
