using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private const string LastSceneKey = "LastScene";

    // Mevcut sahneyi kaydetmek için kullanılan fonksiyon
    public void SaveCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString(LastSceneKey, currentScene);
        PlayerPrefs.Save();
    }

    // En son kaydedilen sahneyi yüklemek için kullanılan fonksiyon
    public void LoadLastScene()
    {
        if (PlayerPrefs.HasKey(LastSceneKey))
        {
            string lastScene = PlayerPrefs.GetString(LastSceneKey);
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            Debug.LogWarning("Kaydedilen sahne bulunamadı. Varsayılan sahne yükleniyor.");
            SceneManager.LoadScene(0); // Varsayılan sahneyi yükleyebilirsiniz.
        }
    }
}

