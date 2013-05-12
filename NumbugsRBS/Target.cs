using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbugsRBS
{
    public class Target
    {

        private int[] values_Renamed = new int[6];
        private int[] targets_Renamed = new int[10];
        internal int index;

        public Target(int[] values, int difficulty) // array of value of the 6 selected bugs and user's difficulty
        {
            this.values_Renamed = values;
            this.index = 0;
            if (difficulty > 2) // difficulty > KS2
            {
                this.setTargets();
            }
            else
            {
                this.Targets = difficulty;
            }
        }

        public virtual int[] values()
        {
            return this.values();
        }

        public virtual int[] targets()
        {
            return this.targets();
        }

        private void setTargets()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                this.targets_Renamed[i] = rand.Next(899) + 101; // [101,999]
            }
        }

        private int Targets
        {
            set
            {
                Random rand = new Random();
                int vI; // index of this.values array
                int tI; // index of this.targets array
                int valNum; // number of values to be operated on
                int operNum; // number indicating operator to use

                for (tI = 0; tI < 10; tI++) // produce 10 possible targets
                {

                    int[] valueChoice = this.values_Renamed;
                    vI = rand.Next(valueChoice.Length); // randomly choose a value from the array
                    this.targets_Renamed[tI] = valueChoice[vI];
                    valueChoice = editArray(valueChoice, vI); // take value out of the array

                    for (valNum = rand.Next(3) + 4; valNum > 0; valNum--) // at least 4 numbers involved.. cycle through number of values to be operated on
                    {

                        switch (value)
                        {
                            case 1:
                                operNum = rand.Next(2);
                                goto default;
                            default:
                                operNum = rand.Next(4);
                                break;
                        }
                        vI = rand.Next(valueChoice.Length);
                        bool loop = true;

                        while (loop) // so it repeats if integer division not possible
                        {
                            switch (operNum)
                            {
                                case 1:
                                    this.targets_Renamed[tI] = this.targets_Renamed[tI] + valueChoice[vI];
                                    loop = false;
                                    break;
                                case 2:
                                    this.targets_Renamed[tI] = this.targets_Renamed[tI] - valueChoice[vI];
                                    loop = false;
                                    break;
                                case 3:
                                    if (this.targets_Renamed[tI] >= valueChoice[vI])
                                    {
                                        this.targets_Renamed[tI] = this.targets_Renamed[tI] - valueChoice[vI];
                                        loop = false;
                                        break;
                                    }
                                    else
                                    {
                                        this.targets_Renamed[tI] = valueChoice[vI] - this.targets_Renamed[tI];
                                        loop = false;
                                        break;
                                    }
                                case 4:
                                    if (this.targets_Renamed[tI] % valueChoice[vI] == 0) // check int division possible
                                    {
                                        this.targets_Renamed[tI] = this.targets_Renamed[tI] / valueChoice[vI];
                                        loop = false;
                                        break;
                                    }
                                    else // must use another operator
                                    {
                                        operNum = rand.Next(3);
                                        break;
                                    }
                            }
                        }
                        valueChoice = editArray(valueChoice, vI);
                    }

                }
            }
        }

        private int[] editArray(int[] array, int index)
        {
            int[] newArray = new int[array.Length - 1];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = array[i];
            }
            for (int i = index; i < array.Length - 1; i++)
            {
                newArray[i] = array[i + 1];
            }
            return newArray;
        }

        public virtual int nextTarget()
        {
            int target = this.targets_Renamed[this.index];
            this.index++;
            return target;
        }

        public virtual void back() // allows user to return to previous target if nextTarget it then called
        {
            this.index--; // needed because nextTarget increases index
        }

    }

}
