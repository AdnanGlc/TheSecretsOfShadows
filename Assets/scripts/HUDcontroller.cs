using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDcontroller : MonoBehaviour
{
    public static HUDcontroller instance;
    public void Awake()
    {
        instance = this;
    }
    [SerializeField] TMP_Text interactionText;
    public void EnableInteractionText(string text)
    {
        interactionText.text = text;
        interactionText.gameObject.SetActive(true);
    }
    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}
