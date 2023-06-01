using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Solution
    {
        public static List<Ad> ReadDataFromJson(string jsonFilename)
        {
            var fileAsString = File.ReadAllText(jsonFilename);
            var data = JsonConvert.DeserializeObject<List<Ad>>(fileAsString);
            return data;
        }
        public static List<Ad> ReadDataFromCSV(string csvFilename, int rowsToSkip)
        {
            List<Ad> data = new List<Ad>();
            foreach (var row in File.ReadAllLines(csvFilename).Skip(rowsToSkip))
            {
                data.Add(new Ad(row));
            }
            return data;
        }
        public static double DistanceTo(double xCoordinate, double yCoordinate, double estateXCoordinate, double estateYCoordinate)
        {
            double xCoordinates = estateXCoordinate - xCoordinate;
            double yCoordinates = estateYCoordinate - yCoordinate;
            var result = Math.Sqrt(Math.Pow(xCoordinates, 2) + Math.Pow(yCoordinates, 2));
            return result;
        }
    }
}
