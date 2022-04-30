
using System.Collections.Generic;

[System.Serializable]
public class SongData
{
    public string videoname;
    public List<NoteData> notes;
    public SongData()
    {
        notes = new List<NoteData>();
    }
}