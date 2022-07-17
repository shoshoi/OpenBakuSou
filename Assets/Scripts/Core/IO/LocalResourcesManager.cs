using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BakuSou
{
    public class LocalResourcesManager : MonoBehaviour
    {

        Dictionary<string, System.Object> loadFiles = new Dictionary<string, System.Object>();
        List<string> keys = new List<string>();

        private void Start()
        {
            DontDestroyOnLoad(this);
            string folder = "/music";
#if UNITY_EDITOR
            folder = "/resources/music";
#endif

            if (System.IO.Directory.Exists(@Application.dataPath + folder))
            {
                string[] directories = System.IO.Directory.GetDirectories(@Application.dataPath + "/resources/music", "*");
                for (int i = 0; i < directories.Length; i++)
                {
                    if (System.IO.File.Exists(directories[i] + "/info.json"))
                    {
                        LoadText(directories[i] + "/info.json");
                    }
                    else
                    {
                        break;
                    }
                    if (System.IO.File.Exists(directories[i] + "/music.wav"))
                    {
                        LoadMusic(directories[i] + "/music.wav");
                    }
                    else if (System.IO.File.Exists(directories[i] + "/music.mp3"))
                    {
                        //localResources.LoadMusic(directories[i] + "/music.mp3");
                        //break;
                    }
                    else
                    {
                        break;
                    }
                    if (System.IO.File.Exists(directories[i] + "/score.json"))
                    {
                        LoadText(directories[i] + "/score.json");
                    }
                    else
                    {
                        break;
                    }

                    if (System.IO.File.Exists(directories[i] + "/image.png"))
                    {
                        LoadImage(directories[i] + "/image.png");
                    }
                    else if (System.IO.File.Exists(directories[i] + "/image.jpg"))
                    {
                        LoadImage(directories[i] + "/image.jpg");
                    }
                    else if (System.IO.File.Exists(directories[i] + "/image.jpeg"))
                    {
                        LoadImage(directories[i] + "/image.jpeg");
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        private void Update()
        {
            bool readable = true;
            foreach (string key in keys)
            {
                readable &= loadFiles.ContainsKey(key);
            }
            if (readable)
            {
                Debug.Log("LocalResources loaded");
                GameParameter gameParameter = GameParameter.Instance();
                gameParameter.SetLocalResources(this);
            }
        }
        public System.Object GetLoadFile(string path)
        {
            Debug.Log("get:" + path);
            if (loadFiles.ContainsKey(path))
            {
                return loadFiles[path];
            }
            else
            {
                return null;
            }
        }
        public void LoadText(string path)
        {
            StartCoroutine(LoadLocalFile(path, "text"));
        }
        public void LoadMusic(string path)
        {
            StartCoroutine(LoadLocalFile(path, "music"));
        }
        public void LoadImage(string path)
        {
            StartCoroutine(LoadLocalFile(path, "image"));
        }


        IEnumerator LoadLocalFile(string path, string format)
        {
            string fullpath = path;

            string prep = "file://";
#if UNITY_STANDALONE_WIN
        prep = "file:///";
#endif

            string key =
            System.IO.Path.GetDirectoryName(path) + "/" +
            System.IO.Path.GetFileNameWithoutExtension(path);
            keys.Add(key);
            WWW www = new WWW(prep + path);
            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                Debug.Log("key:" + key);
                switch (format)
                {
                    case "text":
                        byte[] bytes = www.bytes;
                        var encode = new UTF8Encoding(false);
                        string text;
                        if ((bytes[0] == 0xef) && (bytes[1] == 0xbb) && (bytes[2] == 0xbf))
                        {
                            text = encode.GetString(bytes, 3, bytes.Length - 3); // BOMを無視する
                        }
                        else
                        {
                            text = encode.GetString(bytes);
                        }
                        loadFiles.Add(key, (System.Object)text);
                        break;
                    case "music":
                        loadFiles.Add(key, (System.Object)www.GetAudioClip());
                        break;
                    case "image":
                        loadFiles.Add(key, (System.Object)www.texture);
                        break;
                }
            }
        }
    }
}