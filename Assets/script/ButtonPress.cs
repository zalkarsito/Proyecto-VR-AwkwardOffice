using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public void OnButtonDown()
    {
    SceneLoader.instance.LoadScene("VR_AwkWard");
    }
}
