using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundCompleteUI : MonoBehaviour
{
    public static RoundCompleteUI instance;
    public GameObject panel; // the results panel itself
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI currencyText;
    public Button continueButton;
    public Button shopButton;
    public GameObject ui;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        continueButton.onClick.AddListener(() => GameManager.instance.ChooseContinue());
        shopButton.onClick.AddListener(() => GameManager.instance.EnterShop());

        panel.SetActive(false);
    }
    public void Show()
    {
        panel.SetActive(true);
        messageText.text = "You beat the target score!";
        scoreText.text = "Score: " + ScoreManager.instance.totalScore;
        //currencyText.text = "Currency: " + ScoreManager.instance.currency;
        
    }

    public void Hide()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
