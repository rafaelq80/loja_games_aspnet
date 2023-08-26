using Newtonsoft.Json;
using System.Globalization;

namespace loja_games.Util
{
    public class DateOnlyJsonConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
    {
        public DateOnlyJsonConverter() 
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
