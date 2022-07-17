using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    public sealed class GameParameter
    {
        /* Singletonクラス */
        private static GameParameter _singleInstance = new GameParameter();

        public List<BakusouMusicData> musicDatas; // 楽曲データの一覧
        public List<BakusouMusicData> sortedMusicDatas;
        public int selectMusicDataId;            // 選択中の楽曲のid
        public LocalResourcesManager localResources;
        public ResultData result;
        public string gameMode = "play";
        public string gameStatus = "";
        public List<Dictionary<string, float>> keyLog = new List<Dictionary<string, float>>();
        public SortDTO sort;

        private List<Dictionary<string, float>> dictPool = new List<Dictionary<string, float>>();
        int dictPoolSize = 1000;
        int dictPoolIndex = 0;

        public static GameParameter Instance()
        {
            return _singleInstance;
        }
        private GameParameter()
        {
            AbstractMusicDataLoader musicDataLoader;
            if (GameObject.Find("LocalResources") == null)
            {
                musicDataLoader = new MusicDataResourcesLoader("music/list");
            }
            else
            {
                Debug.Log("LocalResources");
                musicDataLoader = new MusicDataLocalFoldersLoader(1);
            }

            musicDatas = musicDataLoader.GetMusicDataList();
            sortedMusicDatas = new List<BakusouMusicData>(musicDatas);
            selectMusicDataId = 1;

            sort = new SortDTO();
            sort.sort = "id";
            sort.type = new string[] { "original", "arrange" };
            sort.genre = new string[] { "nicovideo", "nicolive", "etc" };
        }
        public BakusouMusicData GetSelectMusicData()
        {
            foreach(BakusouMusicData data in musicDatas)
            {
                if(data.Id == selectMusicDataId)
                {
                    return data;
                }
            }
            return null;
        }
        public BakusouMusicData GetMusicData(int id)
        {
            foreach (BakusouMusicData data in musicDatas)
            {
                if (data.Id == id)
                {
                    return data;
                }
            }
            return null;
        }
        public List<BakusouMusicData> GetSortMusicData(string sort, string[] type, string[] genre)
        {
            sortedMusicDatas = new List<BakusouMusicData>(musicDatas);

            for (int i = sortedMusicDatas.Count - 1; i >= 0; i--)
            {
                bool nokosu = false;
                foreach (string item in type)
                {
                    nokosu = nokosu || sortedMusicDatas[i].Inf.type.Equals(item);
                }
                if (!nokosu)
                {
                    sortedMusicDatas.RemoveAt(i);
                }
            }
            for (int i = sortedMusicDatas.Count - 1; i >= 0; i--)
            {
                bool nokosu = false;
                foreach (string item in genre)
                {
                    nokosu = nokosu || sortedMusicDatas[i].Inf.genre.Equals(item);
                }
                if (!nokosu)
                {
                    sortedMusicDatas.RemoveAt(i);
                }
            }
            Comparison<BakusouMusicData> c;
            switch (sort)
            {
                case "id":
                    c = new Comparison<BakusouMusicData>(IdCompare);
                    break;
                case "level":
                    c = new Comparison<BakusouMusicData>(LevelCompare);
                    break;
                case "title":
                    c = new Comparison<BakusouMusicData>(TitleCompare);
                    break;
                case "date":
                    c = new Comparison<BakusouMusicData>(DateCompare);
                    break;
                default:
                    c = new Comparison<BakusouMusicData>(IdCompare);
                    break;
            }
            sortedMusicDatas.Sort(c);
            return sortedMusicDatas;
        }
        public void SetLocalResources(LocalResourcesManager localResources)
        {
            this.localResources = localResources;
        }
        public bool IsToubakuMania()
        {
            return selectMusicDataId >= 21 && selectMusicDataId <= 24;
        }
        static int IdCompare(BakusouMusicData a, BakusouMusicData b)
        {
            return a.Id - b.Id;
        }
        static int LevelCompare(BakusouMusicData a, BakusouMusicData b)
        {
            return a.Inf.level - b.Inf.level;
        }
        static int TitleCompare(BakusouMusicData a, BakusouMusicData b)
        {
            return String.Compare(a.Inf.title, b.Inf.title);
        }
        static int DateCompare(BakusouMusicData a, BakusouMusicData b)
        {
            DateTime aTime = DateTime.Parse(a.Inf.date);
            DateTime bTime = DateTime.Parse(b.Inf.date);
            return aTime.CompareTo(bTime);
        }
        public void InitKeyLog()
        {
            keyLog = new List<Dictionary<string, float>>();
            dictPool = new List<Dictionary<string, float>>();
            for (int i=0;i < dictPoolSize; i++)
            {
                dictPool.Add(new Dictionary<string, float>());
            }
        }
        Dictionary<string, float> GetDictPool()
        {
            Dictionary<string, float> dict;
            if(dictPoolIndex < dictPoolSize)
            {
                dict = dictPool[dictPoolIndex];
                dictPoolIndex++;
            }
            else
            {
                dict = new Dictionary<string, float>();
            }
            return dict;
        }
        public void SetKeyLog( float time, int key)
        {
            Dictionary<string, float> dict = GetDictPool();
            dict.Add("time", time);
            dict.Add("key", key);
            keyLog.Add(dict);
        }
    }
}