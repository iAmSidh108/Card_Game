using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    GameObject clickedObject;
    [SerializeField] private Image groupbutton;
    [SerializeField] private Image restartButton;

    public void OnDrag(PointerEventData eventData)
    {
        CardManager.instance.MoveCard(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clickedObject = eventData.pointerCurrentRaycast.gameObject;

        if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>() != null)
        {
            CardManager.instance.AddClickedCardsToList(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>());
            CardManager.instance.SetSelectedCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>());
        }

        clickedObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        groupbutton.raycastTarget = false;
        restartButton.raycastTarget = false;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (clickedObject.GetComponent<CardView>() || eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>())
        {
            if (eventData.pointerCurrentRaycast.gameObject != null && !CheckIfSameContainer(eventData))
            {
                CardManager.instance.ReleaseCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>().currentGroupContainer, true);
            }
            else
            {
                CardManager.instance.ReleaseCard(clickedObject.GetComponent<CardView>().currentGroupContainer, false);
            }

            clickedObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
            groupbutton.raycastTarget = true;
            restartButton.raycastTarget = true;
        }
        
    }

    bool CheckIfSameContainer(PointerEventData eventData)
    {
        if (eventData != null)
        {
            
            return clickedObject.GetComponent<CardView>().currentGroupContainer == eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>().currentGroupContainer;
        }
        else
        {
            return false;
        }
        

    }
}
