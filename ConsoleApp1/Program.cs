using System.Globalization;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{ 
    class Program 
    { 
        static void Main(string[] args)
        {
            var Data = Solution.ReadDataFromJson("realestates.json");
            var Data1 = Solution.ReadDataFromCSV("realestates.csv", 1);
            // 6. Feladat
            var HousesOnFloorZero = Data.Where(c => c.Floors == 0).ToList();
            var AreaSum = HousesOnFloorZero.Sum(c => c.Area);
            var HousesCount = HousesOnFloorZero.Count();
            double Average = (double)AreaSum / (double)HousesCount;
            Console.WriteLine($"6. feladat: Földszinti ingatlanok átlagos alapterülete {Average:f2} m2");
            //8. Feladat
            double mesevarXCoordinates = 47.4164220114023;
            double mesevarYCoordinates = 19.066342425796986;
            Dictionary<int, double> distanceList = new Dictionary<int, double>();
            foreach (var i in Data)
            {
                var estateCoordinates = i.LatLong.Split(',');
                double estateX = double.Parse(estateCoordinates[0], CultureInfo.InvariantCulture);
                double estateY = double.Parse(estateCoordinates[1], CultureInfo.InvariantCulture);
                double distance = Solution.DistanceTo(mesevarXCoordinates, mesevarYCoordinates, estateX, estateY);
                if(i.FreeOfCharge)
                {
                    distanceList.Add(i.Id, distance);
                }
            }
            var minDistanceId = distanceList.MinBy(k => k.Value).Key;
            var closestEstate = Data.Where(c => c.Id == minDistanceId).FirstOrDefault();
            Console.WriteLine($"8. feladat: \nEladó neve: {closestEstate.Seller.Name}\nEladó telefonja: {closestEstate.Seller.Phone}\nAlapterület: {closestEstate.Area}\nSzobák száma: {closestEstate.Rooms}");
            Console.ReadKey();
        }
    }
}