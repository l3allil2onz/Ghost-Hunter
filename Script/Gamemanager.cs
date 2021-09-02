using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    //  Score
    //      curComboTimeDuration ต้องเป็น      0 ตลอด
    //      comboScoreMultiplier ค่าตั้งต้นเป็น   1 ตลอด
    //      score ค่าเริ่มต้นเป็น                 0 ตลอด
    public bool isCombo;
    public int score;
    public int comboScoreMultiplier = 1;
    private int multiplierPointValue = 0;
    private int unitPoint = 9;
    public float curComboTimeDuration;
    [Range(0,3)]
    public float comboTimeDuration;
    public GameObject comboDisplayObj;
    public Image comboColorImg;
    public Image comboDurationImg;
    public TextMeshProUGUI countOfMultiplierText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI displayTotalScore;
        public Color32[] comboColor = new Color32[4];
        public string[] comboStringText = new string[4];

    //  Monster
    #region monster
    public int monsterRemain;
    public int monsterCount;
    public TextMeshProUGUI displayMonsterRemain;
    public GameObject OverScreen, CompleteScreen;
    public GameObject PauseScreen;
    public bool IsPause;
    public float maxTime;
    public float curentTime;
    public int NumberStage;
    public bool IsShow;
    public float LifeCount;
    //  Boss
    public bool isBoss = false;
    public bool isEnemy1 = false;
    public int drawCorrectCount = 0;

    public static Gamemanager Instance;
    
    #endregion
    //public GameObject endsceness;
    //public GameObject endscenefail;
    //public HpBar Hp;
    //public bool true;
    // Use this for initialization
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        monsterCount = SpawnEnemy.instance.MaxMonsterCount;
        monsterRemain = monsterCount;
        curComboTimeDuration = comboTimeDuration;
        comboDurationImg.fillAmount = 1f;
        comboDisplayObj.SetActive(false);
        curentTime = maxTime;
    }
    void Update()
    {
        displayTotalScore.text = score.ToString();
        displayMonsterRemain.text = monsterRemain.ToString();
        LifeCount = Player.instance.CurrentHp;
        if (monsterRemain <= 0 && !CompleteScreen.activeSelf)
        {
            CompleteScreen.SetActive(true);
            Debug.Log("monsterCount : "+monsterCount);
        }
        if (LifeCount <= 0 && !OverScreen.activeSelf)
        {
            OverScreen.SetActive(true);
        }

       if (isCombo)
        {
            curComboTimeDuration -= Time.deltaTime;
            comboDurationImg.fillAmount = curComboTimeDuration / comboTimeDuration;
            countOfMultiplierText.text = "X" + comboScoreMultiplier.ToString();

            if (curComboTimeDuration <= 0 && comboDurationImg.fillAmount <= 0)
            {
                comboDisplayObj.SetActive(false);
                comboScoreMultiplier = 1;
                curComboTimeDuration = comboTimeDuration;
                isCombo = false;
            }
            else
            {
                if(comboScoreMultiplier > (multiplierPointValue + unitPoint) && comboScoreMultiplier <= 40)
                {
                    multiplierPointValue++;
                }

                switch (comboScoreMultiplier)
                {
                    case 1:
                        comboText.text = comboStringText[0];
                        comboColorImg.color = comboColor[0];
                        break;
                    case 10:
                        comboText.text = comboStringText[1];
                        comboColorImg.color = comboColor[1];
                        break;
                    case 20:
                        comboText.text = comboStringText[2];
                        comboColorImg.color = comboColor[2];
                        break;
                    case 40:
                        comboText.text = comboStringText[3];
                        comboColorImg.color = comboColor[3];
                        break;
                    default:
                        break;
                }
            }
        }

        if (curentTime > 0)
        {
            if (IsPause == false)
            {
               //score += 10 * Time.deltaTime;
                curentTime -= Time.deltaTime * 2;
            }
        }
        else
        {

            IsPause = true;
            //StartCoroutine(ShowResult(true));


        }

    }
    public void PauseGame(bool isPause)
    {

        IsPause = isPause;


        if (isPause)
        {


            Time.timeScale = 0;
            AudioListener.volume = 0f;

            PauseScreen.SetActive(true);
            Debug.Log(isPause);
        }
        else
        {

            Time.timeScale = 1;

            PauseScreen.SetActive(false);




        } // Pause Menu
    }
   
}
    
