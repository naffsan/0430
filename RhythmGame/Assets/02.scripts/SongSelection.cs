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
        //���� Ŭ�� �ε�
        clip=Resources.Load<VideoClip>($"VideoClips/{clipName}");
        //�뷡 ���̽����� ������ �ε�
        TextAsset songDataText = Resources.Load<TextAsset>($"SongDatas/{clipName}");
        //json������ ��ø��������
        songData=JsonUtility.FromJson<SongData>(songDataText.ToString());
    }
}
