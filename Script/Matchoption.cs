
using System.Collections;
using System.Collections.Generic;
using GestureRecognizer;
using UnityEngine;
using UnityEngine.UI;

public class Matchoption : MonoBehaviour
{

    //public Dropdown dropdownMin;
   // public Dropdown dropdownMax;
    //public Dropdown dropdownThreads;
    public Text textTime;

    public DrawDetector[] detectors;

    public Recognizer recognizer;
    public UILineRenderer line;

    void OnEnable()
    {
        foreach (var detector in detectors)
        {
            detector.OnRecognize.AddListener(RecognitionResult);
            print("jjj");
        }
    }
    void OnDisable()
    {
        if (Application.isPlaying)
        {
            foreach (var detector in detectors)
            {
                detector.OnRecognize.RemoveListener(RecognitionResult);
            }
        }
    }

    void RecognitionResult(RecognitionResult result)
    {
        
        //textTime.text = string.Format("{0:0.000}s", result.recognitionTime);
    }

    /*public void OnChangeMinMax()
    {
        int min = dropdownMin.value + 1;
        int max = dropdownMax.value + 1;
        foreach (var detector in detectors)
        {
            detector.MinLines = min;
            detector.MaxLines = max;
            detector.ClearLines();
        }
    }
    public void OnChangeThreads()
    {
        int n_threads = dropdownThreads.value + 1;
        recognizer.numberOfThreads = n_threads;
    }*/
    public void OnDestroy()
    {
        Destroy(line);
        Debug.Log("des");
    }
}
