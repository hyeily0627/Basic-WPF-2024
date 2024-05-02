using System;
using System.Collections.Generic;

using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex05_wpf_bikeshop
{
    //Notifier 를 상속받으면 AutoProperty { get; set; } 은 사용 불가 
    internal class Bike : Notifier 
    {
        // 멤버변수 
        private double speed; 
        private Color color;

        // 속성 
        public double Speed
        {
            get { return speed; }
            set 
            { 
                speed = value; 
                // 속성값이 변경되는 것을 알려주려면 이 작업이 필요
                OnpropertyChange(nameof(Speed));    
            }
        }

        public Color Color
        {
            get { return color; }
            set 
            { 
                color = value; 
                OnpropertyChange(nameof(Color));
            }
        }


        /*
        public double Speed { get; set; }

        public Color Color { get; set; }    
              //클래스 // 프로퍼티 
        */

    }
}
