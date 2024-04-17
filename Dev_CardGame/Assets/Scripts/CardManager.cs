using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    [SerializeField] private List<Sprite> cardSprites;
    [SerializeField] private Transform cardHolderContainer;
    [SerializeField] private Transform secondCardHolderContainer;

    [SerializeField] private Transform parentHolderContainer;
    [SerializeField] private GameObject cardPrefab;

    private CardView selectedCard;
    private List<CardView> selectedCards=new List<CardView>();

    public Button groupButton;

    public CardView SelectedCard { get => selectedCard;}
    

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

    private void OnEnable()
    {
        groupButton.onClick.AddListener(GroupCards);
    }

    private void Start()
    {
        for (int i = 0;i<24;i++)
        {
            SpawnCard(i);
        }

        groupButton.gameObject.SetActive(false);
    }

    void SpawnCard(int cardIndex)
    {
        GameObject card=Instantiate(cardPrefab);
        card.name = "Card" + cardIndex;
        card.transform.SetParent(cardHolderContainer);
        card.GetComponent<CardView>().SetCardImg(cardSprites[cardIndex]);
    }

    public void SetSelectedCard(CardView card)
    {
        int selectedCardIndex=card.transform.GetSiblingIndex();

        selectedCard = card;
        selectedCard.childIndex = selectedCardIndex;
        selectedCard.transform.SetParent(parentHolderContainer);
    }

    public void ReleaseCard()
    {
        if (selectedCard != null)
        {
            selectedCard.transform.SetParent(cardHolderContainer);
            selectedCard.transform.SetSiblingIndex(selectedCard.childIndex);
            selectedCard = null;
        }
    }

    public void MoveCard(Vector2 position)
    {
        if (selectedCard != null)
        {
            selectedCard.transform.position = position;
        }
    }

    public void AddClickedCardsToList(CardView clickedCards)
    {
        if (selectedCards.Contains(clickedCards))
            return;

        if(selectedCards.Count >= 2) 
        {
            selectedCards.Clear();
        }

        
        
        selectedCards.Add(clickedCards);
    }

    public void GroupCards()
    {
        foreach(CardView card in selectedCards)
        {
            card.transform.SetParent(secondCardHolderContainer);
        }
    }

    private void Update()
    {
        if (selectedCards.Count == 2)
        {
            groupButton.gameObject.SetActive(true);
        }
    }
}
