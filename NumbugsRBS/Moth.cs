using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace NumbugsRBS
{
    public class Moth : Bug
	{

		public Moth(int x, int y) : base(1,x,y)
		{
			this.Id = 1;
			this.setValue();
		    
		}
        public Moth()
            : base()
        {
            this.Id = 1;
            this.setValue();

        }

		public Moth(int value, int x, int y) : base(1, x, y)
		{
			this.Value = value;
			this.bitmapImage = new Image();
            this.bitmapImage.Source = new BitmapImage(new Uri(@"Assets/moth.png"));

		}

		public override void setValue()
		{
			Random rand = new Random();
			this.value_Renamed = rand.Next(5) + 6; // [6,10]
		}

	}

}

