using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbugsRBS
{
    public class Player
    {

        private string name_Renamed;
        private int age_Renamed;
        private int difficulty_Renamed; // 1=KS1, 2=KS2, 3=KS3easy, 4=KS3normal, 5=KS3hard
        private int gamesPlayed_Renamed;
        //private BugSelection bugSelection;

        public Player()
        {

        }

        public Player(string name, int age, int difficulty, int gamesPlayed)
        {
            this.name_Renamed = name;
            this.age_Renamed = age;
            this.difficulty_Renamed = difficulty;
            this.gamesPlayed_Renamed = gamesPlayed;
            //this.bugSelection = new BugSelection();
        }

        public virtual string name()
        {
            return this.name_Renamed;
        }

        public virtual int age()
        {
            return this.age_Renamed;
        }

        public virtual int difficulty()
        {
            return this.difficulty_Renamed;
        }

        public virtual int gamesPlayed()
        {
            return this.gamesPlayed_Renamed;
        }
        /*
        public BugSelection bugSelection(){
            return this.bugSelection;
        }*/

        public virtual int Age
        {
            set
            {
                this.age_Renamed = value;
            }
        }


    }

}
