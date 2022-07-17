/** 
 * Copyright (c) 2017 setchi
 * Released under the MIT license
 * https://github.com/setchi/FancyScrollView/blob/master/LICENSE
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using BakuSou;

namespace FancyScrollView
{
    public class MenuScrollViewCell
        : FancyScrollViewCell<MenuScrollViewCellDto, MenuScrollViewContext>
    {
        [SerializeField]
        Animator animator;
        [SerializeField]
        Text message;
        [SerializeField]
        Image image;
        [SerializeField]
        Button button;
        [SerializeField]
        int id;

        static readonly int scrollTriggerHash = Animator.StringToHash("scroll");
        MenuScrollViewContext context;
        bool selected = true;
        AudioManager preview;
        AudioSource select;
        AudioSource submit;
        MenuController menuController;

        void Start()
        {
            var rectTransform = transform as RectTransform;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchoredPosition3D = Vector3.zero;
            UpdatePosition(0);

            button.onClick.AddListener(OnPressedCell);
            GameObject p = GameObject.Find("preview");
            preview = p.GetComponent<AudioManager>();
            GameObject selecton = GameObject.Find("selecton");
            select = selecton.GetComponent<AudioSource>();
            GameObject submiton = GameObject.Find("submiton");
            submit = selecton.GetComponent<AudioSource>();
            menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
        }

        /// <summary>
        /// コンテキストを設定します
        /// </summary>
        /// <param name="context"></param>
        public override void SetContext(MenuScrollViewContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// セルの内容を更新します
        /// </summary>
        /// <param name="itemData"></param>
        public override void UpdateContent(MenuScrollViewCellDto itemData)
        {
            if(image.sprite == null || id != itemData.Id)
            {
                image.sprite = GameParameter.Instance().GetMusicData(itemData.Id).GetImage();
            }
            id = itemData.Id;
            if (context != null)
            {
                var isSelected = context.SelectedIndex == DataIndex;
                image.color = new Color32(255, 255, 255, 255);
                if(currentPosition > 0.45f && currentPosition < 0.55f)
                {
                    if (!selected)
                    {
                        GameParameter.Instance().selectMusicDataId = this.id;
                        context.SelectedIndex = DataIndex;
                        if(select != null)
                        {
                            if (select.time > 0)
                            {
                                select.Stop();
                            }
                            select.Play();
                        }
                        if (preview != null)
                        {
                            if (preview.IsPlaying())
                            {
                                preview.Stop();
                                preview.SetClip(GameParameter.Instance().GetSelectMusicData().GetPreviewAudioClip());
                            }
                            preview.Play();
                        }

                        selected = true;
                    }
                    this.transform.SetSiblingIndex(1);
                    image.color = new Color32(255, 255, 255, 255);
                }else{
                    this.transform.SetSiblingIndex(0);
                    image.color = new Color32(255, 255, 255, 150);
                    selected = false;
                }
            }
        }

        public void UpdatePreviewMusic()
        {
            if (preview != null)
            {
                if (preview.IsPlaying())
                {
                    preview.Stop();
                    preview.SetClip(GameParameter.Instance().GetSelectMusicData().GetPreviewAudioClip());
                }
                preview.Play();
            }

        }
        /// <summary>
        /// セルの位置を更新します
        /// </summary>
        /// <param name="position"></param>
        public override void UpdatePosition(float position)
        {
            currentPosition = position;
            animator.Play(scrollTriggerHash, -1, position);
            animator.speed = 0;
        }

        // GameObject が非アクティブになると Animator がリセットされてしまうため
        // 現在位置を保持しておいて OnEnable のタイミングで現在位置を再設定します
        float currentPosition = 0;
        void OnEnable()
        {
            UpdatePosition(currentPosition);
        }

        void OnPressedCell()
        {
            if (!menuController.onClick)
            {
                menuController.onClick = true;
            }
            /*
            submit.Play();

            FadeManager.FadeOut(2);
            if (context != null)
            {
                context.OnPressedCell(this);
            }
            */
        }
    }
}
