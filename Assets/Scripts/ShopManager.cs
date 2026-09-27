using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public List<ShopOption> allItems;
    public List<ShopOption> currentItems;
    public int offers = 3;
    public GameObject shopUI; // panel you toggle on/off
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
        poolUI.SetActive(false);
        
    }

    private List<ShopOption> GetRandomBalls(int count)
    {
        // simple no-duplicates random pick, unweighted
        List<ShopOption> pool = new List<ShopOption>(allItems);
        List<ShopOption> result = new List<ShopOption>();

        count = Mathf.Min(count, pool.Count);

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, pool.Count);
            result.Add(pool[index]);
            pool.RemoveAt(index);
        }

        return result;
    }

    public bool BuyBall(int index)
    {
        ShopOption option = currentItems[index];

        if (ScoreManager.instance.currency < option.cost)
        {
            Debug.Log("Not enough currency for " + option.displayName);
            return false;
        }

        ScoreManager.instance.currency -= option.cost;

        GameObject newBall = Instantiate(option.ballPrefab);
        newBall.tag = "Ball";
        BallRandomizer.instance.balls.Add(newBall);

        return true;
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
        poolUI.SetActive(true);
        GameManager.instance.StartNewRound();
    }


}
