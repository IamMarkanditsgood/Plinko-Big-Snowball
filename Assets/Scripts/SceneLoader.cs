using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TMP_Text _procent;
    [SerializeField] private int sceneIndexToLoad;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync(sceneIndexToLoad));
    }

    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = true;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            // Обновление текста с процентом
            if (_procent != null)
            {
                _procent.text = $"{(int)(progress * 100)}%";
            }

            // Масштабирование от 1 до 5 по X
            if (image != null)
            {
                float scale = Mathf.Lerp(1f, 3f, progress);
                image.transform.localScale = new Vector3(scale, scale, 1f);
            }

            yield return null;
        }
    }
}
