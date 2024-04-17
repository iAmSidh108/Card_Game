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
        CardManager.instance.AddClickedCardsToList(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clickedObject = eventData.pointerCurrentRaycast.gameObject;

        
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            
            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>() != null)
            {
                CardManager.instance.SetSelectedCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>());
            }
        }

        clickedObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if(eventData.pointerCurrentRaycast.gameObject != null)
        {
            CardManager.instance.ReleaseCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>().currentGroupContainer);
        }
        else
        {
            CardManager.instance.ReleaseCard(clickedObject.GetComponent<CardView>().currentGroupContainer);
        }

        clickedObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
