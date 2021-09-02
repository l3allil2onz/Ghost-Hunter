using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GestureRecognizer;

public class Player : MonoBehaviour {

    public Animator anim;
    Rigidbody2D rb;
    //Status Player
    public float MaxHp, CurrentHp;
    public float Damage;
    public bool IsDie;
    public bool isLowHp = false;
    public bool isUseHealPack = false;
    public int NumberSkillUse;
    public DrawDetector[] detectors;
    int i = 0;
    public static Player instance;
    
    //public List<GesturePatternDraw> references = new List<GesturePatternDraw>();

    public GameObject Floor;
    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHp <= 0 && !IsDie && !isLowHp)
        {
            anim.SetBool("Dead", true);
            IsDie = true;
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<Collider2D>().enabled = false;
            // GetComponentInChildren<HpBarObj>().gameObject.SetActive(false);

        }
        else if(CurrentHp <= 70 && !IsDie && !isLowHp)
        {
            isLowHp = true;
        }

    }
    public void ResetDieAnimation()
    {
        anim.SetBool("IsDie", false);
    }
    public void EndAnimation_Attack1()
    {
        anim.SetBool("Attack1", false);
    }
    public void EndAnimation_Attack2()
    {
        anim.SetBool("Attack2", false);
    }
    public void EndAnimation_Attack3()
    {
        anim.SetBool("Attack3", false);
    }
    public void EndAnimation_Attack4()
    {
        anim.SetBool("Attack4", false);
    }
    public void EndAnimation_Attack5()
    {
        anim.SetBool("Attack5", false);
    }
    public void EndAnimation_Attack6()
    {
        anim.SetBool("Attack6", false);
    }
    public void EndAnimation_Attack7()
    {
        anim.SetBool("Attack7", false);
    }
    public void HurtAnimation()
    {
        anim.SetBool("Hurt", false);
    }


}
