using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;



public class ColorChange : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Text = null;
    // Start is called before the first frame update

    void Start()
    {
        // ê‘êFÇ…
        Text.outlineColor = new Color(1, 0, 0, 1);
    }
}
