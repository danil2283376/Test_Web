using System.Collections;
//using System.IO;
//using UnityEditor;
using UnityEngine;
//using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

public class LoadSprites : MonoBehaviour
{
    public SpriteRenderer[] SpriteRenderer;
    private readonly string _defaultPathToSprite = "Assets/Sprites/Image ";

    //[MenuItem("Tools/Build AssetBundles")]
    //public static void BuildAllAssetBundles()
    //{
    //    // Определяем путь для AssetBundles
    //    string assetBundlePath = "Assets/AssetBundles";

    //    // Создаем папку, если она не существует
    //    if (!Directory.Exists(assetBundlePath))
    //    {
    //        Directory.CreateDirectory(assetBundlePath);
    //    }

    //    // Указываем настройки AssetBundle
    //    BuildAssetBundleOptions options = BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.StrictMode;
    //    BuildPipeline.BuildAssetBundles(assetBundlePath, options, BuildTarget.WebGL);
    //}

    public void Load() 
    {
        for (int i = 0; i < SpriteRenderer.Length; i++)
        {
            StartCoroutine(LoadSprite(SpriteRenderer[i], (i + 1)));
        }
    }

    private IEnumerator LoadSprite(SpriteRenderer spriteRenderer, int number)
    {
        // Загрузка AssetBundle с помощью UnityWebRequest
        string assetBundleUrl = "https://danil2283376.github.io/WebGLTestAddressables/StreamingAssets/aa/WebGL/defaultlocalgroup_assets_all_b5f5c7eb408c34740339a8295e89b2bf.bundle";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(assetBundleUrl);

        yield return request.SendWebRequest();

        // Загрузка Sprite из AssetBundle
        AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(request);
        Sprite sprite = assetBundle.LoadAsset<Sprite>(_defaultPathToSprite + number + ".jpg"); // Загружаем нужный спрайт

        // Установка Sprite на SpriteRenderer
        spriteRenderer.sprite = sprite;

        // Освобождение ресурсов AssetBundle
        assetBundle.Unload(false);

        //var task = Addressables.LoadAssetAsync<Sprite>(_defaultPathToSprite + number + ".jpg");

        //yield return task;
        //spriteRenderer.sprite = task.Result;
    }
}
