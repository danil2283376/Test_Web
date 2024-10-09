using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadSprites : MonoBehaviour 
{
    public GameObject[] spriteRenderer;
    public string[] strings;

    public void Load() 
    {
        for (int i = 0; i < spriteRenderer.Length; i++) 
        {
            StartCoroutine(LoadSprite(spriteRenderer[i].GetComponent<SpriteRenderer>(), i));
        }
    }

    private IEnumerator LoadSprite(SpriteRenderer spriteRenderer, int number) 
    {
        var task = Addressables.LoadAssetAsync<Sprite>(strings[number]);
        yield return task;
        spriteRenderer.sprite = task.Result;
    }
}
