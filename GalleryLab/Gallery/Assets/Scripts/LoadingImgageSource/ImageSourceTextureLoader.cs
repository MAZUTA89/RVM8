using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageSourceTextureLoader : MonoBehaviour
{
    const string uri = "https://cdn.mos.cms.futurecdn.net/viC8tbRf75Sno7AuHKcZ9R-1200-80.jpg";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadImageCoroutine(uri));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadImageCoroutine(string imageUrl)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                // Получаем текстуру изображения
                Texture2D texture = DownloadHandlerTexture.GetContent(www);

                // Используйте текстуру по вашему усмотрению
                // Например, установите ее на материал объекта
                var renderer = GetComponent<Renderer>();
                renderer.material.mainTexture = texture;
                renderer.material.mainTextureScale = new Vector2(1.8f, 1.96f);
            }
            else
            {
                Debug.LogError($"Ошибка загрузки изображения: {www.error}");
            }
        }
    }
}
