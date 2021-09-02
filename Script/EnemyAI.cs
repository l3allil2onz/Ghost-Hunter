using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public int score;
    public GameObject player;
    public GameObject enemy;
    public float moveSpeed;
    float scaleX;
    public Animator anim;
    public GameObject Floor;

    public float MaxHp, CurrentHp;
    public float Damage;
    public bool IsDie;
    //  Boss
    public float distanceBounceOff = 100f;
    ExampleGestureHandler egh;
    Gamemanager gm;


    public List<string> symbol = new List<string>();


    private void Awake()
    {
        gm = Gamemanager.Instance;
        egh = ExampleGestureHandler.instance;
        player = GameObject.Find("Player");
        
        anim = GetComponent<Animator>();
        scaleX = transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).childCount <= 0 && !IsDie)
        {
            CurrentHp = 0;
        }

        if (CurrentHp <= 0 && !IsDie)
        {
            
            anim.SetBool("IsDie", true);
            //GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<Collider2D>().enabled = false;
            // GetComponentInChildren<HpBarObj>().gameObject.SetActive(false);
            IsDie = true;

        }
        else if (!IsDie)
        {
            Seeking();
        }
        else if (IsDie)
        {
            anim.SetBool("IsDie", false);
        }

        if (!IsDie && gm.isBoss && gm.drawCorrectCount >= 8)
        {
            if (scaleX < 0)
            {
                transform.localPosition -= new Vector3(distanceBounceOff, 0, 0);
                gm.drawCorrectCount = 0;
            }
            else if (scaleX > 0)
            {
                transform.localPosition += new Vector3(distanceBounceOff, 0, 0);
                gm.drawCorrectCount = 0;
            }
        }
    }
    
    public void DestroySelf()
    {
        Gamemanager.Instance.score += (score * Gamemanager.Instance.comboScoreMultiplier);
        Gamemanager.Instance.monsterRemain--;
        GetEnemyIndexToRemove();
        Destroy(gameObject);
    }
    public void GetEnemyIndexToRemove()
    {
        int index = egh.referenceRoot.FindIndex(x => x.name == this.name);
        egh.referenceRoot.RemoveAt(index);
    }
    void Seeking()
    {
        //  Example : 114(itself) - 9(player) = 105(result)
        float distance = transform.position.x - player.transform.position.x;  //หาระยะห่าง
       // Debug.Log(distance);
        //เปลี่นอนิเมชั่น
        //Debug.Log(distance);

        //  ((9,0,0)(v3) - (9,0,0)(v3)).nor.x * -1.33 * time
        //  0 * -1.33 * 1(sec.)
        //  ((8,0,0)(v3) - (9,0,0)(v3)).nor.x * -1.33 * time
        //  -1 * -1.33 * 1(sec.)
        if (Mathf.Abs(distance) > 50f)
        {

            float offsetY = (transform.position - player.transform.position).normalized.y * -moveSpeed * Time.deltaTime; //ให้มันเดินไปข้างหน้า
            float offsetX = (transform.position - player.transform.position).normalized.x * -moveSpeed * Time.deltaTime; //ให้มันเดินไปข้างหน้า

            transform.position = transform.position + new Vector3(offsetX, offsetY, 0);
        }

        if (distance > 0) //กลับซ้ายขวา
        {
            transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);

        }
        else if (distance < 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);

        }
    }

    public void CompareSymbol(string symbol)
    {
        if (symbol == this.symbol[0])
        {
            CurrentHp -= 50;
            this.symbol.RemoveAt(0);
            
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", true);
        }

       
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Attack", false);

        }
    }
    public void TakeDamage()
    {
        Debug.Log("Tee");
        Player pc = player.GetComponent<Player>();
        pc.CurrentHp = (pc.CurrentHp - Damage <= 0) ? 0 : pc.CurrentHp - Damage;
        pc.GetComponent<Animator>().SetBool("Hurt", true);


    }
    public void FinishHurtAnimation()
    {
        anim.SetBool("Hurt", false);
    }

  
}



