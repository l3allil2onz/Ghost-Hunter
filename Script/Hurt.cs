using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public Gamemanager GM;
    Animator anim;




    public float TakeDamage;
    // Use this for initialization
    void Start()
    {
        GM = GameObject.Find("CanvasOverlay").GetComponent<Gamemanager>();
         anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
          
            GM.curentTime += TakeDamage;
            anim.SetBool("Hurt", false);
        }
    }
}
