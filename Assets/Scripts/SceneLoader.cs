using System.Collections;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public OVROverlay overlay_Background;
    public OVROverlay overlay_LoadingText;
    // Creamos un Singlenton para poder acceder al método LoadScene desde otro script:
    public static SceneLoader instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(ShowOverlayAndLoad(sceneName));
    }
    IEnumerator ShowOverlayAndLoad(string sceneName)
    {
        // activamos los componentes
        overlay_Background.enabled = true;
        overlay_LoadingText.enabled = true;
        GameObject centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
        overlay_LoadingText.gameObject.transform.position = centerEyeAnchor.transform.position + new Vector3(0,
        0, 3f);
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        overlay_Background.enabled = false;
        overlay_LoadingText.enabled = false;
        Debug.Log("Escena cargada");
        yield return null;
    }
}
