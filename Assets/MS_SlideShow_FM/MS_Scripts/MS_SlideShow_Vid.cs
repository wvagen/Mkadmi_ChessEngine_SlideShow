using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MS_SlideShow_Vid : MonoBehaviour
{
    public Text videoMomentTxt;
    public VideoPlayer videoPlayer;

    void Update()
    {
        videoMomentTxt.text = ((int)videoPlayer.time).ToString() + " / " + ((int)videoPlayer.length).ToString();
    }
}
