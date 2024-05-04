using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkSolved : MonoBehaviour
{
    //btn1-6
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject btn5;
    public GameObject btn6;
    //lb1-5
    public GameObject lb1;
    public GameObject lb2;
    public GameObject lb3;
    public GameObject lb4;
    public GameObject lb5;
    //ladica neka
    public GameObject cube;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //lb11
        if (getButonState(btn1) || getButonState(btn2))
            CallUpdateMaterial(lb1);
        else CallUpdateMaterial(lb1, false);
        //lb2
        if (getButonState(btn3) && getButonState(btn4))
            CallUpdateMaterial(lb2);
        else CallUpdateMaterial(lb2, false);
        //lb3
        if(getButonState(btn5) && getButonState(btn6))
            CallUpdateMaterial(lb3);
        else
            CallUpdateMaterial(lb3, false);
        //lb4
        if (CallGetLBstate(lb1) == false && CallGetLBstate(lb2))
            CallUpdateMaterial(lb4);
        else CallUpdateMaterial(lb4, false);
        //lb5
        if (CallGetLBstate(lb2) && CallGetLBstate(lb3) == false)
            CallUpdateMaterial(lb5);
        else CallUpdateMaterial(lb5, false);

        if (CallGetLBstate(lb4) && CallGetLBstate(lb5))
            CallUpdateMaterial(cube);
        else CallUpdateMaterial(cube, false);

    }

    void CallUpdateMaterial(GameObject go,bool turnedOn = true)
    {
        turnOnOff script = go.GetComponent<turnOnOff>();
        script.UpdateMaterial(turnedOn);
    }
    bool getButonState(GameObject go)
    {
        buttonPress script = go.GetComponent<buttonPress>();
        return script.getBtnState();
    }
    bool CallGetLBstate(GameObject go)
    {
        turnOnOff script = go.GetComponent<turnOnOff>();
        return script.getLBstate();
    }

}
