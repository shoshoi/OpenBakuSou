using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public class NotesManager : SingletonMonoBehaviour<NotesManager>
    {
        public GameObject notePrefab;
        public BakusouMusicData musicData;

        // 譜面情報を保持する変数
        private double[] timingArray;
        private int[] keyArray;
        private int noteIndex = 0;

        double fallTime;

        //　ノートプール
        private List<Note> notePool;
        private List<Note> activeNoteList;
        private int poolSize = Constants.NOTE_POOL_SIZE;
        private int poolIndex = 0;

        // 得点管理
        private ScoreBoard scoreBoard;

        void Start()
        {
            scoreBoard = ScoreBoard.Instance;
            InitNotes();
        }
        void InitNotes()
        {
            musicData = GameParameter.Instance().GetSelectMusicData();

            // ノート情報
            timingArray = musicData.TimingArray;
            keyArray = musicData.KeyArray;
            noteIndex = 0;
            poolIndex = 0;

            float fallDist = Constants.DEFAULT_FALL_DIST;
            double settingSpeed = SaveManager.Instance().GetSaveData().setting.speed;
            float fallSpeed = 0;
            if (musicData.Id == 30 || musicData.Id == 31)
            {
                fallSpeed = (3 / Constants.DEFAULT_FALL_SPEED / (float)settingSpeed) * (120.0f / musicData.Bpm * 2);
            }
            else
            {
                fallSpeed = (3 / Constants.DEFAULT_FALL_SPEED / (float)settingSpeed) * (120.0f / musicData.Bpm);
            }
            
            fallTime = fallSpeed / fallDist * 100;
            Debug.Log("fallDist : " + fallDist);
            Debug.Log("fallSpeed : " + fallSpeed);
            Debug.Log("falltime : " + fallTime);
            float fallDistOffset = 0.0f;
            //ノートプールの準備
            notePool = new List<Note>();
            activeNoteList = new List<Note>();

            for (var i = 0; i < poolSize; i++)
            {
                GameObject noteObject = Instantiate(notePrefab, new Vector3(0, -100, -100), new Quaternion(0.0f, 180.0f, 0.0f, 1.0f));
                Note note = noteObject.GetComponent<Note>();
                note.InitNote();
                note.fallDist = fallDist;
                note.fallDistOffset = fallDistOffset;
                note.fallSpeed = fallSpeed;
                note.fallTime = fallTime;
                notePool.Add(note);
            }
        }

        void Update()
        {
            // 非アクティブなノートは、activeNoteListから排除する。
            for (int i = 0; i < activeNoteList.Count; i++)
            {
                if (!activeNoteList[i].GetActive())
                {
                    scoreBoard.AddScore(Judgement.LATE);
                    activeNoteList.Remove(activeNoteList[i]);
                }
            }
            // ノートを出現する
            if (noteIndex < timingArray.Length)
            {
                if (AudioManager.Instance.GetTime() > (timingArray[noteIndex] - fallTime))
                {
                    NoteAdd(noteIndex++);
                }
            }
        }
        void NoteAdd(int index)
        {
            Note note = GetPassiveNote();
            if (note != null)
            {
                note.Show(timingArray[index], keyArray[index]);
                activeNoteList.Add(note);
                note.SetActive(true);
            }
            else
            {
                // プールが足りない場合
                Debug.Log("ノートプールが不足しています。");
            }
        }
        Note GetPassiveNote()
        {
            for (int i = 0; i < poolSize; i++)
            {
                Note note = notePool[(poolIndex + i) % poolSize];
                if (!note.GetActive())
                {
                    poolIndex = (i + 1) % poolSize;
                    return note;
                }
            }
            return null;
        }
        public Judgement NoteSeek(int key)
        {
            for (int i = 0; i < activeNoteList.Count; i++)
            {
                if (activeNoteList[i].GetActive() && activeNoteList[i].GetLine() == key)
                {
                    Judgement judge = activeNoteList[i].NoteOn();
                    if (judge == Judgement.GREAT || judge == Judgement.GOOD || judge == Judgement.BAD)
                    {
                        scoreBoard.AddScore(judge);
                        activeNoteList.Remove(activeNoteList[i]);
                    }
                    else if (judge == Judgement.EARLY || judge == Judgement.LATE)
                    {
                    }
                    return judge;
                }
            }
            return Judgement.NOJUDGE;
        }
    }
}