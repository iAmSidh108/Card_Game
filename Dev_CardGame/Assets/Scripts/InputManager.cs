using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    GameObject clickedObject;
    

    public void OnDrag(PointerEventData eventData)
    {
        
        CardManager.instance.MoveCard(eventData.position);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clickedObject = eventData.pointerCurrentRaycast.gameObject;

        if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>() != null)
        {
            CardManager.instance.SetSelectedCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>());
            CardManager.instance.AddClickedCardsToList(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>());
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
