using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class JsonHandler : MonoBehaviour
{
    public static JsonHandler instance;
    [SerializeField] private TextAsset jsonData;
    public Sprite[] cardSprites; // Array of card sprites
    List<string> cardNames = new List<string>();

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
        cardNames = ParseJson(jsonData.text);
    }

    private List<string> ParseJson(string jsonString)
    {
        List<string> cards = new List<string>();

        try
        {
            Root jsonData = JsonConvert.DeserializeObject<Root>(jsonString);
            cards = jsonData.data.deck;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error parsing JSON data: " + e.Message);
        }

        return cards;
    }

    public void SpawnCards(GameObject cardPrefab,Transform groupToInstantiate)
    {
        // Spawn cards and set their sprites
        foreach (string cardName in cardNames)
        {
            GameObject card = Instantiate(cardPrefab, groupToInstantiate);
            card.transform.SetParent(groupToInstantiate);
            Sprite sprite = GetSpriteByName(cardName);
            if (sprite != null)
            {
                card.GetComponent<CardView>().SetCardImg(sprite);
            }
            card.GetComponent<CardView>().currentGroupContainer = groupToInstantiate;
        }
    }

    private Sprite GetSpriteByName(string cardName)
    {
        // Find sprite based on card name
        foreach (Sprite sprite in cardSprites)
        {
            if (sprite.name == cardName)
            {
                return sprite;
            }
        }
        return null; // Return null if sprite not found
    }
}

