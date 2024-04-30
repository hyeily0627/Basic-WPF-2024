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

namespace ex04_wpf_bikeshop
{
    /// <summary>
    /// ContactPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContactPage : Page
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // 코드에서는 속성에 값을 지정할 때 사용 
            Bike MyBike = new Bike();
            MyBike.Speed = 60;
            MyBike.Color = Colors.Red;

            TextBox text1 = new TextBox();
            StpBike.DataContext = MyBike;   
        }

        /*
        // 슬라이더 + 프로그레스바 설정
        private void SldValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PrgValue.Value = (double)e.NewValue;
            // 라벨 숫자 표시(1 : 소숫점 1자리까지, 0 : 정수만)
            LblValue.Content = Math.Round(PrgValue.Value, 0);
        }
        */
    }
}
