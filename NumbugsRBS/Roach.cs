using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace NumbugsRBS
{
   
	public class Roach : Bug
	{

		public Roach(int x, int y) : base(2, x, y)
		{
			this.Id = 2;
			this.setValue();
			this.bitmapImage = new Image();
            this.bitmapImage.Source = new BitmapImage(new Uri(@"Assets/roach.png"));

		}
        public Roach()
            : base()
        {
            this.Id = 2;
            this.setValue();

        }
		public Roach(int value, int x, int y) : base(2, x, y)
		{
			this.Value = value;
			this.bitmapImage = new Image();
            this.bitmapImage.Source = new BitmapImage(new Uri(@"Assets/roach.png"));

		}

		public override void setValue()
		{
			Random rand = new Random();
			this.value_Renamed = rand.Next(10) + 11; // [11,20]
		}

	}

}

