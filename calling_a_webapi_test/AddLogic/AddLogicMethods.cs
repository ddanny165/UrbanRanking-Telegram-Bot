using System.Text.RegularExpressions;

namespace UrbanRankingTelegBot.AddLogic
{
    public class AddLogicMethods
    {
        //formatting numbers in our string (millions and thousands)
        public static string NumberFormatting (string input)
        { 
            string MillionsFormattedStr = Regex.Replace(input,
                                 @"(?<n1>\d{1,3})(?<n2>\d{3})(?<n3>\d{3})",
                                "${n1}.${n2}.${n3}");

            return Regex.Replace(MillionsFormattedStr,  
                                 @"(?<n1>\d{3})(?<n2>\d{3})", 
                                "${n1}.${n2}"); 
        }

        //handling exception bc of invalid values for operation with json (serial/deserial)
        public static string JsonSerializationValidation (string input)
        {
            string pattern = @"\?+";

            if (Regex.IsMatch(input, pattern))
            {
                input = "no_city";
            }
            return input;
        }

        public static bool CheckingIfACity (string input)
        {
            bool IsACity;

            switch (input.ToLower())
            {
                case "aarhus":
                    IsACity = true;
                    break;
                case "almaty":
                    IsACity = true;
                    break;
                case "amsterdam":
                    IsACity = true;
                    break;
                case "andorra":
                    IsACity = true;
                    break;
                case "athens":
                    IsACity = true;
                    break;
                case "atlanta":
                    IsACity = true;
                    break;
                case "auckland":
                    IsACity = true;
                    break;
                case "austin":
                    IsACity = true;
                    break;
                case "baku":
                    IsACity = true;
                    break;
                case "baltimore":
                    IsACity = true;
                    break;
                case "bangkok":
                    IsACity = true;
                    break;
                case "barcelona":
                    IsACity = true;
                    break;
                case "beijing":
                    IsACity = true;
                    break;
                case "beirut":
                    IsACity = true;
                    break;
                case "belgrade":
                    IsACity = true;
                    break;
                case "bilbao":
                    IsACity = true;
                    break;
                case "bergen":
                    IsACity = true;
                    break;
                case "anchorage":
                    IsACity = true;
                    break;
                case "bogota":
                    IsACity = true;
                    break;
                case "bologna":
                    IsACity = true;
                    break;
                case "bordeaux":
                    IsACity = true;
                    break;
                case "boston":
                    IsACity = true;
                    break;
                case "bratislava":
                    IsACity = true;
                    break;
                case "brisbane":
                    IsACity = true;
                    break;
                case "brno":
                    IsACity = true;
                    break;
                case "calgary":
                    IsACity = true;
                    break;
                case "bucharest":
                    IsACity = true;
                    break;
                case "budapest":
                    IsACity = true;
                    break;
                case "cairo":
                    IsACity = true;
                    break;
                case "cardiff":
                    IsACity = true;
                    break;
                case "charlotte":
                    IsACity = true;
                    break;
                case "chicago":
                    IsACity = true;
                    break;
                case "chisinau":
                    IsACity = true;
                    break;
                case "cincinnati":
                    IsACity = true;
                    break;
                case "cleveland":
                    IsACity = true;
                    break;
                case "cologne":
                    IsACity = true;
                    break;
                case "columbus":
                    IsACity = true;
                    break;
                case "chennai":
                    IsACity = true;
                    break;
                case "dallas":
                    IsACity = true;
                    break;
                case "delhi":
                    IsACity = true;
                    break;
                case "denver":
                    IsACity = true;
                    break;
                case "detroit":
                    IsACity = true;
                    break;
                case "florianopolis":
                    IsACity = true;
                    break;
                case "dubai":
                    IsACity = true;
                    break;
                case "cork":
                    IsACity = true;
                    break;
                case "dusseldorf":
                    IsACity = true;
                    break;
                case "edinburgh":
                    IsACity = true;
                    break;
                case "eindhoven":
                    IsACity = true;
                    break;
                case "frankfurt":
                    IsACity = true;
                    break;
                case "gdansk":
                    IsACity = true;
                    break;
                case "florence":
                    IsACity = true;
                    break;
                case "doha":
                    IsACity = true;
                    break;
                case "grenoble":
                    IsACity = true;
                    break;
                case "gothenburg":
                    IsACity = true;
                    break;
                case "guadalajara":
                    IsACity = true;
                    break;
                case "kingston":
                    IsACity = true;
                    break;
                case "hannover":
                    IsACity = true;
                    break;
                case "havana":
                    IsACity = true;
                    break;
                case "helsinki":
                    IsACity = true;
                    break;
                case "honolulu":
                    IsACity = true;
                    break;
                case "houston":
                    IsACity = true;
                    break;
                case "indianapolis":
                    IsACity = true;
                    break;
                case "innsbruck":
                    IsACity = true;
                    break;
                case "istanbul":
                    IsACity = true;
                    break;
                case "jakarta":
                    IsACity = true;
                    break;
                case "johannesburg":
                    IsACity = true;
                    break;
                case "fukuoka":
                    IsACity = true;
                    break;
                case "kiev":
                    IsACity = true;
                    break;
                case "kyiv":
                    IsACity = true;
                    break;
                case "krakow":
                    IsACity = true;
                    break;
                case "lima":
                    IsACity = true;
                    break;
                case "madison":
                    IsACity = true;
                    break;
                case "nantes":
                    IsACity = true;
                    break;
                case "lille":
                    IsACity = true;
                    break;
                case "nicosia":
                    IsACity = true;
                    break;
                case "liverpool":
                    IsACity = true;
                    break;
                case "ljubljana":
                    IsACity = true;
                    break;
                case "london":
                    IsACity = true;
                    break;
                case "lviv":
                    IsACity = true;
                    break;
                case "turku":
                    IsACity = true;
                    break;
                case "madrid":
                    IsACity = true;
                    break;
                case "malaga":
                    IsACity = true;
                    break;
                case "malmo":
                    IsACity = true;
                    break;
                case "manchester":
                    IsACity = true;
                    break;
                case "montevideo":
                    IsACity = true;
                    break;
                case "marseille":
                    IsACity = true;
                    break;
                case "medellin":
                    IsACity = true;
                    break;
                case "melbourne":
                    IsACity = true;
                    break;
                case "miami":
                    IsACity = true;
                    break;
                case "milan":
                    IsACity = true;
                    break;
                case "minsk":
                    IsACity = true;
                    break;
                case "montreal":
                    IsACity = true;
                    break;
                case "moscow":
                    IsACity = true;
                    break;
                case "mumbai":
                    IsACity = true;
                    break;
                case "munich":
                    IsACity = true;
                    break;
                case "nairobi":
                    IsACity = true;
                    break;
                case "naples":
                    IsACity = true;
                    break;
                case "nashville":
                    IsACity = true;
                    break;
                case "orlando":
                    IsACity = true;
                    break;
                case "casablanca":
                    IsACity = true;
                    break;
                case "oslo":
                    IsACity = true;
                    break;
                case "ottawa":
                    IsACity = true;
                    break;
                case "panama":
                    IsACity = true;
                    break;
                case "paris":
                    IsACity = true;
                    break;
                case "philadelphia":
                    IsACity = true;
                    break;
                case "pittsburgh":
                    IsACity = true;
                    break;
                case "porto":
                    IsACity = true;
                    break;
                case "tehran":
                    IsACity = true;
                    break;
                case "quebec":
                    IsACity = true;
                    break;
                case "riga":
                    IsACity = true;
                    break;
                case "rome":
                    IsACity = true;
                    break;
                case "rotterdam":
                    IsACity = true;
                    break;
                case "sarajevo":
                    IsACity = true;
                    break;
                case "seattle":
                    IsACity = true;
                    break;
                case "seoul":
                    IsACity = true;
                    break;
                case "santiago":
                    IsACity = true;
                    break;
                case "shanghai":
                    IsACity = true;
                    break;
                case "reykjavik":
                    IsACity = true;
                    break;
                case "sofia":
                    IsACity = true;
                    break;
                case "uppsala":
                    IsACity = true;
                    break;
                case "taipei":
                    IsACity = true;
                    break;
                case "sydney":
                    IsACity = true;
                    break;
                case "tallinn":
                    IsACity = true;
                    break;
                case "thessaloniki":
                    IsACity = true;
                    break;
                case "tokyo":
                    IsACity = true;
                    break;
                case "toronto":
                    IsACity = true;
                    break;
                case "tunis":
                    IsACity = true;
                    break;
                case "turin":
                    IsACity = true;
                    break;
                case "utrecht":
                    IsACity = true;
                    break;
                case "valencia":
                    IsACity = true;
                    break;
                case "vancouver":
                    IsACity = true;
                    break;
                case "vienna":
                    IsACity = true;
                    break;
                case "vilnius":
                    IsACity = true;
                    break;
                case "skopje":
                    IsACity = true;
                    break;
                case "wellington":
                    IsACity = true;
                    break;
                case "winnipeg":
                    IsACity = true;
                    break;
                case "perth":
                    IsACity = true;
                    break;
                case "valletta":
                    IsACity = true;
                    break;
                case "zagreb":
                    IsACity = true;
                    break;
                case "zurich":
                    IsACity = true;
                    break;
                default:
                    IsACity = false;
                    break;
            }

            return IsACity;
        }

        public static bool CheckingIfAvailableCategory (string input)
        {
            bool IsACategory;

            switch (input.ToLower())
            {
                case "businessfreedom":
                    IsACategory = true;
                    break;
                case "costofliving":
                    IsACategory = true;
                    break;
                case "housing":
                    IsACategory = true;
                    break;
                case "leisure&culture":
                    IsACategory = true;
                    break;
                case "safety":
                    IsACategory = true;
                    break;
                case "taxation":
                    IsACategory = true;
                    break;
                case "travelconnectivity":
                    IsACategory = true;
                    break;
                default:
                    IsACategory = false;
                    break;
            }

            return IsACategory;
        }

        public static bool CheckingIfAValidLetter (string input)
        {
            bool IsALetter;

            switch (input.ToLower())
            {
                case "a":
                    IsALetter = true;
                    break;

                case "b":
                    IsALetter = true;
                    break;

                case "c":
                    IsALetter = true;
                    break;

                case "d":
                    IsALetter = true;
                    break;

                case "e":
                    IsALetter = true;
                    break;

                case "f":
                    IsALetter = true;
                    break;

                case "g":
                    IsALetter = true;
                    break;

                case "h":
                    IsALetter = true;
                    break;

                case "i":
                    IsALetter = true;
                    break;

                case "j":
                    IsALetter = true;
                    break;

                case "k":
                    IsALetter = true;
                    break;

                case "l":
                    IsALetter = true;
                    break;

                case "m":
                    IsALetter = true;
                    break;

                case "n":
                    IsALetter = true;
                    break;

                case "o":
                    IsALetter = true;
                    break;

                case "p":
                    IsALetter = true;
                    break;

                case "q":
                    IsALetter = true;
                    break;

                case "r":
                    IsALetter = true;
                    break;

                case "s":
                    IsALetter = true;
                    break;

                case "t":
                    IsALetter = true;
                    break;

                case "u":
                    IsALetter = true;
                    break;

                case "v":
                    IsALetter = true;
                    break;

                case "w":
                    IsALetter = true;
                    break;

                case "x":
                    IsALetter = true;
                    break;

                case "y":
                    IsALetter = true;
                    break;

                case "z":
                    IsALetter = true;
                    break;
                default:
                    IsALetter = false;
                    break;
            }

            return IsALetter;
        }

        public static string CapitalizingFirstLetter (char[] array)
        {
            char[] reformattedStr = array;
            char replace = char.ToUpper(reformattedStr[0]);
            reformattedStr[0] = replace;
            string CityName = new string(reformattedStr);

            return CityName;
        }

        public static string RemovingSpacesFromString (string input)
        {
            Regex regex = new Regex(@"\s+");
            string ReplaceTarget = "";

            string FormattedInput = regex.Replace(input, ReplaceTarget);
            
            return FormattedInput;
        }

        public static string GettingRandomCity(int num)
        {
            string cityName;

            switch (num)
            {
                case 1:
                    cityName = "aarhus";
                    break;
                case 2:
                    cityName = "almaty";
                    break;
                case 3:
                    cityName = "amsterdam";
                    break;
                case 4:
                    cityName = "andorra";
                    break;
                case 5:
                    cityName = "athens";
                    break;
                case 6:
                    cityName = "atlanta";
                    break;
                case 7:
                    cityName = "auckland";
                    break;
                case 8:
                    cityName = "austin";
                    break;
                case 9:
                    cityName = "baku";
                    break;
                case 10:
                    cityName = "anchorage";
                    break;
                case 11:
                    cityName = "baltimore";
                    break;
                case 12:
                    cityName = "bangkok";
                    break;
                case 13:
                    cityName = "barcelona";
                    break;
                case 14:
                    cityName = "beijing";
                    break;
                case 15:
                    cityName = "beirut";
                    break;
                case 16:
                    cityName = "belgrade";
                    break;
                case 17:
                    cityName = "bilbao";
                    break;
                case 18:
                    cityName = "bergen";
                    break;
                case 19:
                    cityName = "casablanca";
                    break;
                case 20:
                    cityName = "bogota";
                    break;
                case 21:
                    cityName = "bologna";
                    break;
                case 22:
                    cityName = "bordeaux";
                    break;
                case 23:
                    cityName = "boston";
                    break;
                case 24:
                    cityName = "bratislava";
                    break;
                case 25:
                    cityName = "brisbane";
                    break;
                case 26:
                    cityName = "brno";
                    break;
                case 27:
                    cityName = "calgary";
                    break;
                case 28:
                    cityName = "bucharest";
                    break;
                case 29:
                    cityName = "budapest";
                    break;
                case 30:
                    cityName = "cairo";
                    break;
                case 31:
                    cityName = "cardiff";
                    break;
                case 32:
                    cityName = "charlotte";
                    break;
                case 33:
                    cityName = "chicago";
                    break;
                case 34:
                    cityName = "chisinau";
                    break;
                case 35:
                    cityName = "cincinnati";
                    break;
                case 36:
                    cityName = "cleveland";
                    break;
                case 37:
                    cityName = "cologne";
                    break;
                case 38:
                    cityName = "columbus";
                    break;
                case 39:
                    cityName = "cork";
                    break;
                case 40:
                    cityName = "dallas";
                    break;
                case 41:
                    cityName = "delhi";
                    break;
                case 42:
                    cityName = "denver";
                    break;
                case 43:
                    cityName = "detroit";
                    break;
                case 44:
                    cityName = "doha";
                    break;
                case 45:
                    cityName = "dubai";
                    break;
                case 46:
                    cityName = "florence";
                    break;
                case 47:
                    cityName = "dusseldorf";
                    break;
                case 48:
                    cityName = "edinburgh";
                    break;
                case 49:
                    cityName = "eindhoven";
                    break;
                case 50:
                    cityName = "frankfurt";
                    break;
                case 51:
                    cityName = "gdansk";
                    break;
                case 52:
                    cityName = "florianopolis";
                    break;
                case 53:
                    cityName = "zurich";
                    break;
                case 54:
                    cityName = "zagreb";
                    break;
                case 55:
                    cityName = "gothenburg";
                    break;
                case 56:
                    cityName = "guadalajara";
                    break;
                case 57:
                    cityName = "valletta";
                    break;
                case 58:
                    cityName = "hannover";
                    break;
                case 59:
                    cityName = "havana";
                    break;
                case 60:
                    cityName = "helsinki";
                    break;
                case 61:
                    cityName = "honolulu";
                    break;
                case 62:
                    cityName = "houston";
                    break;
                case 63:
                    cityName = "indianapolis";
                    break;
                case 64:
                    cityName = "innsbruck";
                    break;
                case 65:
                    cityName = "istanbul";
                    break;
                case 66:
                    cityName = "jakarta";
                    break;
                case 67:
                    cityName = "johannesburg";
                    break;
                case 68:
                    cityName = "chennai";
                    break;
                case 69:
                    cityName = "fukuoka";
                    break;
                case 70:
                    cityName = "krakow";
                    break;
                case 71:
                    cityName = "grenoble";
                    break;
                case 72:
                    cityName = "kingston";
                    break;
                case 73:
                    cityName = "lima";
                    break;
                case 74:
                    cityName = "lille";
                    break;
                case 75:
                    cityName = "madison";
                    break;
                case 76:
                    cityName = "liverpool";
                    break;
                case 77:
                    cityName = "ljubljana";
                    break;
                case 78:
                    cityName = "london";
                    break;
                case 79:
                    cityName = "lviv";
                    break;
                case 80:
                    cityName = "montevideo";
                    break;
                case 81:
                    cityName = "madrid";
                    break;
                case 82:
                    cityName = "malaga";
                    break;
                case 83:
                    cityName = "malmo";
                    break;
                case 84:
                    cityName = "manchester";
                    break;
                case 85:
                    cityName = "nicosia";
                    break;
                case 86:
                    cityName = "marseille";
                    break;
                case 87:
                    cityName = "medellin";
                    break;
                case 88:
                    cityName = "melbourne";
                    break;
                case 89:
                    cityName = "miami";
                    break;
                case 90:
                    cityName = "milan";
                    break;
                case 91:
                    cityName = "minsk";
                    break;
                case 92:
                    cityName = "montreal";
                    break;
                case 93:
                    cityName = "moscow";
                    break;
                case 94:
                    cityName = "mumbai";
                    break;
                case 95:
                    cityName = "munich";
                    break;
                case 96:
                    cityName = "nairobi";
                    break;
                case 97:
                    cityName = "naples";
                    break;
                case 98:
                    cityName = "nashville";
                    break;
                case 99:
                    cityName = "orlando";
                    break;
                case 100:
                    cityName = "perth";
                    break;
                case 101:
                    cityName = "oslo";
                    break;
                case 102:
                    cityName = "ottawa";
                    break;
                case 103:
                    cityName = "panama";
                    break;
                case 104:
                    cityName = "paris";
                    break;
                case 105:
                    cityName = "philadelphia";
                    break;
                case 106:
                    cityName = "pittsburgh";
                    break;
                case 107:
                    cityName = "porto";
                    break;
                case 108:
                    cityName = "reykjavik";
                    break;
                case 109:
                    cityName = "quebec";
                    break;
                case 110:
                    cityName = "riga";
                    break;
                case 111:
                    cityName = "rome";
                    break;
                case 112:
                    cityName = "rotterdam";
                    break;
                case 113:
                    cityName = "sarajevo";
                    break;
                case 114:
                    cityName = "seattle";
                    break;
                case 115:
                    cityName = "seoul";
                    break;
                case 116:
                    cityName = "santiago";
                    break;
                case 117:
                    cityName = "shanghai";
                    break;
                case 118:
                    cityName = "skopje";
                    break;
                case 119:
                    cityName = "sofia";
                    break;
                case 120:
                    cityName = "taipei";
                    break;
                case 121:
                    cityName = "tehran";
                    break;
                case 122:
                    cityName = "sydney";
                    break;
                case 123:
                    cityName = "tallinn";
                    break;
                case 124:
                    cityName = "thessaloniki";
                    break;
                case 125:
                    cityName = "tokyo";
                    break;
                case 126:
                    cityName = "toronto";
                    break;
                case 127:
                    cityName = "tunis";
                    break;
                case 128:
                    cityName = "turin";
                    break;
                case 129:
                    cityName = "utrecht";
                    break;
                case 130:
                    cityName = "valencia";
                    break;
                case 131:
                    cityName = "vancouver";
                    break;
                case 132:
                    cityName = "vienna";
                    break;
                case 133:
                    cityName = "vilnius";
                    break;
                case 134:
                    cityName = "turku";
                    break;
                case 135:
                    cityName = "wellington";
                    break;
                case 136:
                    cityName = "winnipeg";
                    break;
                case 137:
                    cityName = "uppsala";
                    break;
                default:
                    cityName = "zurich";
                    break;
            }
            return cityName;
        }
    }
}
