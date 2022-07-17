/** 
 * Copyright (c) 2015 setchi
 * Released under the MIT license
 * https://github.com/setchi/NoteEditor/blob/master/LICENSE
 */
using System;
using System.Collections.Generic;

namespace BakuSou
{
    [Serializable]
    public class MusicDTO
    {
        [System.Serializable]
        public class EditData
        {
            public string name;
            public int maxBlock;
            public int BPM;
            public int offset;
            public List<Note> notes;
        }

        [System.Serializable]
        public class Note
        {
            public int LPB;
            public int num;
            public int block;
            public int type;
            public List<Note> notes;
        }
    }
}