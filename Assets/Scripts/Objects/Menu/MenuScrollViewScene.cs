using System.Collections.Generic;
/** 
 * Copyright (c) 2017 setchi
 * Released under the MIT license
 * https://github.com/setchi/FancyScrollView/blob/master/LICENSE
 */
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using BakuSou;

namespace FancyScrollView
{
    public class MenuScrollViewScene : MonoBehaviour
    {
        [SerializeField]
        MenuScrollView scrollView;
        [SerializeField]
        Button prevCellButton;
        [SerializeField]
        Button nextCellButton;
        [SerializeField]
        Text selectedItemInfo;

        List<MenuScrollViewCellDto> cellData;
        MenuScrollViewContext context;
        AudioManager preview;

        public void HandlePrevButton()
        {
            var index = (context.SelectedIndex - 1) < 0 ? cellData.Count -1 : context.SelectedIndex - 1;
            
            SelectCell(index);
        }

        public void HandleNextButton()
        {
            SelectCell((context.SelectedIndex + 1) % cellData.Count);
        }
        public bool HandleCellUpdate(string sort, string[] type, string[] genre)
        {
            // Jirno : 楽曲ソートで絞り込みをしたときの設定
            List<MenuScrollViewCellDto> cellDataList = new List<MenuScrollViewCellDto>();
            GameParameter gameParameter = GameParameter.Instance();
            List<BakusouMusicData> musicDatas = gameParameter.GetSortMusicData(sort, type, genre);

            if(musicDatas.Count > 0)
            {
                foreach (var item in musicDatas)
                {
                    var cellData = new MenuScrollViewCellDto();
                    cellData.Message = item.Inf.title;
                    cellData.Id = item.Id;
                    cellDataList.Add(cellData);
                }
                cellData = cellDataList;
                context = new MenuScrollViewContext();
                context.OnSelectedIndexChanged = HandleSelectedIndexChanged;
                //context.SelectedIndex = 0;
                scrollView.UpdateData(cellData, context);
                gameParameter.selectMusicDataId = musicDatas[0].Id;
                SelectCell(-1);

                scrollView.UpdateSelection(context.SelectedIndex);
                SelectCell(0);


                GameObject p = GameObject.Find("preview");
                preview = p.GetComponent<AudioManager>();
                if (preview.IsPlaying())
                {
                    preview.Stop();
                    preview.SetClip(GameParameter.Instance().GetSelectMusicData().GetPreviewAudioClip());
                }
                preview.Play();
                return true;
            }
            return false;
        }
        void SelectCell(int index)
        {
            Debug.Log(cellData.Count);
            if (index >= 0 && index < cellData.Count)
            {
                GameParameter.Instance().selectMusicDataId = cellData[index].Id;
                
                scrollView.UpdateSelection(index);

            }
        }

        void HandleSelectedIndexChanged(int index)
        {
            //selectedItemInfo.text = String.Format("Selected item info: index {0}", index);
        }

        void Awake()
        {
        }

        void Start()
        {
            // Jirno: スクロールメニューの初期設定
            FadeManager.FadeIn();
            List<MenuScrollViewCellDto> cellDataList = new List<MenuScrollViewCellDto>();
            GameParameter gameParameter = GameParameter.Instance();
            SaveDataDTO saveData = SaveManager.Instance().GetSaveData();
            List<BakusouMusicData> musicDatas = null;
            if (gameParameter.sortedMusicDatas == null)
            {
                musicDatas = gameParameter.musicDatas;
            }
            else
            {
                musicDatas = gameParameter.sortedMusicDatas;
            }

            int count = 0;
            int select_index = 0;
            foreach (var item in musicDatas)
            {
                var cellData = new MenuScrollViewCellDto();
                cellData.Message = item.Inf.title;
                cellData.Id = item.Id;
                cellDataList.Add(cellData);
                if (item.Id == GameParameter.Instance().selectMusicDataId) select_index = count;
                count++;
            }
            cellData = cellDataList;
            context = new MenuScrollViewContext();
            context.OnSelectedIndexChanged = HandleSelectedIndexChanged;
            context.SelectedIndex = select_index;

            scrollView.UpdateData(cellData,context);
            scrollView.UpdateSelection(context.SelectedIndex);

            GameObject p = GameObject.Find("preview");
            preview = p.GetComponent<AudioManager>();
            preview.SetClip(GameParameter.Instance().GetSelectMusicData().GetPreviewAudioClip());

            preview.Play();
        }
    }
}
