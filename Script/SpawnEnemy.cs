using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject healthPrefab;
    public GameObject bossPrefab;
    public GameObject[] EnemyPrefab;
    
    public int MonsterCount, MaxMonsterCount, MaxMonsterCount2 ;
     public float MaxTimeReSpawn, MinTimeReSpawn;
     public List<GameObject> Monster = new List<GameObject>();
     public Transform[] SpawnPoint;
     public bool isSpawning;
    public bool isEnemy1 = false;
    public bool isEnemy2 = false;
    public bool isBossSpawn = false;
    public static SpawnEnemy instance;

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
     {
         // CreateEnemy();
         InvokeRepeating("ReSpawningWithTime", 0, 0.5f);
     }

     // Update is called once per frame
     void Update()
     {

        

     }
     public void ReSpawningWithTime()
     {
         StartCoroutine(Spawning());
     }

     public IEnumerator Spawning()
     {
         if (!isSpawning)
         {
             isSpawning = true;
             yield return new WaitForSeconds(Random.Range(MinTimeReSpawn, MaxTimeReSpawn));
             CreateEnemyType2();
             isSpawning = false;

         }
     }


    public void CreateEnemyType2()
    {
        if (Player.instance.isLowHp && !Player.instance.isUseHealPack)
        {
            int rndSP = Random.Range(0, SpawnPoint.Length);
            GameObject thisHealPack =
            Instantiate(healthPrefab, SpawnPoint[rndSP].position, transform.rotation);
            thisHealPack.transform.parent = SpawnPoint[rndSP].transform;
           /* switch (thisHealPack.transform.parent.name)
            {
                case "SpawnMon":
                    thisHealPack.transform.localPosition = new Vector3(85, 91, 0);
                    break;
                case "SpawnMon (1)":
                    thisHealPack.transform.localPosition = new Vector3(85, 91, 0);
                    break;
                case "SpawnMon (2)":
                    thisHealPack.transform.localPosition = new Vector3(701, 59, 0);
                    break;
                case "SpawnMon (3)":
                    thisHealPack.transform.localPosition = new Vector3(701, 59, 0);
                    break;
                default:
                    break;
            }*/
            thisHealPack.transform.parent = transform;
            thisHealPack.transform.localScale = Vector3.one;
            Transform healPackTransform = thisHealPack.transform;
            ExampleGestureHandler.instance.referenceRoot.Add(healPackTransform);
            ExampleGestureHandler.instance.UpdateRef(healPackTransform);
            Player.instance.isUseHealPack = true;
        }
        //  def mc : 0 , maxMc : 10
        //  stop at => mc : 10 == maxMc : 10    , monRemain : 1 | spawn boss affect to if player who can kill the boss successfully will be able to complete the game. cause mc--
       
        if (MonsterCount + 1 == MaxMonsterCount && !isBossSpawn && Gamemanager.Instance.monsterRemain > 0 && !Gamemanager.Instance.isBoss)
        {
            isBossSpawn = true;
        }
        //  mc : .. . < maxMc : 10
        //  stop at => mc : 9+(1) < maxMc : 10 , monRemain : 1  | monster not spawn affect to mc can't complete the game.
        else if (MonsterCount + 1 < MaxMonsterCount)
        {
            GameObject thisMonster =
             Instantiate(EnemyPrefab[Random.Range(0, EnemyPrefab.Length)], SpawnPoint[Random.Range(0, SpawnPoint.Length)].position, transform.rotation);
            thisMonster.transform.parent = transform;
            thisMonster.transform.localScale = new Vector3(1, 1, 1);



            Transform monTransform = thisMonster.transform;
            ExampleGestureHandler.instance.referenceRoot.Add(monTransform);
            ExampleGestureHandler.instance.UpdateRef(monTransform);

            MonsterCount++;
            /*Monster.Add(thisMonster);
             MonsterCount = Monster.Count;*/

        }
        
 

        if (isBossSpawn)
        {
            GameObject thisMonster =
            Instantiate(bossPrefab, SpawnPoint[Random.Range(0, SpawnPoint.Length)].position, transform.rotation);
            thisMonster.transform.parent = transform;
            thisMonster.transform.localScale = new Vector3(1, 1, 1);



            Transform monTransform = thisMonster.transform;
            ExampleGestureHandler.instance.referenceRoot.Add(monTransform);
            ExampleGestureHandler.instance.UpdateRef(monTransform);
            Gamemanager.Instance.isBoss = true;
            isBossSpawn = false;
        }

    }
}
