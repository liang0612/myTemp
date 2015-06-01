using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AttentionChannel
{
    public class AttentionChannelPage : Grid
    {
        #region 字段
        /// <summary>
        /// 频道列表
        /// </summary>
        private List<ChannelModel> channeles;
        /// <summary>
        /// 当前页的索引
        /// </summary>
        private int currentIndex;
        /// <summary>
        /// 总页数
        /// </summary>
        private double pageCount;
        /// <summary>
        /// 单页显示频道的数量
        /// </summary>
        private const int number = 12;
        #endregion

        #region 方法
        /// <summary>
        /// 构造函数
        /// </summary>
        public AttentionChannelPage(List<ChannelModel> channeles)
        {
            this.channeles = channeles;
            double pageNumebr = channeles.Count / number;
            pageCount = Math.Ceiling(pageNumebr);
            this.DataContext = channeles;
            Initialization(channeles);
            
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialization(List<ChannelModel> channeles)
        {
            int rowCout = 4;
            int colunmcCount = 3;
            for (int i = 0; i < rowCout; i++)
            {
                RowDefinition row = new RowDefinition();
                this.RowDefinitions.Add(row);
            }

            for (int i = 0; i < colunmcCount; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                this.ColumnDefinitions.Add(column);
            }
        }

        #endregion

    }
}
