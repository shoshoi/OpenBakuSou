using UnityEngine;
using System.Collections.Generic;

namespace BakuSou
{
    public class MusicDataResourcesLoader : AbstractMusicDataLoader
    {
        public MusicDataResourcesLoader(string path) : base(path)
        {
        }

        protected override void Load()
        {

            // 楽曲の一覧を取得する
            MusicListJson list;
            string json = Resources.Load(path).ToString();
            list = JsonUtility.FromJson<MusicListJson>(json);

            BakusouMusicData musicData;
            MusicListItemJson item;
            MusicInf inf;
            MusicDTO.EditData data;
            MusicOldDTO oldData;

            // 楽曲の詳細な情報を取得する
            for (int i = 0; i < list.items.Length; i++)
            {
                musicData = new BakusouMusicData();

                // id,pathを読み込む
                item = list.items[i];

                // 楽曲情報を読み込む
                json = Resources.Load("Music/" + item.path + "/info").ToString();
                inf = JsonUtility.FromJson<MusicInf>(json);

                // 譜面情報を読み込む
                if (inf.score_ver == 1)
                {
                    json = Resources.Load("Music/" + item.path + "/score").ToString();
                    data = JsonUtility.FromJson<MusicDTO.EditData>(json);
                    MusicDTOFormatter musicDTOFormatter = new MusicDTOFormatter(item, inf, data);
                    musicData = musicDTOFormatter.ToBakusouMusicData();
                }
                else if (inf.score_ver == 0)
                {
                    json = Resources.Load("Music/" + item.path + "/score").ToString();
                    oldData = JsonUtility.FromJson<MusicOldDTO>(json);
                    MusicDTOFormatter musicDTOFormatter = new MusicDTOFormatter(item, inf, oldData);
                    musicData = musicDTOFormatter.ToBakusouMusicData();
                }

                musicDataList.Add(musicData);
            }
        }
    }
}