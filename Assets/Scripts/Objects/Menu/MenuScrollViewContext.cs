/** 
 * Copyright (c) 2017 setchi
 * Released under the MIT license
 * https://github.com/setchi/FancyScrollView/blob/master/LICENSE
 */
using System;

namespace FancyScrollView
{
    public class MenuScrollViewContext
    {
        int selectedIndex = 1;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                var prevSelectedIndex = selectedIndex;
                selectedIndex = value;
                if (prevSelectedIndex != selectedIndex)
                {
                    if (OnSelectedIndexChanged != null)
                    {
                        OnSelectedIndexChanged(selectedIndex);
                    }
                }
            }
        }

        public Action<MenuScrollViewCell> OnPressedCell;
        public Action<int> OnSelectedIndexChanged;
    }
}
