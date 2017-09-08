using System;

namespace DojoDachi
{
    public class DachiPet
    {
        public int fullness = 20;
        public int happiness = 20;
        public int meals = 3;
        public int energy = 50;
        
        public DachiPet(){
        }
        public void Feed()
        {
            Random rand = new Random();
            if (rand.Next(1,5) == 1)
            {
                meals -= 1;
            } 
            else
            {
                meals -= 1;
                fullness += rand.Next(5, 11);
            }    
        }
        public void Play()
        {
            Random rand = new Random();
            if (rand.Next(1,5) == 1)
            {
                energy -=5;
            }
            else
            {
                energy -= 5;
                happiness += rand.Next(5, 11);
            }
        }
        public void Work()
        {
            Random rand = new Random();
            energy -= 5;
            meals += rand.Next(1,4);
        }
        public void Sleep()
        {
            energy += 15;
            fullness -= 5;
            happiness -= 5;
        }
    }
}