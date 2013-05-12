using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace NumbugsRBS
{
    public class Ladybird : Bug
    {

        public Ladybird(int x, int y)
            : base(3, x, y)
        {
            this.Id = 3;
            this.setValue();
            this.bitmapImage = new Image();
            this.bitmapImage.Source = new BitmapImage(new Uri(@"Assets/ladybug.png"));
            Canvas.SetLeft(this.bitmapImage, x);
            Canvas.SetTop(this.bitmapImage, y);
        }
        public Ladybird()
            : base()
        {
            this.Id = 3;
            this.setValue();
         
        }

        public Ladybird(int value, int x, int y)
            : base(3, x, y)
        {
            this.Value = value;
            this.bitmapImage = new Image();
            this.bitmapImage.Source = new BitmapImage(new Uri(@"Assets/ladybug.png"));

        }

        public override void setValue()
        {
            Random rand = new Random();
            this.value_Renamed = (rand.Next(6) + 5) * 5; // 25, 30, 35, 40, 45, 50
        }

    }

    
}

