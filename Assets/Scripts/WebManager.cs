using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Text;


public class WebManager : MonoBehaviour
{
    public static WebManager Instance;
    public const string MESSAGE_OF_THE_DAY_URI = "http://krdr.alwaysdata.net/infoDuJour.php";
    public const string GET_HALL_OF_FAME_URI = "http://krdr.alwaysdata.net/scoreList.php?game=CoffeeRush";
    public const string SEND_SCORE = "http://krdr.alwaysdata.net/scoreForm.php";
    public const string GET_COFFEE_VOTES = "http://krdr.alwaysdata.net/voteList.php?groupe=BlueLagoon";
    public static string QuoteOfTheDay;
    public TextMeshProUGUI quoteRepo;
    public TextMeshProUGUI textZone;


    public void Awake()
    {
        if(null != Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(GetMessageOfTheDay());
        StartCoroutine(GetCoffeeVotes());
    }

    public IEnumerator GetMessageOfTheDay()
    {
        UnityWebRequest request = new UnityWebRequest(MESSAGE_OF_THE_DAY_URI)
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return request.SendWebRequest();

        if(request.result != UnityWebRequest.Result.Success)
        {
            QuoteOfTheDay = "Erreur lors de l'appel avec status : " + request.result;
        }
        else
        {
            QuoteOfTheDay = request.downloadHandler.text;
        }
        quoteRepo.text += QuoteOfTheDay;
    }

    public IEnumerator GetHallOfFame(TextMeshProUGUI text)
    {
        UnityWebRequest request = new UnityWebRequest(GET_HALL_OF_FAME_URI)
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            text.text = "Erreur lors de l'appel avec status : " + request.result;
        }
        else
        {
            text.text += request.downloadHandler.text;
        }
    }

    public IEnumerator SendPlayerScore(string player, int score)
    {
        ScoreEntity scoreEntity = new ScoreEntity("CoffeeRush", player, score);

        UnityWebRequest request = new UnityWebRequest(SEND_SCORE, "POST");

        byte[] bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(scoreEntity));

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();
    }

    public IEnumerator GetCoffeeVotes()
    {
        UnityWebRequest request = new UnityWebRequest(GET_COFFEE_VOTES)
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            textZone.text = "Erreur lors de l'appel avec status : " + request.result;
        }
        else
        {
            textZone.text += request.downloadHandler.text;
        }
    }
}
