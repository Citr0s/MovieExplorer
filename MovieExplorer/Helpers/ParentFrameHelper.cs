using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace MovieExplorer.Helpers
{
    public class ParentFrameHelper
    {
        public static bool Navigate(DependencyObject child, Type sourcePageType, object parameter)
        {
            return FindParent<Frame>(child).Navigate(sourcePageType, parameter);
        }

        private static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null)
                return null;

            var parentType = parent as T;

            return parentType ?? FindParent<T>(parent);
        }
    }
}