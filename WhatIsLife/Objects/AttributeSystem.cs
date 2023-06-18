namespace WhatIsLife.Objects
{
    public class AttributeSystem
    {
        public int Hunger { get; set; }

        public void Reset()
        {
            Hunger = 100;
        }
    }
}
