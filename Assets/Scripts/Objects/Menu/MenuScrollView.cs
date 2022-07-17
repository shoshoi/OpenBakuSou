/** 
 * Copyright (c) 2017 setchi
 * Released under the MIT license
 * https://github.com/setchi/FancyScrollView/blob/master/LICENSE
 */
using System.Collections.Generic;
using UnityEngine;

namespace FancyScrollView
{
    public class MenuScrollView : FancyScrollView<MenuScrollViewCellDto, MenuScrollViewContext>
    {
        [SerializeField]
        ScrollPositionController scrollPositionController;
        [SerializeField]
        float scrollToDuration = 0.4f;

        void Awake()
        {
            scrollPositionController.OnUpdatePosition(UpdatePosition);
            SetContext(new MenuScrollViewContext { OnPressedCell = OnPressedCell });
        }

        public void UpdateData(List<MenuScrollViewCellDto> data, MenuScrollViewContext context)
        {
            context.OnPressedCell = OnPressedCell;
            SetContext(context);

            cellData = data;
            scrollPositionController.SetDataCount(cellData.Count);
            UpdateContents();
        }
        public void UpdateSelection(int selectedCellIndex)
        {
            scrollPositionController.ScrollTo(selectedCellIndex, scrollToDuration);
            context.SelectedIndex = selectedCellIndex;
            UpdateContents();
        }

        void OnPressedCell(MenuScrollViewCell cell)
        {
            //scrollPositionController.ScrollTo(cell.DataIndex, 0.4f);
            //context.SelectedIndex = cell.DataIndex;
            //UpdateContents();
        }


        void HandleItemSelected(int selectedItemIndex)
        {
            context.SelectedIndex = selectedItemIndex;
            UpdateContents();
        }

    }
}
