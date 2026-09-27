using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public List<Sprite> allItems;
    public List<Image> itemPlaceholders;
    private List<Sprite> results;
    public List<Sprite> currentItems;
    public int offers = 3;
    public GameObject shopUI; // panel you toggle on/off
    //public TextMeshProUGUI currencyText;
    public Image person;
    public Sprite[] people;
    public GameObject poolUI;
    public System.Action onOffersRefreshed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        shopUI.SetActive(true);
        int index = Random.Range(0, people.Length - 1);
        person.sprite = people[index];
        poolUI.SetActive(false);

        results = GetRandomBalls(offers);

        index = -1;
        foreach (Image image in itemPlaceholders)
        {
            index++;
            image.sprite = results[index];
        }
    }

    private List<Sprite> GetRandomBalls(int count)
    {
        List<Sprite> results = new List<Sprite>();
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, allItems.Count - 1);
            results.Add(allItems[index]);
        }

        return results;
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
        poolUI.SetActive(true);
        GameManager.instance.StartNewRound();
    }


}
