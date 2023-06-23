using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace MathPractiseApplication.Converters
{
    public class IndexToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int selectedIndex = (int)value;
            RadioButton radioButton = (RadioButton)parameter;

            // Находим индекс radiobutton в itemscontroll
            ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(radioButton);
            int index = itemsControl.ItemContainerGenerator.IndexFromContainer(radioButton);

            
            return selectedIndex == index;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            bool isChecked = (bool)value;
            RadioButton radioButton = (RadioButton)parameter;

            if (isChecked)
            {
                // Если radiobutton isChecked == true, находим его в itemscontroll
                ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(radioButton);
                return itemsControl.ItemContainerGenerator.IndexFromContainer(radioButton);
            }
            else
            {
                // Если не выбран то ничего не меняем
                return Binding.DoNothing;
            }
        }
    }
}
