using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController3 : MonoBehaviour
{
    public VideoPlayer videoPlayer3;

    void Start()
    {
        // Subscribe to the videoPlayer's loopPointReached event
        videoPlayer3.loopPointReached += OnVideoEnd;


    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // This method is called when the video ends
        SceneManager.LoadScene("EasyLevel10");
    }

}
