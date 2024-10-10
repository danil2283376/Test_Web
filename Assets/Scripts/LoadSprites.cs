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
    //    // ���������� ���� ��� AssetBundles
    //    string assetBundlePath = "Assets/AssetBundles";

    //    // ������� �����, ���� ��� �� ����������
    //    if (!Directory.Exists(assetBundlePath))
    //    {
    //        Directory.CreateDirectory(assetBundlePath);
    //    }

    //    // ��������� ��������� AssetBundle
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
        // �������� AssetBundle � ������� UnityWebRequest
        string assetBundleUrl = "https://danil2283376.github.io/WebGLTestAddressables/StreamingAssets/aa/WebGL/defaultlocalgroup_assets_all_b5f5c7eb408c34740339a8295e89b2bf.bundle";
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(assetBundleUrl);

        yield return request.SendWebRequest();

        // �������� Sprite �� AssetBundle
        AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(request);
        Sprite sprite = assetBundle.LoadAsset<Sprite>(_defaultPathToSprite + number + ".jpg"); // ��������� ������ ������

        // ��������� Sprite �� SpriteRenderer
        spriteRenderer.sprite = sprite;

        // ������������ �������� AssetBundle
        assetBundle.Unload(false);

        //var task = Addressables.LoadAssetAsync<Sprite>(_defaultPathToSprite + number + ".jpg");

        //yield return task;
        //spriteRenderer.sprite = task.Result;
    }
}
