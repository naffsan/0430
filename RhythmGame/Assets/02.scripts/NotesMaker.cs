using UnityEngine;
using UnityEditor;
using UnityEngine.Video;
using System;
/// <summary>
/// 뮤직비디오 재생하고 사용자가 해당 뮤비에 대한 노트 데이터를 입력해 저장할 수 있도록 하는 클래스
/// </summary>
public class NotesMaker : MonoBehaviour
{
    private SongData songData;//노래 데이터
    KeyCode[] keyCodes = { KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.Space, KeyCode.J, KeyCode.K, KeyCode.L };//키보드 입력 목록

    private bool onRecord
    {
        get
        {
            return vp.isPlaying ? true : false;
        }
    }//녹화중인가?
    [SerializeField] VideoPlayer vp;
    private void Update()
    {
        if (onRecord)
            Recording();
    }
    /// <summary>
    /// 노래데이터 생성, 뮤비시작
    /// </summary>
    public void StartRecording()
    {
        songData=new SongData();//노래 데이터 객체 생성
        //뮤비 시작
        songData.videoName = vp.clip.name;//노래 데이터에 현재 클립 이름 대입
        vp.Play();//비디오 재생
    }
    /// <summary>
    /// 녹화 중 호출, 키 입력에 따라 노트 데이터 생성
    /// </summary>
    private void Recording()
    {
      
        foreach (KeyCode keyCode in keyCodes)
        {
            if (Input.GetKeyDown(keyCode))
                CreateNoteData(keyCode);
        }
    }
    /// <summary>
    /// 재생중이던 뮤비 정지, 지금까지 생성한 데이터 저장
    /// </summary>
    public void StopRecording()
    {
        //뮤직비디오 정지하기
        SaveSongData();
        vp.Stop();//비디오 정지
    }

    /// <summary>
    /// 키코드, 시간에 따른 노트 데이터 생성해 노래데이터에 추가하는 함수
    /// </summary>
    /// <param name = "keyCode">현재 키보드 입력</param>
    private void CreateNoteData(KeyCode keyCode)
    {
        float roundedTime = (float)Math.Round(vp.time, 2);//소숫점 둘째자리까지 반올림
        NoteData noteData = new NoteData ();//노트데이터 생성
        noteData.time = roundedTime;
        noteData.keyCode = keyCode;
        Debug.Log($"노트데이터 생성: {keyCode} {roundedTime}");
        songData.notes.Add(noteData);//노래데이터에 생성한 노트데이터 추가

        //뮤비 현재 시간에 맞춰서 멤버 세팅하기
        //noteData.time=뮤직비디오 현재시간 반올림된거

    }
    /// <summary>
    /// 저장 패널 띄운 후에 사용자가 저장할 디렉토리 입력하면 해당 디렉토리에 
    /// 역직렬화된 노래 데이터(디시리얼라이즈, 압축해제)를 쓰는 함수
    /// </summary>
   private void SaveSongData()
    {//저장 패널 띄우고 사용자의 저장할 디렉토리 받아옴
        string dir = EditorUtility.SaveFilePanel("저장할 곳을 입력하세요", "", songData.videoName,"json");//파일저장하는 패널이 뜸, 하지만 아직 저장은 아님
        //jsonUtility.ToJson을 통해 노래데이터를 디시리얼라이즈하고 그로 인해 만들어진 텍스트를 파일로 씀
        //이 함수가 디렉토리를 반환할 뿐이니 실제 파일을 따로 써줘야 함
        System.IO.File.WriteAllText(dir, JsonUtility.ToJson(songData));
    }
}
