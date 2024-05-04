using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnOff : MonoBehaviour
{
    // Start is called before the first frame update
    public bool state = false;
    public Material redMaterial;
    public Material yellowMaterial;
    private Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    public void UpdateMaterial(bool turnedOn)
    {
        state = turnedOn;
        // Change the material based on the state
        if (state)
        {
            renderer.material = yellowMaterial;
        }
        else
        {
            renderer.material = redMaterial;
        }
    }
    public bool getLBstate()
    {
        return state;
    }
}
