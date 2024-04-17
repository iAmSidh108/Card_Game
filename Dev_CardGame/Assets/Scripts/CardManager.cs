using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    [SerializeField] private List<Sprite> cardSprites;
    [SerializeField] private Transform cardHolderContainer;
    [SerializeField] private GameObject cardPrefab;

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        for (int i = 0;i<24;i++)
        {
            SpawnCard(i);
        }
    }

    void SpawnCard(int cardIndex)
    {
        GameObject card=Instantiate(cardPrefab);
        card.name = "Card" + cardIndex;
        card.transform.SetParent(cardHolderContainer);
        card.GetComponent<CardView>().SetCardImg(cardSprites[cardIndex]);
    }
}
