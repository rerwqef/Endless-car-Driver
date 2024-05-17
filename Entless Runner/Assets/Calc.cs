using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calc : MonoBehaviour
{
    public TextMeshProUGUI BtnPressingVal;
    public TextMeshProUGUI finalamounttext;
    int amount;
    // List<int> btnValues=new List<int>();
    public string previousone = "";


    private void Start()
    {
        BtnPressingVal.text = "0";
    }
    public void Passvalue(int val)
    {
        //btnValues.Add(val);
        amount += val;
        UpdateUi(val);
    }
    public void PressplusBrn()
    {
        previousone += "+";
        BtnPressingVal.text = previousone;
    }
public void UpdateUi(int val)
    {
        BtnPressingVal.text=previousone + + val;
        previousone +=   val.ToString();
    }

    public void FinalResult()
    {
        finalamounttext.text = amount.ToString();
    }
}
