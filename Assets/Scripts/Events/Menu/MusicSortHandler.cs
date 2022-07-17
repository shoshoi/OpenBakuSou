using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BakuSou
{
    public class MusicSortHandler : MonoBehaviour
    {
        private FancyScrollView.MenuScrollViewScene viewScript;
        public GameObject sort_toggle_id;
        public GameObject sort_toggle_difficulty;
        public GameObject sort_toggle_name;
        public GameObject sort_toggle_date;

        public GameObject type_toggle_original;
        public GameObject type_toggle_arrange;

        public GameObject genre_toggle_movie;
        public GameObject genre_toggle_live;
        public GameObject genre_toggle_etc;

        GameObject resultObject;

        // Use this for initialization
        void Start()
        {
            var viewScene = GameObject.Find("MainCanvas");
            viewScript = viewScene.GetComponent<FancyScrollView.MenuScrollViewScene>();
            GameParameter.Instance().selectMusicDataId = 1;
            resultObject = GameObject.Find("Result");


            SaveDataDTO saveData = SaveManager.Instance().GetSaveData();
            //saveData.sort.sort = sort_array[0];
            //saveData.sort.type = type_array;
            //saveData.sort.genre = genre_array;

            sort_toggle_id.GetComponent<Toggle>().isOn = false;
            sort_toggle_difficulty.GetComponent<Toggle>().isOn = false;
            sort_toggle_name.GetComponent<Toggle>().isOn = false;
            sort_toggle_date.GetComponent<Toggle>().isOn = false;
            type_toggle_original.GetComponent<Toggle>().isOn = false;
            type_toggle_arrange.GetComponent<Toggle>().isOn = false;
            genre_toggle_movie.GetComponent<Toggle>().isOn = false;
            genre_toggle_live.GetComponent<Toggle>().isOn = false;
            genre_toggle_etc.GetComponent<Toggle>().isOn = false;

            switch (GameParameter.Instance().sort.sort)
            {
                case "id":
                    sort_toggle_id.GetComponent<Toggle>().isOn = true;
                    break;
                case "level":
                    sort_toggle_difficulty.GetComponent<Toggle>().isOn = true;
                    break;
                case "title":
                    sort_toggle_name.GetComponent<Toggle>().isOn = true;
                    break;
                case "date":
                    sort_toggle_date.GetComponent<Toggle>().isOn = true;
                    break;
            }

            foreach(string item in GameParameter.Instance().sort.type)
            {
                Debug.Log("saveData1:" + item);
                switch (item)
                {
                    case "original":
                        type_toggle_original.GetComponent<Toggle>().isOn = true;
                        break;
                    case "arrange":
                        type_toggle_arrange.GetComponent<Toggle>().isOn = true;
                        break;
                }
            }

            foreach (string item in GameParameter.Instance().sort.genre)
            {
                Debug.Log("saveData2:" + item);
                switch (item)
                {
                    case "nicovideo":
                        genre_toggle_movie.GetComponent<Toggle>().isOn = true;
                        break;
                    case "nicolive":
                        genre_toggle_live.GetComponent<Toggle>().isOn = true;
                        break;
                    case "etc":
                        genre_toggle_etc.GetComponent<Toggle>().isOn = true;
                        break;
                }
            }
        }

        // Update is called once per frame
        public void SortButton()
        {
            ArrayList sort = new ArrayList();
            ArrayList type = new ArrayList();
            ArrayList genre = new ArrayList();

            Toggle toggle = sort_toggle_id.GetComponent<Toggle>();
            if (toggle.isOn) sort.Add("id");
            toggle = sort_toggle_difficulty.GetComponent<Toggle>();
            if (toggle.isOn) sort.Add("level");
            toggle = sort_toggle_name.GetComponent<Toggle>();
            if (toggle.isOn) sort.Add("title");
            toggle = sort_toggle_date.GetComponent<Toggle>();
            if (toggle.isOn) sort.Add("date");

            toggle = type_toggle_original.GetComponent<Toggle>();
            if (toggle.isOn) type.Add("original");
            toggle = type_toggle_arrange.GetComponent<Toggle>();
            if (toggle.isOn) type.Add("arrange");

            toggle = genre_toggle_movie.GetComponent<Toggle>();
            if (toggle.isOn) genre.Add("nicovideo");
            toggle = genre_toggle_live.GetComponent<Toggle>();
            if (toggle.isOn) genre.Add("nicolive");
            toggle = genre_toggle_etc.GetComponent<Toggle>();
            if (toggle.isOn) genre.Add("etc");

            string[] sort_array/* = { "id", "level", "title", "date" }*/;
            string[] type_array/* = { "original", "arrange" }*/;
            string[] genre_array/* = { "nicovideo", "nicolive", "etc" }*/;

            /*if (sort.Count > 0) */
            sort_array = (string[])sort.ToArray(typeof(string));
            /*if (type.Count > 0) */
            type_array = (string[])type.ToArray(typeof(string));
            /*if (genre.Count > 0) */
            genre_array = (string[])genre.ToArray(typeof(string));


            bool result = viewScript.HandleCellUpdate(sort_array[0], type_array, genre_array);
            if (result)
            {
                GetComponent<SettingSwitchHandler>().SettingButtonSwitch();
                resultObject.GetComponent<Text>().text = "";
                SaveDataDTO saveData = SaveManager.Instance().GetSaveData();
                GameParameter.Instance().sort.sort = sort_array[0];
                GameParameter.Instance().sort.type = type_array;
                GameParameter.Instance().sort.genre = genre_array;
                SaveManager.Instance().Save();
            }
            else
            {
                resultObject.GetComponent<Text>().text = "ヒットしませんでした。\nソート条件を変更してください。";
            }
        }
    }
}
 
 
 