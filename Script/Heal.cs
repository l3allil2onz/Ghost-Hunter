using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public Animator anim;
    public bool isDead = false;
    public static Heal instance;
    public float MaxHp, CurrentHp;
    ExampleGestureHandler egh;

    private void Awake()
    {
        instance = this;
        egh = ExampleGestureHandler.instance;
    }
    void Start ()
    {
        anim = GetComponent<Animator>();
	}
    private void Update()
    {
        if (transform.GetChild(0).childCount <= 0 && !isDead)
        {
            CurrentHp = 0;
        }

        if (CurrentHp <= 0 && !isDead)
        {
            anim.SetBool("Dead", true);
            isDead = true;
        }
        else if (isDead)
        {
            anim.SetBool("IsDie", false);
        }
    }

    public void HealPlayer()
    {
        Player.instance.CurrentHp += 20;
    }
    public void DestroySelf()
    {
        GetEnemyIndexToRemove();
        Destroy(gameObject);
    }
    public void GetEnemyIndexToRemove()
    {
        int index = egh.referenceRoot.FindIndex(x => x.name == this.name);
        egh.referenceRoot.RemoveAt(index);
    }
}
