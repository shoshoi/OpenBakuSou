using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BakuSou
{
    /// <summary>
    /// BakusouMusicDataをローディングするための抽象クラス。
    /// BakusouMusicDataはリソースや外部ファイルから、この抽象クラスを継承した
    /// クラスから、ロードする。
    /// </summary>
    public abstract class AbstractMusicDataLoader
    {
        protected List<BakusouMusicData> musicDataList;
        protected string path;

        public AbstractMusicDataLoader(string path)
        {
            this.path = path;
            this.musicDataList = new List<BakusouMusicData>();
        }

        /// <summary>
        /// ロードしたBakusouMusicDataのリストを返す
        /// </summary>
        /// <returns>BakusouMusicDataのリスト</returns>
        public List<BakusouMusicData> GetMusicDataList()
        {
            Load();
            return musicDataList;
        }

        /// <summary>
        /// リソースや外部ファイルからBakusouMusicDataをロードする処理を実装する。
        /// ロードしたBakusouMusicDataは、musicDataListに格納する。
        /// </summary>
        abstract protected void Load();

    }
}