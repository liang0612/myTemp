﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;


namespace AttentionChannel
{
    /// <summary>
    /// 关注频道的分页索引
    /// </summary>
    public class PageIndex : StackPanel
    {
        #region 字段
        /// <summary>
        /// 圆点的大小
        /// </summary>
        private int ellipseSize = 12;

        /// <summary>
        /// 圆点选中的的颜色
        /// </summary>
        private SolidColorBrush selectedColor;

        /// <summary>
        /// 圆点未选中的颜色
        /// </summary>
        private SolidColorBrush normalColor;

        /// <summary>
        /// 圆点列表
        /// </summary>
        List<Ellipse> ellipses = new List<Ellipse>();
        #endregion

        #region 函数

        /// <summary>
        /// 创建一个分页索引的实例
        /// </summary>
        /// <param name="number">页面数量</param>
        public PageIndex(int number)
            : base()
        {
            this.Orientation = Orientation.Horizontal;
            Color color = (Color)ColorConverter.ConvertFromString("#d3d0cf");
            normalColor = new SolidColorBrush(color);

            color = (Color)ColorConverter.ConvertFromString("#6f922e");
            selectedColor = new SolidColorBrush(color);
        }

        /// <summary>
        /// 创建圆点集合
        /// </summary>
        /// <param name="number">圆点数量</param>
        public void CreateEllipse(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Margin = new System.Windows.Thickness(0, 0, 5, 0);
                ellipse.Tag = i;
                ellipse.Width = ellipseSize;
                ellipse.Height = ellipseSize;
                ellipse.Fill = normalColor;
                this.Children.Add(ellipse);
                ellipses.Add(ellipse);
            }
            SetSelecteIndex(0);
        }

        /// <summary>
        /// 设置选中项的索引
        /// </summary>
        /// <param name="index"></param>
        public void SetSelecteIndex(int index)
        {

            if (index < 0 || index >= ellipses.Count)
                return;
            for (int i = 0; i < ellipses.Count; i++)
            {
                Ellipse sllipse = ellipses[i];
                if (index == i)
                    sllipse.Fill = selectedColor;
                else
                    sllipse.Fill = normalColor;
            }

        }
        #endregion
    }
}
