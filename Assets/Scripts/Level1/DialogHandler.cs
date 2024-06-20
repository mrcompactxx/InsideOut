using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DialogHandler : MonoBehaviour
{
    private int index = 0;
    public float speed;
    internal static DialogHandler Instance;
    public string[] sentences;
    [SerializeField]private TextMeshProUGUI text;
     

    void Start()
    {
        text.text = "";
        Instance = this;
    }

    void Update()
    {
        
            if (text.text == sentences[index]) 
            {
                NextLine();
            }
    }

    internal IEnumerator ReadLines() 
    {
        foreach (char i in sentences[index].ToCharArray()) 
        {
            text.text += i;
            yield return new WaitForSeconds(speed);
        }

    }
    //sentences = 4;
    //index = 0;
    private void NextLine() 
    {
        if (index < sentences.Length-1) 
        {
            index++;
            text.text = "";
            StartCoroutine(ReadLines());
        }
    }


}
