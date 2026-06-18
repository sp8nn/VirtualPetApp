using System;

namespace VirtualPetApp
{
    public class VirtualPet
    {
        public string Name { get; set; }
        public int Hunger { get; set; }
        public int Happiness { get; set; }
        public int Age { get; set; }
        public string Mood { get; set; }
        public string GrowthStage { get; set; }
        public DateTime LastUpdated { get; set; }

        public VirtualPet(string name)
        {
            Name = name;
            Hunger = 50;
            Happiness = 50;
            Age = 0;
            Mood = "Okay";
            GrowthStage = "Baby";
            LastUpdated = DateTime.Now;
            UpdateMood();
        }

        public void Feed()
        {
            Hunger -= 20;

            if (Hunger < 0)
                Hunger = 0;

            Happiness += 5;

            if (Happiness > 100)
                Happiness = 100;

            UpdateMood();
        }

        public void Play()
        {
            Happiness += 15;
            Hunger += 10;

            if (Happiness > 100)
                Happiness = 100;

            if (Hunger > 100)
                Hunger = 100;

            UpdateMood();
        }

        public void Rest()
        {
            Happiness += 10;
            Hunger += 5;

            if (Happiness > 100)
                Happiness = 100;

            if (Hunger > 100)
                Hunger = 100;

            UpdateMood();
        }

        public void PassTime()
        {
            Hunger += 10;
            Happiness -= 5;
            Age++;

            if (Hunger > 100)
                Hunger = 100;

            if (Happiness < 0)
                Happiness = 0;

            UpdateGrowthStage();
            UpdateMood();
        }

        public void UpdateGrowthStage()
        {
            if (Age < 3)
                GrowthStage = "Baby";
            else if (Age < 6)
                GrowthStage = "Teen";
            else
                GrowthStage = "Adult";
        }

        public void UpdateMood()
        {
            if (Hunger >= 80)
                Mood = "Hungry";
            else if (Happiness >= 75)
                Mood = "Happy";
            else if (Happiness <= 25)
                Mood = "Sad";
            else
                Mood = "Okay";
        }

        public string GetImage()
        {
            if (Mood == "Hungry")
                return "(>_<)  Hungry Pet";

            if (Mood == "Happy")
                return "(^_^)  Happy Pet";

            if (Mood == "Sad")
                return "(T_T)  Sad Pet";

            return "(o_o)  Okay Pet";
        }
    }
}