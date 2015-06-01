using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttentionChannel
{
    /// <summary>
    /// 频道模型
    /// </summary>
    public class ChannelModel : INotifyPropertyChanged
    {
        #region 字段
        private string name;
        private bool isAttention;
        private int serialNumber;

        #endregion

        #region 属性
        /// <summary>
        /// 频道名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Refresh("Name");
            }
        }
        /// <summary>
        /// 是否取消关注
        /// </summary>
        public bool IsCancelAttention
        {
            get { return isAttention; }
            set
            {
                isAttention = value;
                Refresh("IsAttention");
            }
        }
        /// <summary>
        /// 序号
        /// </summary>
        public int SerialNumber
        {
            get { return serialNumber; }
            set
            {
                serialNumber = value;
                Refresh("SerialNumber");
            }
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
