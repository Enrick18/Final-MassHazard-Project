using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController2 : MonoBehaviour
{
    public VideoPlayer videoPlayer2;

    void Start()
    {
        // Subscribe to the videoPlayer's loopPointReached event
        videoPlayer2.loopPointReached += OnVideoEnd;

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
        SceneManager.LoadScene("StagesUI_Scene");
    }

    //void PlayCutscene()
    //{
    //    // Play the cutscene here
    //    SceneManager.LoadScene("EasyLevel02");
    //    // Set the flag to indicate that the cutscene has been played
    //    PlayerPrefs.SetInt("CutscenePlayed", 1);
    //    PlayerPrefs.Save();
    //}
}
