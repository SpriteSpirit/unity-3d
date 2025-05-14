using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        // Проверяем, существует ли уже экземпляр MusicManager
        if (instance == null)
        {
            instance = this;
            // Не уничтожать объект при загрузке новой сцены
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Если экземпляр уже существует, уничтожаем дубликат
            Destroy(gameObject);
        }
    }
}
