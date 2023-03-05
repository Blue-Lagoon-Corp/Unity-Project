using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintHallOfFame : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WebManager.Instance.GetHallOfFame(text));
    }
}
