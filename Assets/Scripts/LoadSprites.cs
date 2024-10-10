using System.Collections;
//using System.IO;
//using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

public class LoadSprites : MonoBehaviour
{
    public SpriteRenderer[] SpriteRenderer;
    private readonly string _defaultPathToSprite = "Assets/Sprites/Image ";

    public void Load() 
    {
        for (int i = 0; i < SpriteRenderer.Length; i++)
        {
            StartCoroutine(LoadSprite(SpriteRenderer[i], (i + 1)));
        }
    }

    private IEnumerator LoadSprite(SpriteRenderer spriteRenderer, int number)
    {
        var task = Addressables.LoadAssetAsync<Sprite>(_defaultPathToSprite + number + ".jpg");

        yield return task;
        spriteRenderer.sprite = task.Result;
    }
}
