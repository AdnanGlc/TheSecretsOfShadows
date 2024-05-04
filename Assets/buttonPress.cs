using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class buttonPress : MonoBehaviour
{
    public bool state = false;
    int pressedCounter = 0;
    private void Start()
    {
        turnOnOff script = this.GetComponent<turnOnOff>();
        script.UpdateMaterial(state);
    }
    private void OnMouseUpAsButton()
    {
       changeState();
    }
    public bool getBtnState()
    {
        return state;
    }
    public int getPressedCounter()
    {
        return pressedCounter;
    }
    public void resetPressedCounter()
    {
        pressedCounter = 0;
    }
    public void changeState(int counter=1)
    {
        state = !state;
        turnOnOff script = this.GetComponent<turnOnOff>();
        script.UpdateMaterial(state);
        pressedCounter+=counter;
    }

}
