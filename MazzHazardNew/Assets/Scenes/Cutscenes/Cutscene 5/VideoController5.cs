using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController5 : MonoBehaviour
{
    public VideoPlayer videoPlayer5;

    void Start()
    {
        // Subscribe to the videoPlayer's loopPointReached event
        videoPlayer5.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // This method is called when the video ends
        SceneManager.LoadScene("EasyLevel05");
    }
}

