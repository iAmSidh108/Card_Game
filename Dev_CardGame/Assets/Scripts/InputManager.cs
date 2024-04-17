using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerClickHandler
{
    GameObject clickedObject;

    public void OnDrag(PointerEventData eventData)
    {
        CardManager.instance.MoveCard(eventData.position);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
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


    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if(eventData.pointerCurrentRaycast.gameObject != null && !CheckIfSameContainer(eventData))
        {
            CardManager.instance.ReleaseCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>().currentGroupContainer, true);
        }
        else
        {
            CardManager.instance.ReleaseCard(clickedObject.GetComponent<CardView>().currentGroupContainer, false);
        }

        clickedObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    bool CheckIfSameContainer(PointerEventData eventData)
    {
        return clickedObject.GetComponent<CardView>().currentGroupContainer == eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>().currentGroupContainer;
    }
}
