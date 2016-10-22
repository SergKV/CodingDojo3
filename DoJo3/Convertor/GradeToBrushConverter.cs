using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;


namespace DoJo3.Convertor
{
    public class GradeToBrushConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parametr, System.Globalization.CultureInfo culture)
        {
            int temp = (int)value;

            if (temp >= 20) { return new SolidColorBrush(Colors.Green); }
            else if (temp >= 10) { return new SolidColorBrush(Colors.Yellow); }
            else { return new SolidColorBrush(Colors.Red); }
        }

        public object ConvertBack(object value, Type targetType, object parametr, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
