using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
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
using ProjectMcsr.Models;

namespace ProjectMcsr;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MyResourceHandler MyResources;
    public MainWindow()
    {
        InitializeComponent();
        Initialize();
    }

    private void Initialize()
    {
        MyResources = new MyResourceHandler();
        MyResourcesList.ItemsSource = MyResources.Resources;
    }

    private void BtnGuides_Click(object sender, RoutedEventArgs e)
    {
        //Define animation
        DoubleAnimation slideOut = new DoubleAnimation()
        {
            From = 0,
            To = -1000,
            Duration = TimeSpan.FromSeconds(0.5),
            AccelerationRatio = 0.5
        };
        DoubleAnimation slideIn = new DoubleAnimation()
        {
            From = 4000,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.8),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut },
        };
        
        //Slide Out
        TranslateTransform menuTransform = new TranslateTransform();
        MainMenuPanel.RenderTransform = menuTransform;
        menuTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);
        
        //Slide In
        TranslateTransform guideTransform = new TranslateTransform();
        GuidePanel.RenderTransform = guideTransform;
        guideTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
    }

    private void BtnBack_Click(object sender, RoutedEventArgs e)
    {
        //Define animation
        DoubleAnimation slideOut = new DoubleAnimation()
        {
            From = 0,
            To = 4000,
            Duration = TimeSpan.FromSeconds(0.5),
            AccelerationRatio = 0.5
        };
        DoubleAnimation slideIn = new DoubleAnimation()
        {
            From = -1000,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.8),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut },
        };
        
        //Slide Out
        TranslateTransform backTransform = new TranslateTransform();
        GuidePanel.RenderTransform = backTransform;
        backTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);
        
        //Slide In
        TranslateTransform menuTransform = new TranslateTransform();
        MainMenuPanel.RenderTransform = menuTransform;
        menuTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
    }

    private void BtnFindResources_Click(object sender, RoutedEventArgs e)
    {
        //Define animation
        DoubleAnimation slideOut = new DoubleAnimation()
        {
            From = 0,
            To = -1000,
            Duration = TimeSpan.FromSeconds(0.5),
            AccelerationRatio = 0.5
        };
        DoubleAnimation slideIn = new DoubleAnimation()
        {
            From = 4000,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.8),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut },
        };
        
        //Slide Out
        TranslateTransform menuTransform = new TranslateTransform();
        MainMenuPanel.RenderTransform = menuTransform;
        menuTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);
        
        //Slide In
        TranslateTransform findTransform = new TranslateTransform();
        FindResourcesPanel.RenderTransform = findTransform;
        findTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
    }

    private void BtnPostResource_Click(object sender, RoutedEventArgs e)
    {
        //Define animation
        DoubleAnimation slideOut = new DoubleAnimation()
        {
            From = 0,
            To = -1000,
            Duration = TimeSpan.FromSeconds(0.5),
            AccelerationRatio = 0.5
        };
        DoubleAnimation slideIn = new DoubleAnimation()
        {
            From = 4000,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.8),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut },
        };
        
        //Slide Out
        TranslateTransform menuTransform = new TranslateTransform();
        MainMenuPanel.RenderTransform = menuTransform;
        menuTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);
        
        //Slide In
        TranslateTransform postTransform = new TranslateTransform();
        PostResourcePanel.RenderTransform = postTransform;
        postTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
    }

    private void BtnQuit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void BtnBackFromFind_Click(object sender, RoutedEventArgs e)
    {
        //Define animation
        DoubleAnimation slideOut = new DoubleAnimation()
        {
            From = 0,
            To = 4000,
            Duration = TimeSpan.FromSeconds(0.5),
            AccelerationRatio = 0.5
        };
        DoubleAnimation slideIn = new DoubleAnimation()
        {
            From = -1000,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.8),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut },
        };
        
        //Slide Out
        TranslateTransform backTransform = new TranslateTransform();
        FindResourcesPanel.RenderTransform = backTransform;
        backTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);
        
        //Slide In
        TranslateTransform menuTransform = new TranslateTransform();
        MainMenuPanel.RenderTransform = menuTransform;
        menuTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
    }

    private void BtnBackFromPost_Click(object sender, RoutedEventArgs e)
    {
        //Define animation
        DoubleAnimation slideOut = new DoubleAnimation()
        {
            From = 0,
            To = 4000,
            Duration = TimeSpan.FromSeconds(0.5),
            AccelerationRatio = 0.5
        };
        DoubleAnimation slideIn = new DoubleAnimation()
        {
            From = -1000,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.8),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut },
        };
        
        //Slide Out
        TranslateTransform backTransform = new TranslateTransform();
        PostResourcePanel.RenderTransform = backTransform;
        backTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);
        
        //Slide In
        TranslateTransform menuTransform = new TranslateTransform();
        MainMenuPanel.RenderTransform = menuTransform;
        menuTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
    }

    private void BtnAddResource_Click(object sender, RoutedEventArgs e)
    {
        //Define animation
        DoubleAnimation slideOut = new DoubleAnimation()
        {
            From = 0,
            To = -1000,
            Duration = TimeSpan.FromSeconds(0.5),
            AccelerationRatio = 0.5
        };
        DoubleAnimation slideIn = new DoubleAnimation()
        {
            From = 4000,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.8),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut },
        };
        
        //Slide Out
        TranslateTransform postTransform = new TranslateTransform();
        PostResourcePanel.RenderTransform = postTransform;
        postTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);
        
        //Slide In
        TranslateTransform createTransform = new TranslateTransform();
        CreateResourcePanel.RenderTransform = createTransform;
        createTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
    }

    private void BtnCancelCreate_Click(object sender, RoutedEventArgs e)
    {
        //Define animation
        DoubleAnimation slideOut = new DoubleAnimation()
        {
            From = 0,
            To = 4000,
            Duration = TimeSpan.FromSeconds(0.5),
            AccelerationRatio = 0.5
        };
        DoubleAnimation slideIn = new DoubleAnimation()
        {
            From = -1000,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.8),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut },
        };
        
        //Slide Out
        TranslateTransform backTransform = new TranslateTransform();
        CreateResourcePanel.RenderTransform = backTransform;
        backTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);
        
        //Slide In
        TranslateTransform postTransform = new TranslateTransform();
        PostResourcePanel.RenderTransform = postTransform;
        postTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
    }


    private void OnResourceAdded()
    {
        //Slide out
        
        //Define animation
        DoubleAnimation slideOut = new DoubleAnimation()
        {
            From = 0,
            To = -1000,
            Duration = TimeSpan.FromSeconds(0.5),
            AccelerationRatio = 0.5
        };
        DoubleAnimation slideIn = new DoubleAnimation()
        {
            From = -1000,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.8),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut },
        };
        
        //Slide Out
        TranslateTransform backTransform = new TranslateTransform();
        CreateResourcePanel.RenderTransform = backTransform;
        backTransform.BeginAnimation(TranslateTransform.XProperty, slideOut);
        
        //Slide In
        TranslateTransform postTransform = new TranslateTransform();
        PostResourcePanel.RenderTransform = postTransform;
        postTransform.BeginAnimation(TranslateTransform.XProperty, slideIn);
        
        
        
    }
    private void BtnConfirmCreate_Click(object sender, RoutedEventArgs e)
    {
        OnResourceAdded();
        
        string author = "N12J1";
        string name = InputName.Text;
        ResourceType? type = EnumTools.StringToResourceType(InputType.Text);
        Difficulty? difficulty = EnumTools.StringToDifficulty(InputDifficulty.Text);
        string description = InputDescription.Text;
        Split? split = EnumTools.StringToSplit(InputSplit.Text);
        string videoLink = InputVideoLink.Text;
        MyResources.AddResource(new Ressource(author, name, type, difficulty, description,null, videoLink,split));
        MyResourcesList.ItemsSource = null; 
        MyResourcesList.ItemsSource = MyResources.Resources;
    }
}