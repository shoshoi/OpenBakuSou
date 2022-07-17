using UnityEngine;
using System.Collections.Generic;

namespace BakuSou
{
    public class MusicDataLocalFoldersLoader : AbstractMusicDataLoader
    {
        private int startId = 1;
        public string[] fs;
        public MusicDataLocalFoldersLoader(int startId) : base("/")
        {
            this.startId = startId;
        }

        protected override void Load()
        {
            BakusouMusicData musicData;
            MusicInf inf;
            MusicDTO.EditData data;
            MusicOldDTO oldData;
            LocalResourcesManager localResources = GameParameter.Instance().localResources;

            string folder = "/music";
#if UNITY_EDITOR
            folder = "/resources/music";
#endif

            if (System.IO.Directory.Exists(@Application.dataPath + folder))
            {
                string[] directories = System.IO.Directory.GetDirectories(@Application.dataPath + "/resources/music", "*");
                string json;
                for (int i = 0; i < directories.Length; i++)
                {
                    // id,pathを読み込む
                    MusicListItemJson item;
                    item = new MusicListItemJson();
                    item.id = startId + i;

                    if (System.IO.Directory.Exists(directories[i]))
                    {

                        if (System.IO.File.Exists(directories[i] + "/info.json"))
                        {
                            json = (string)localResources.GetLoadFile(directories[i] + "/info");
                            inf = JsonUtility.FromJson<MusicInf>(json);
                        }
                        else
                        {
                            break;
                        }
                        if (System.IO.File.Exists(directories[i] + "/music.wav"))
                        {
                            item.path = directories[i];
                        }
                        else if (System.IO.File.Exists(directories[i] + "/music.mp3"))
                        {
                            item.path = directories[i];
                        }
                        else
                        {
                            break;
                        }
                        if (System.IO.File.Exists(directories[i] + "/score.json"))
                        {
                            json = (string)localResources.GetLoadFile(directories[i] + "/score");
                            // 譜面情報を読み込む
                            if (inf.score_ver == 1)
                            {
                                Debug.Log(json);
                                data = JsonUtility.FromJson<MusicDTO.EditData>(json);
                                MusicDTOFormatter musicDTOFormatter = new MusicDTOFormatter(item, inf, data);
                                musicData = musicDTOFormatter.ToBakusouMusicData();
                            }
                            else if (inf.score_ver == 0)
                            {
                                oldData = JsonUtility.FromJson<MusicOldDTO>(json);
                                MusicDTOFormatter musicDTOFormatter = new MusicDTOFormatter(item, inf, oldData);
                                musicData = musicDTOFormatter.ToBakusouMusicData();
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                        musicDataList.Add(musicData);
                    }
                }
            }
        }
    }
}