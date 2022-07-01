using System.Globalization;

namespace TopShopClient.Converters
{
    public class ProductTitleSliceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value.ToString().Length >= 35)
            {
                return value.ToString().Substring(0, 34);
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
    }
}
