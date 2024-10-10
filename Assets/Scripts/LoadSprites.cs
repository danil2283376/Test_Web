using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadSprites : MonoBehaviour
{
    public SpriteRenderer[] SpriteRenderer;
    //"Assets/Sprites/Image ";
    //private readonly string _defaultPathToSprite = "Sprites/Image ";
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
        //Debug.Log("For Test: " + _defaultPathToSprite + number/* + ".jpg"*/);
        var task = Addressables.LoadAssetAsync<Sprite>(_defaultPathToSprite + number + ".jpg");

        //// Ожидаем завершения загрузки
        //task.Completed += (operation) =>
        //{
        //    if (operation.Status == AsyncOperationStatus.Succeeded)
        //    {
        //        spriteRenderer.sprite = operation.Result; // Установка Sprite на SpriteRenderer
        //    }
        //    else
        //    {
        //        Debug.LogError("Ошибка загрузки: " + operation.Result.ToString()); //  operation.Result -  строковое описание ошибки
        //    }
        //};

        yield return task;
        spriteRenderer.sprite = task.Result;
    }
}
