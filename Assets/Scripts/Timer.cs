using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI m_txtTimer;

    private IEnumerator m_coroutineCompteur;

    // Start is called before the first frame update
    void Start()
    {
        m_coroutineCompteur = Compteur();
        StartCoroutine(m_coroutineCompteur);
    }

    IEnumerator Compteur()
    {
        for (int iTimer = 0; iTimer >= 0; iTimer++)
        {
            m_txtTimer.text = "" + iTimer;
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
