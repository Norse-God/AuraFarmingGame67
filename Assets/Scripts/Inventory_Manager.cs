using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Inventory_Manager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerCurrentRaycast.gameObject);
    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
