using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController4 : MonoBehaviour
{
    public VideoPlayer videoPlayer4;

    void Start()
    {
        // Subscribe to the videoPlayer's loopPointReached event
        videoPlayer4.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // This method is called when the video ends
        SceneManager.LoadScene("StagesUI_Scene");
    }
}
