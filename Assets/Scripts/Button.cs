using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerClickHandler
{
    public LoadSprites LoadSpritesParent;
    public Animator Animator;

    private bool _spritesIsLoaded = false;
    public void OnPointerClick(PointerEventData eventData) 
    {
        Debug.Log("Click");
        Animator.SetBool("anim", true);
        if (_spritesIsLoaded == false)
            LoadSpritesParent.Load();
        _spritesIsLoaded = true;
    }
}
