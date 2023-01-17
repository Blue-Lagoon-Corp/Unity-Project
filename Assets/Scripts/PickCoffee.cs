using UnityEngine;
using TMPro;
using System.Collections;

public class PickCoffee : MonoBehaviour
{
    public int scoreToGive;

    public float speedToAdd;

    //public TextMeshProUGUI bonusText;

    private PlayerController player;

    private ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        player = FindObjectOfType<PlayerController>();
        //bonusText.enabled = false;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            scoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
            player.AddSpeed(speedToAdd);
            //TextCooldown();
        }
    }

    /*public IEnumerator TextCooldown()
    {
        bonusText.enabled = true;
        yield return new WaitForSeconds(2f);
        bonusText.enabled = false;
    }*/
}
