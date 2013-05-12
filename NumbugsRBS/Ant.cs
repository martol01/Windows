using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
namespace NumbugsRBS
{
    public class Ant : Bug
	{
        Random random = new Random();
		public Ant(int x, int y) : base(0,x,y)
		{
			this.Id = 0;
			this.setValue();
            this.bitmapImage = new Image();
           
            this.bitmapImage.Source = new BitmapImage(new Uri(@"Assets/ant.png"));
		}
        public Ant()
            : base()
        {
            this.Id = 0;
            this.value_Renamed = random.Next(5) + 1; // [1,5]
          
        }

		public Ant(int value, int x, int y) : base(0, x, y)
		{
			this.Value = value;
            this.bitmapImage = new Image();
            this.bitmapImage.Source = new BitmapImage(new Uri(@"Assets/ant.png"));
			
		}

		public override void setValue()
		{
			Random rand = new Random();
			this.value_Renamed = rand.Next(5) + 1; // [1,5]
            
		}


        
    }
}
