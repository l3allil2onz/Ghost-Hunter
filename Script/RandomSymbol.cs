using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSymbol : MonoBehaviour
{
    public Image Symbol1;
    public Image Symbol2;
    public int pick;

    Image[] pics;
    int i;
    
    // Use this for initialization
    void Start()
    {
        pics = new Image[2];

        pics[0] = Symbol1;
        pics[1] = Symbol2;

    }

    // Update is called once per frame
    void Update()
    {
        i = pick;
        while (i == pick)
        {
            pick = Random.Range(0, 2);
        }
    }
}

    
