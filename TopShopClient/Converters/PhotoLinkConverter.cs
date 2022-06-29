using System.Globalization;
using TopShopClient.Services;

namespace TopShopClient.Converters
{
    public class PhotoLinkConverter : IValueConverter
    {
        private BaseService _baseService = new BaseService();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return _baseService.domainUrl + value.ToString();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
