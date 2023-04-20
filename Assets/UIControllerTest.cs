using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerTest : MonoBehaviour
{
    [SerializeField] Text information;

    public void OnButtonPressed()
    {
        information.text = "Tested";
    }
}
