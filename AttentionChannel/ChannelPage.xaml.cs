using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AttentionChannel
{
    /// <summary>
    /// AttentionChannelPage1.xaml 的交互逻辑
    /// </summary>
    public partial class ChannelPage : Grid, INotifyPropertyChanged
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
        /// <summary>
        /// 当前页的索引
        /// </summary
        private ObservableCollection<ChannelModel> currentChannelList;
        PageIndex pageIndex;
        #endregion

        #region 属性

        /// <summary>
        /// 当前页的索引
        /// </summary
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (value >= 0 && value <= pageCount)
                    currentIndex = value;
                Refresh("CurrentIndex");
            }
        }
        /// <summary>
        /// 当前显示的频道列表
        /// </summary>
        public ObservableCollection<ChannelModel> CurrentChannelList
        {
            get { return currentChannelList; }
            set
            {
                currentChannelList = value;
                Refresh("CurrentChannelList");
            }
        }
        #endregion

        #region 函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public ChannelPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="channeles">频道列表</param>
        public ChannelPage(List<ChannelModel> channeles)
            : this()
        {
            this.channeles = channeles;
            double pageNumebr = channeles.Count / number;
            pageCount = Math.Ceiling(pageNumebr);
            this.DataContext = this;
            CurrentChannelList = GetDataContextByIndex(CurrentIndex);
            InitilzePage();
        }

        private void InitilzePage()
        {
            pageIndex = new PageIndex((int)pageCount);
            pageIndex.DataContext = this;
            pageIndex.HorizontalAlignment = HorizontalAlignment.Right;
            this.rootGrid.Children.Add(pageIndex);
            Grid.SetColumn(pageIndex, 1);
            Grid.SetRow(pageIndex, 2);
            pageIndex.CreateEllipse((int)pageCount);
        }
        #endregion

        #region 事件处理
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousPageClick(object sender, RoutedEventArgs e)
        {
            CurrentIndex -= 1;
            this.CurrentChannelList = GetDataContextByIndex(CurrentIndex);
            pageIndex.SetSelecteItem(CurrentIndex);
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPageClick(object sender, RoutedEventArgs e)
        {
            CurrentIndex += 1;
            this.CurrentChannelList = GetDataContextByIndex(CurrentIndex);
            pageIndex.SetSelecteItem(CurrentIndex);

        }
        /// <summary>
        /// 根据索引获取页面显示的数据
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private ObservableCollection<ChannelModel> GetDataContextByIndex(int index)
        {
            if (channeles == null)
                return null;
            var temp = channeles.Skip(index * number).Take(number);
            return new ObservableCollection<ChannelModel>(temp);
        }
        /// <summary>
        /// 全选按钮点击处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxAllSelectClick(object sender, RoutedEventArgs e)
        {
            foreach (var item in channeles)
            {
                item.IsCancelAttention = (bool)cbxAllSelect.IsChecked;
            }

            this.CurrentChannelList = GetDataContextByIndex(CurrentIndex);
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void Refresh(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
