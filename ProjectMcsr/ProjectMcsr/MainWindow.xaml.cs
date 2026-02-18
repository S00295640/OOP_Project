using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectMcsr;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void BtnGuides_Click(object sender, RoutedEventArgs e)
    {
        DoubleAnimation slideOut = new DoubleAnimation()
        {
            To = -1000,
            Duration = TimeSpan.FromSeconds(0.5),
            AccelerationRatio = 0.5
        };
        TranslateTransform menuTransform = new TranslateTransform();
        MainMenuPanel.RenderTransform = menuTransform;
        menuTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);

        GuidePanel.Visibility = Visibility.Visible;
        TimeSpan duration = TimeSpan.FromSeconds(0.8);
        IEasingFunction ease = new CubicEase { EasingMode = EasingMode.EaseOut };
        
        DoubleAnimation slideIn = new DoubleAnimation(1000, 0, duration) { EasingFunction = ease };
        GuidesTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
    }

    private void BtnBack_Click(object sender, RoutedEventArgs e)
    {
        //routine pour close le panel
    }
}