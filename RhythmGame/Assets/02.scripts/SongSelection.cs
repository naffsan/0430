using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SongSelection : MonoBehaviour
{
    public static SongSelection instance;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public VideoClip clip;
    public SongData songData;

    public void LoadSongData(string clipName)
    {
        //비디오 클립 로드
        clip=Resources.Load<VideoClip>($"VideoClips/{clipName}");
        //노래 제이슨파일 데이터 로드
        TextAsset songDataText = Resources.Load<TextAsset>($"SongDatas/{clipName}");
        //json데이터 디시리얼라이즈
        songData=JsonUtility.FromJson<SongData>(songDataText.ToString());
    }
}
