using System.Windows;
using System.Windows.Controls;

namespace DemonBinding.Wpf.CustomControls
{
    public class ButtonCounter : Button
    {
        public static readonly DependencyProperty ButtonCounterProperty = 
            DependencyProperty.Register(nameof(Counter), typeof(int), typeof(ButtonCounter));


        public int Counter
        {
            get
            {
                return (int)GetValue(ButtonCounterProperty);
            }
            set
            {
                SetValue(ButtonCounterProperty, value); 
            }
        }

        protected override void OnClick()
        {
            base.OnClick();
            Counter++; 
        }
    }
}
