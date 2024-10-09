using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler 
{
    public LoadSprites LoadSpritesParent;
    public Animator Animator;

    public void OnPointerClick(PointerEventData eventData) 
    {
        Debug.Log("Click");
        Animator.SetBool("anim", true);
        LoadSpritesParent.Load();
    }

    public void OnPointerDown(PointerEventData eventData) 
    {

    }

    public void OnPointerEnter(PointerEventData eventData) 
    {

    }

    public void OnPointerExit(PointerEventData eventData) 
    {

    }

    public void OnPointerUp(PointerEventData eventData) 
    {

    }
}
