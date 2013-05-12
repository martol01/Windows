using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace NumbugsRBS
{
    public abstract class Bug
    {

        internal int id_Renamed; // 0=ant, 1=
        internal int value_Renamed;
        internal Image bitmapImage;// actual bitmap
        internal int x_Renamed; // coordinates of centre of image
        internal int y_Renamed;

        public Bug()
        {

        }

        public Bug(int id, int x, int y)
            : base()
        {
            this.id_Renamed = id;
            this.Value = value_Renamed; // method does some checking
            this.x_Renamed = x;
            this.y_Renamed = y;
            //bitmap is set afterwards in child classes

        }


        public virtual int id()
        {
            return id_Renamed;
          
        }

        public virtual int Id
        {
            set
            {
                this.id_Renamed = value;
            }
        }

        public virtual int value()
        {
            return value_Renamed;
        }

        public virtual int Value
        {
            set
            {
                if (value == 0)
                {
                    this.setValue();
                }
                else
                {
                    this.value_Renamed = value;
                }
            }
        }

        public virtual void setValue()
        {
            // empty method to be overridden by children
            this.value_Renamed = 0;
        }

        public virtual Image bitmap()
        {
            return bitmapImage;
            
        }

        public virtual Image setBitmap
        {
            set
            {
                this.bitmapImage = value;
                // lookup value, using the this.id in the view/activity
            }
        }

        public virtual int x()
        {
            return x_Renamed;
        }

        public virtual int X
        {
            set
            {
                this.x_Renamed = value;
            }
        }

        public virtual int y()
        {
            return y_Renamed;
        }

        public virtual int Y
        {
            set
            {
                this.y_Renamed = value;
            }
        }
        
        public virtual int width()
        {
            return (int) this.bitmapImage.Width;
        }

        public virtual int height()
        {
            return (int)this.bitmapImage.Height;
        }

        public virtual void draw(Canvas canvas)
        {
            double xs = 50;

            Canvas.SetLeft(bitmapImage, xs);
            
        }

        public virtual bool handleActionDown(int eventX, int eventY)
        {
            if (eventX >= (this.x_Renamed - this.bitmapImage.Width / 2) && (eventX <= (this.x_Renamed + this.bitmapImage.Width/ 2)))
            {
                if (eventY >= (this.y_Renamed - this.bitmapImage.Height / 2) && (eventY <= (this.y_Renamed + this.bitmapImage.Height / 2)))
                {
                    // bug touched
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }

}
