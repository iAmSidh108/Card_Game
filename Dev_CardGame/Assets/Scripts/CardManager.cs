using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    //Singleton Pattern
    public static CardManager instance;

    [Header("Card Related")]
    [SerializeField] private GameObject cardPrefab;

    [Header("Group Related")]
    [SerializeField] private Transform firstCardGroupContainer;
    [SerializeField] private Transform[] groupList;
    [SerializeField] private Transform parentHolderContainer;
    

    [Header("Selected Cards")]
    private CardView _selectedCard;
    private List<CardView> _selectedCardsList=new List<CardView>();

    [Header("UI")]
    [SerializeField] private Button groupButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button restartButton;
    [SerializeField] GameObject noGroupPopUp;
    
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

        playButton.onClick.AddListener(() => {

            playButton.gameObject.SetActive(false);
            JsonHandler.instance.SpawnCards(cardPrefab, firstCardGroupContainer);
        });

        restartButton.onClick.AddListener(() => {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        groupButton.onClick.AddListener(() => {

            if (GetCurrentFreeGroup() == null)
            {
                StartCoroutine(NoGroupAvailablePopupandHide());
                SetCheckMarkOff();
                _selectedCardsList.Clear();
                return;
            }

            GroupCards(GetCurrentFreeGroup());
            groupButton.gameObject.SetActive(false);
            SetCheckMarkOff();
            _selectedCardsList.Clear();
        });
    }

    private void OnEnable()
    {
        

        
    }
    

    private void Start()
    {
        groupButton.gameObject.SetActive(false);
    }

    public void SetSelectedCard(CardView card)
    {
        int selectedCardIndex=card.transform.GetSiblingIndex();

        _selectedCard = card;
        _selectedCard.childIndex = selectedCardIndex;
        _selectedCard.transform.SetParent(parentHolderContainer);

    }

    public void ReleaseCard(Transform containerToRelease, bool shouldRemoveItem)
    {
        if (_selectedCard != null)
        {
            _selectedCard.transform.SetParent(containerToRelease);
            _selectedCard.transform.SetSiblingIndex(_selectedCard.childIndex);

            if (shouldRemoveItem)
            {
                _selectedCard.selectedCheckMark.gameObject.SetActive(false);
                _selectedCardsList.Remove(_selectedCard);
            }
            _selectedCard.currentGroupContainer = containerToRelease;

            _selectedCard = null;
        }
    }

    public void MoveCard(Vector2 position)
    {
        if (_selectedCard != null)
        {
            _selectedCard.transform.position = position;
        }
    }

    public void AddClickedCardsToList(CardView clickedCards)
    {
        if (_selectedCardsList.Contains(clickedCards))
            return;

        _selectedCardsList.Add(clickedCards);
        SetCheckMarkOn();
    }

    public void GroupCards(Transform container)
    {
        foreach(CardView card in _selectedCardsList)
        {
            card.transform.SetParent(container);
            card.GetComponent<CardView>().currentGroupContainer = container;
        }
    }

    private void Update()
    {
        if (_selectedCardsList.Count > 1)
        {
            groupButton.gameObject.SetActive(true);
        }
        else
        {
            groupButton.gameObject.SetActive(false);
        }
        
    }

    public void SetCheckMarkOn()
    {
        foreach (CardView card in _selectedCardsList)
        {
            card.selectedCheckMark.gameObject.SetActive(true);
        }
    }

    public void SetCheckMarkOff()
    {
        foreach (CardView card in _selectedCardsList)
        {
            card.selectedCheckMark.gameObject.SetActive(false);
        }
    }

    private Transform GetCurrentFreeGroup()
    {
        Transform freeGroup= null;
        for (int i = 0; i < groupList.Length; i++)
        {
            if (!groupList[i].GetComponent<Container>().isBeingUsed)
            {
                freeGroup = groupList[i];

            }
        }

        return freeGroup;
    }

    IEnumerator NoGroupAvailablePopupandHide()
    {
        noGroupPopUp.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        noGroupPopUp.SetActive(false);
    }
}
