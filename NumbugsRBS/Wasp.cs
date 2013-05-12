using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace NumbugsRBS
{
   public class Wasp : Bug
	{

		public Wasp(int x, int y) : base(4, x, y)
		{
			this.Id = 4;
			this.setValue();
			this.bitmapImage = new Image();
            this.bitmapImage.Source = new BitmapImage(new Uri(@"Assets/wasp.jpg"));

		}

        public Wasp()
            : base()
        {
            this.Id = 4;
            this.setValue();
        }

		public Wasp(int value, int x, int y) : base(4, x, y)
		{
			this.Value = value;
			this.bitmapImage = new Image();
            this.bitmapImage.Source = new BitmapImage(new Uri(@"Assets/wasp.jpg"));

		}

		public override void setValue()
		{
			Random rand = new Random();
			this.value_Renamed = (rand.Next(5) + 6) * 10; // 60, 70, 80, 90, 100
		}

	}


}

