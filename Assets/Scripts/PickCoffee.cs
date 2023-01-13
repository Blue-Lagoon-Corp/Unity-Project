using UnityEngine;
using TMPro;

public class PickCoffee : MonoBehaviour
{
    public TextMeshProUGUI score;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            int oldScore = int.Parse(score.text)+10;
            score.text = ""+oldScore;
            gameObject.SetActive(false);
        }
    }
}
