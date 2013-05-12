using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NumbugsRBS
{

    public class BugSelection
    {

        private List<Bug> bugList = new List<Bug>();
        private int max_Renamed;
        private int number = 0;

        public BugSelection()
        {

        }

        public BugSelection(int max)
        {
            this.max_Renamed = max;
        }

        public virtual void add(Bug bug)
        {
            /*int right = v.getRight();
            int distance = right/(this.max+1);
            bug.setX((distance) * (number+1)); // so first is 1/7, second is 2/7 if max = 6
            bug.setY(y);*/
            this.bugList.Add(bug);
            this.number++;
        }

        // introduce getX, getY methods so initialise bugs with coordinates. REECE LOOK AT THIS

        public virtual void remove(int index)
        {
            this.bugList.RemoveAt(index);
            this.number--;
        }

        public virtual int Max
        {
            set
            {
                this.max_Renamed = value;
            }
        }

        public virtual int max()
        {
            return this.max_Renamed;
        }

        public virtual int size()
        {
            return this.bugList.Count;
        }

        public virtual Bug bugAt(int index)
        {
            return this.bugList[index];
        }

        public virtual bool Full
        {
            get
            {
                if (this.bugList.Count >= this.max_Renamed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual int[] intArray()
        {
            int bugListSize = this.bugList.Count;
            int[] array = new int[bugListSize];
            for (int i = 0; i < bugListSize; i++)
            {
                array[i] = this.bugList[i].value();
            }
            return array;
        }

        public virtual Bug[] bugArray()
        {
            int bugListSize = this.bugList.Count;
            Bug[] array = new Bug[bugListSize];
            for (int i = 0; i < bugListSize; i++)
            {
                array[i] = this.bugList[i];
            }
            return array;
        }

        public virtual void draw(Canvas canvas)
        {
            int bugListSize = this.bugList.Count;
            for (int i = 0; i < bugListSize; i++)
            {
                this.bugList[i].draw(canvas);
            }
        }

        public virtual int handleActionDown(int eventX, int eventY)
        {
            int bugListSize = this.bugList.Count;
            for (int i = 0; i < bugListSize; i++)
            {
                if (this.bugList[i].handleActionDown(eventX, eventY))
                {
                    return i;
                }
            }
            return -1;

        }

    }


}
