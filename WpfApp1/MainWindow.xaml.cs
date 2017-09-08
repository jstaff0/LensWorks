using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        Lens lens1;

        
        public MainWindow()
        {
            InitializeComponent();

            Radius1Label.Content = Radius1Slider.Value;
            Radius2Label.Content = Radius2Slider.Value;
            ThicknessLabel.Content = ThicknessSlider.Value;
            DiameterLabel.Content = DiameterSlider.Value;
            lens1 = new Lens(1.5, Radius1Slider.Value, Radius2Slider.Value, ThicknessSlider.Value, DiameterSlider.Value);
            lens1.Draw(EditorCanvas);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            EditorCanvas.Children.Clear();
            lens1.Draw(EditorCanvas);
        }

        private void Radius1Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Radius1Label != null && Radius1Slider != null)
            {
                Radius1Label.Content = Radius1Slider.Value;
                lens1.radius1 = Radius1Slider.Value;
                refresh();
            }
            
        }

        private void Radius2Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Radius2Label != null && Radius2Slider != null)
            {
                Radius2Label.Content = Radius2Slider.Value;
                lens1.radius2 = Radius2Slider.Value;
                refresh();
            }
        }

        private void ThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ThicknessLabel != null && ThicknessSlider != null)
            {
                ThicknessLabel.Content = ThicknessSlider.Value;
                lens1.thickness = ThicknessSlider.Value;
                refresh();
            }
        }

        private void DiameterSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (DiameterLabel != null && DiameterSlider != null)
            {
                DiameterLabel.Content = DiameterSlider.Value;
                lens1.diameter = DiameterSlider.Value;
                refresh();
            }
        }
    }
}
