
namespace BakuSou
{
    public class MusicDTOFormatter
    {
        MusicListItemJson item = null;
        MusicInf inf = null;
        MusicDTO.EditData dto_data = null;
        MusicOldDTO old_data = null;

        public MusicDTOFormatter(MusicListItemJson item, MusicInf inf, MusicDTO.EditData data)
        {
            this.item = item;
            this.inf = inf;
            dto_data = data;
        }
        public MusicDTOFormatter(MusicListItemJson item, MusicInf inf, MusicOldDTO data)
        {
            this.item = item;
            this.inf = inf;
            old_data = data;
        }
        public BakusouMusicData ToBakusouMusicData()
        {
            BakusouMusicData musicData = new BakusouMusicData();
            if (dto_data != null)
            {
                // MusicDTO.EditDataをSimpleMusicDataに変換する
                int[] key = new int[dto_data.notes.Count];
                double[] timing = new double[dto_data.notes.Count];

                var j = 0;
                foreach (var item in dto_data.notes)
                {
                    double lpb = item.LPB;
                    double num = item.num;
                    int block = item.block;

                    //1拍あたりの時間を計算する
                    double section = 60 / (double)dto_data.BPM /* *4 */;
                    double beat = section / lpb;

                    timing[j] = beat * num;
                    key[j] = block;
                    j++;
                }
                musicData.TimingArray = timing;
                musicData.KeyArray = key;
                musicData.Bpm = dto_data.BPM;

            }
            else if (old_data != null)
            {
                musicData.TimingArray = old_data.timing;
                musicData.KeyArray = old_data.key;
                musicData.Bpm = 160;
            }
            musicData.Id = item.id;
            musicData.Path = item.path;
            musicData.Inf = inf;

            return musicData;
        }
    }
}