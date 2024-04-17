using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerClickHandler
{
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
        //if (eventData.pointerCurrentRaycast.gameObject != null)
        //{
        //    //Debug.Log("OnPointerDown " + eventData.pointerCurrentRaycast.gameObject.name);
        //    if (eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>() != null)
        //    {
        //        CardManager.instance.SetSelectedCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>());
        //    }
        //}
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //CardManager.instance.ReleaseCard();
    }
}
