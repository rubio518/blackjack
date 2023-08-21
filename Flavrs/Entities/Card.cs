using System;
namespace Flavrs.Entities
{
	public class Card
	{
		public Card()
		{
		}
        
        public string? suit { get; set; }
        public int number { get; set; }

		public string toString()
		{
			string numberString = number.ToString();
			if (number == 11)
			{
				numberString = "J";
			}
            if (number == 12)
            {
                numberString = "Q";
            }
            if (number == 13)
            {
                numberString = "K";
            }
            if(number == 1)
            {
                numberString = "A";
            }
            return suit + " " + numberString;
		}
    }
}

