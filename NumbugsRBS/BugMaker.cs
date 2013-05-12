using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbugsRBS
{
    public class BugMaker // this class deals with the logic behind combining two bugs and
    {
        // an operand to create a new bug

        private int value1;
        private int value2;
        private int @operator; // 0 = +, 1 = -, 2 = *, 3 = /

        public BugMaker()
        {

        }

        public BugMaker(Bug bug1, Bug bug2, int @operator)
        {
            this.value1 = bug1.value();
            this.value2 = bug2.value();
            this.@operator = @operator;
        }

        public virtual Bug Value1
        {
            set
            {
                this.value1 = value.value();
            }
        }

        public virtual Bug Value2
        {
            set
            {
                this.value2 = value.value();
            }
        }

        public virtual int Operator
        {
            set
            {
                this.@operator = value;
            }
        }

        public virtual Bug makeBug(int x, int y) // provide coordinates to place new bug
        {
            int value;

            switch (this.@operator)
            {
                case 0:
                    value = this.value1 + this.value2;
                    break;
                case 1:
                    value = this.value1 - this.value2;
                    break;
                case 2:
                    value = this.value1 * this.value2;
                    break;
                case 3: // need to make sure this is possible beforehand
                    value = this.value1 / this.value2;
                    break;
                default:
                    value = 0;
                    break;
            }

            if (value < 6)
            {
                return new Ant(value, x, y); //edit bitmap assignment
            }
            else if (value < 11)
            {
                return new Moth(value, x, y);
            }
            else if (value < 21)
            {
                return new Roach(value, x, y);
            }
            else if (value < 51)
            {
                return new Ladybird(value, x, y);
            }
            else
            {
                return new Wasp(value, x, y);
            }
        }

    }


}
