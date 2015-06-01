using System;
using System.Collections.Generic;
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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<ChannelModel> channeles = new List<ChannelModel>();
            for (int i = 0; i < 100; i++)
            {
                ChannelModel model = new ChannelModel();
                model.SerialNumber = i;
                model.Name = "湖南卫视" + i;
                channeles.Add(model);
            }

            ChannelPage page = new ChannelPage(channeles);
            root.Children.Add(page);
        }
    }
}
