using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour {
    public Image fill;
    Player player;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").
            GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        fill.fillAmount = player.CurrentHp / player.MaxHp;
    }
}
