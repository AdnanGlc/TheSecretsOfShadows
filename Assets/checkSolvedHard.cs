using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkSolvedHard : MonoBehaviour
{
    //btn1-7
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject btn5;
    public GameObject btn6;
    public GameObject btn7;
    //lb1-9
    public GameObject lb1;
    public GameObject lb2;
    public GameObject lb3;
    public GameObject lb4;
    public GameObject lb5;
    public GameObject lb6;
    public GameObject lb7;
    public GameObject lb8;
    public GameObject lb9;
    //
    public GameObject cube;
    //max number of inputs
    int maxInputs = 6;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //lb1
        if (getButonState(btn2) || getButonState(btn3))
            CallUpdateMaterial(lb1);
        else CallUpdateMaterial(lb1, false);
        //lb2
        if (getButonState(btn4) || getButonState(btn4))
            CallUpdateMaterial(lb2);
        else CallUpdateMaterial(lb2, false);
        //lb3
        if (getButonState(btn1) && CallGetLBstate(lb1) == false)
            CallUpdateMaterial(lb3);
        else CallUpdateMaterial(lb3, false);
        //lb4
        if (!CallGetLBstate(lb1) != !CallGetLBstate(lb2))
            CallUpdateMaterial(lb4);
        else CallUpdateMaterial(lb4, false);
        //lb5
        if (getButonState(btn6) && !CallGetLBstate(lb2))
            CallUpdateMaterial(lb5);
        else CallUpdateMaterial(lb5, false);
        //lb6
        if (getButonState(btn7) && getButonState(btn6))
            CallUpdateMaterial(lb6);
        else CallUpdateMaterial(lb6, false);
        //lb7
        if (!CallGetLBstate(lb3) || CallGetLBstate(lb4))
            CallUpdateMaterial(lb7);
        else CallUpdateMaterial(lb7, false);
        //lb8
        if (CallGetLBstate(lb4) != CallGetLBstate(lb5))
            CallUpdateMaterial(lb8);
        else CallUpdateMaterial(lb8, false);
        //lb9
        if (CallGetLBstate(lb5) && CallGetLBstate(lb6))
            CallUpdateMaterial(lb9);
        else CallUpdateMaterial(lb9, false);
        //solved
        if (!CallGetLBstate(lb7) && CallGetLBstate(lb8) && CallGetLBstate(lb9))
            CallUpdateMaterial(cube);
        else CallUpdateMaterial(cube, false);
        checkReset();
    }

    private void checkReset()
    {
        int timesPressed = 0;
        timesPressed += getNumberPressed(btn1);
        timesPressed += getNumberPressed(btn2);
        timesPressed += getNumberPressed(btn3);
        timesPressed += getNumberPressed(btn4);
        timesPressed += getNumberPressed(btn5);
        timesPressed += getNumberPressed(btn6);
        timesPressed += getNumberPressed(btn7);
        if (timesPressed > maxInputs)
        {
            callResetCounter(btn1);
            callResetCounter(btn2);
            callResetCounter(btn3);
            callResetCounter(btn4);
            callResetCounter(btn5);
            callResetCounter(btn6);
            callResetCounter(btn7);
            if (getButonState(btn1))
            {
                buttonPress bp = btn1.GetComponent<buttonPress>();
                bp.changeState(0);
            }
            if (getButonState(btn2))
            {
                buttonPress bp = btn2.GetComponent<buttonPress>();
                bp.changeState(0);
            }
            if (!getButonState(btn3))
            {
                buttonPress bp = btn3.GetComponent<buttonPress>();
                bp.changeState(0);
            }
            if (!getButonState(btn4))
            {
                buttonPress bp = btn4.GetComponent<buttonPress>();
                bp.changeState(0);
            }
            if (!getButonState(btn5))
            {
                buttonPress bp = btn5.GetComponent<buttonPress>();
                bp.changeState(0);
            }
            if (getButonState(btn6))
            {
                buttonPress bp = btn6.GetComponent<buttonPress>();
                bp.changeState(0);
            }
            if (getButonState(btn7))
            {
                buttonPress bp = btn7.GetComponent<buttonPress>();
                bp.changeState(0);
            }
        }
    }

    void CallUpdateMaterial(GameObject go, bool turnedOn = true)
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
    int getNumberPressed(GameObject go)
    {
        buttonPress script = go.GetComponent<buttonPress>();
        return script.getPressedCounter();
    }
    void callResetCounter(GameObject go)
    {
        buttonPress script = go.GetComponent<buttonPress>();
        script.resetPressedCounter();
    }
}

//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class checkSolvedHard : MonoBehaviour
//{
//    public List<GameObject> buttons = new List<GameObject>(); // List for buttons
//    public List<GameObject> lightbulbs = new List<GameObject>(); // List for labels
//    public GameObject cube;

//    int maxInputs = 6;

//    void Update()
//    {
//        // Iterate through labels
//        for (int i = 0; i < lightbulbs.Count; i++)
//        {
//            bool state = false;
//            switch (i)
//            {
//                case 0: // lb1
//                    state = getButtonState(buttons[1]) || getButtonState(buttons[2]);
//                    break;
//                case 1: // lb2
//                    state = getButtonState(buttons[3]) || getButtonState(buttons[4]);
//                    break;
//                case 2: // lb3
//                    state = getButtonState(buttons[0]) && !getLabelState(lightbulbs[0]);
//                    break;
//                case 3: // lb4
//                    state = !getLabelState(lightbulbs[0]) != !getLabelState(lightbulbs[1]);
//                    break;
//                case 4: // lb5
//                    state = getButtonState(buttons[5]) && !getLabelState(lightbulbs[1]);
//                    break;
//                case 5: // lb6
//                    state = getButtonState(buttons[6]) && getButtonState(buttons[5]);
//                    break;
//                case 6: // lb7
//                    state = !getLabelState(lightbulbs[2]) || getLabelState(lightbulbs[3]);
//                    break;
//                case 7: // lb8
//                    state = getLabelState(lightbulbs[3]) != getLabelState(lightbulbs[4]);
//                    break;
//                case 8: // lb9
//                    state = getLabelState(lightbulbs[4]) && getLabelState(lightbulbs[5]);
//                    break;
//            }
//            CallUpdateMaterial(lightbulbs[i], state); // Update label material based on state
//        }

//        // Check for cube solved
//        bool cubeSolved = !getLabelState(lightbulbs[6]) && getLabelState(lightbulbs[7]) && getLabelState(lightbulbs[8]);
//        CallUpdateMaterial(cube, cubeSolved);

//        // Check for button press reset
//        checkReset();
//    }

//    void checkReset()
//    {
//        int timesPressed = 0;
//        foreach (var button in buttons)
//        {
//            timesPressed += getNumberPressed(button);
//        }

//        if (timesPressed > maxInputs)
//        {
//            foreach (var button in buttons)
//            {
//                callResetCounter(button);
//                if (getButtonState(button))
//                {
//                    buttonPress bp = button.GetComponent<buttonPress>();
//                    bp.changeState(0);
//                }
//            }
//        }
//    }

//    void CallUpdateMaterial(GameObject go, bool turnedOn = true)
//    {
//        turnOnOff script = go.GetComponent<turnOnOff>();
//        script.UpdateMaterial(turnedOn);
//    }

//    bool getButtonState(GameObject go)
//    {
//        buttonPress script = go.GetComponent<buttonPress>();
//        return script.getBtnState();
//    }

//    bool getLabelState(GameObject go)
//    {
//        turnOnOff script = go.GetComponent<turnOnOff>();
//        return script.getLBstate();
//    }

//    int getNumberPressed(GameObject go)
//    {
//        buttonPress script = go.GetComponent<buttonPress>();
//        return script.getPressedCounter();
//    }

//    void callResetCounter(GameObject go)
//    {
//        buttonPress script = go.GetComponent<buttonPress>();
//        script.resetPressedCounter();
//    }
//}
