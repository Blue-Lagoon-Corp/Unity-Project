using UnityEngine;
using TMPro;

public class PickCoffee : MonoBehaviour
{
    public int scoreToGive;

    public float speedToAdd;

    private PlayerController player;

    private ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        player = FindObjectOfType<PlayerController>();
        
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
        }
    }
}
