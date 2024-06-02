using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inputmanager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler,IPointerMoveHandler
{

     [SerializeField]
     private MaterialChanger materialChanger;
     [SerializeField]
     private PickupScript pickup;
     [SerializeField]
     private Transform referenceIk;

     [SerializeField]
     private GameObject UiObject;
     private bool selected = false;
         
     public void OnPointerClick(PointerEventData eventData)
     {
          Debug.Log("clicked");
          selected = !selected;
          if (selected)
          {
               materialChanger.Highlight();

               UiObject.SetActive(true);
          }
          else{
               materialChanger.RemoveHighlight();

               UiObject.SetActive(false);
          }
          if(eventData.clickCount==2){
               selected = !selected;
          }
          
          pickup.GetlabEquipment(gameObject.transform,referenceIk);
          
     }

     public void OnPointerEnter(PointerEventData eventData)
     {
          Debug.Log("overyou");

     }

     public void OnPointerMove(PointerEventData eventData)
     {
          Debug.Log("moving");
          // trigger shake animation

     }

     void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
     {
          Debug.Log("Exit");
          if (!selected)
          {
               
               materialChanger.RemoveHighlight();
          }
          
     }
}
