using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    [SerializeField] private List<Sprite> cardSprites;
    [SerializeField] private Transform firstCardHolderContainer;
    [SerializeField] private Transform secondCardHolderContainer;

    [SerializeField] private Transform parentHolderContainer;
    [SerializeField] private GameObject cardPrefab;

    private CardView selectedCard;
    private List<CardView> selectedCardsList=new List<CardView>();

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
        groupButton.onClick.AddListener(() => {

            GroupCards(secondCardHolderContainer);
            groupButton.gameObject.SetActive(false);
            SetCheckMarkOff();
            selectedCardsList.Clear();
        });

        
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
        card.transform.SetParent(firstCardHolderContainer);
        card.GetComponent<CardView>().SetCardImg(cardSprites[cardIndex]);
        card.GetComponent<CardView>().currentGroupContainer = firstCardHolderContainer;
    }

    public void SetSelectedCard(CardView card)
    {
        int selectedCardIndex=card.transform.GetSiblingIndex();

        selectedCard = card;
        selectedCard.childIndex = selectedCardIndex;
        selectedCard.transform.SetParent(parentHolderContainer);

        //SetCheckMark();
    }

    public void ReleaseCard(Transform containerToRelease, bool shouldRemoveItem)
    {
        if (selectedCard != null)
        {
            selectedCard.transform.SetParent(containerToRelease);
            selectedCard.transform.SetSiblingIndex(selectedCard.childIndex);

            if (shouldRemoveItem)
            {
                selectedCard.selectedCheckMark.gameObject.SetActive(false);
                selectedCardsList.Remove(selectedCard);
            }

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
        if (selectedCardsList.Contains(clickedCards))
            return;

        selectedCardsList.Add(clickedCards);
        SetCheckMarkOn();
    }

    public void GroupCards(Transform container)
    {
        foreach(CardView card in selectedCardsList)
        {
            card.transform.SetParent(container);
            card.GetComponent<CardView>().currentGroupContainer = container;
            
        }
    }

    private void Update()
    {
        if (selectedCardsList.Count > 1)
        {
            groupButton.gameObject.SetActive(true);
        }
        
    }

    public void SetCheckMarkOn()
    {
        foreach (CardView card in selectedCardsList)
        {
            card.selectedCheckMark.gameObject.SetActive(true);
        }
    }

    public void SetCheckMarkOff()
    {
        foreach (CardView card in selectedCardsList)
        {
            card.selectedCheckMark.gameObject.SetActive(false);
        }
    }




}
