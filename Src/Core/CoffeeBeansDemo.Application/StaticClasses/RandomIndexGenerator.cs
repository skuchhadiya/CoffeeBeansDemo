namespace CoffeeBeansDemo.Application.StaticClasses
{
    public static class RandomIndexGenerator
    {
        //Assuming that index in CoffeeBeans table have always index in sequnce. 
        //If anyone delete the item then they need to adjust all indexes 
        //Deleting BOTD item then they need make new BOTD item
        public static bool TryGetRandomIndex(Random r,int minValue, int maxValue, int currentIndex, int[] possibleNewIndexValues, out int? randomNumber)
        {
            int rInt = r.Next(minValue, maxValue);
            if (possibleNewIndexValues.Contains(rInt))
            {
                randomNumber = rInt;
                return true;
            }
            else
            {
                if (rInt == currentIndex)
                {
                    if (rInt < (maxValue - 2))
                    {
                        randomNumber = rInt+1;
                        return true;
                    }
                    else if (rInt == maxValue - 1)
                    {
                        randomNumber = rInt - 1;
                        return true;
                    }
                }
            }
            randomNumber = null;
            return false; 
        }
    }
}
