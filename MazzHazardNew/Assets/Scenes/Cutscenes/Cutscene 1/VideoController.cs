using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Subscribe to the videoPlayer's loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;

        //if (PlayerPrefs.HasKey("CutscenePlayed") && PlayerPrefs.GetInt("CutscenePlayed") == 1)
        //{
        //    OnVideoEnd(videoPlayer);
        //}

        //else
        //{
        //    PlayCutscene();
        //}

    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // This method is called when the video ends
        SceneManager.LoadScene("EasyLevel01");
    }

    //void PlayCutscene()
    //{
    //    // Play the cutscene here
    //    SceneManager.LoadScene("EasyLevel01");
    //    // Set the flag to indicate that the cutscene has been played
    //    PlayerPrefs.SetInt("CutscenePlayed", 1);
    //    PlayerPrefs.Save();
    //}
}