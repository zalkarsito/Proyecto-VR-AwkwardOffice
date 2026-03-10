using UnityEngine;

public class VideoToOverlay : MonoBehaviour
{
    public OVROverlay overlay;
    public UnityEngine.Video.VideoPlayer videoPlayer;

    void Update()
    {
        if (videoPlayer.texture != null)
        {
            overlay.textures[0] = videoPlayer.texture;
        }
    }
}