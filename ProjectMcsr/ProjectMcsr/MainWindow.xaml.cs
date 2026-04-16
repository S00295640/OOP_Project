using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
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
using Microsoft.Web.WebView2.Core;
using ProjectMcsr.Models;

namespace ProjectMcsr;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MyResourceHandler MyResources;
    ObservableCollection<Ressource> FilteredRessources;
    public MainWindow()
    {
        InitializeComponent();
        MyResourceHandler handler = Initialize();
        this.Closing += (s, e) => handler.SaveResources();
    }
    
    

    private MyResourceHandler Initialize()
    {
        MyResources = new MyResourceHandler();
        MyResourcesList.ItemsSource = MyResources.Resources;
        
        return MyResources;
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
        CloseDetail_Click(null, null);
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
        CloseDetail_Click(null, null);
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
        CloseDetail_Click(null, null);
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
        string? name = InputName.Text;
        ResourceType? type = EnumTools.StringToResourceType(InputType.Text);
        Difficulty? difficulty = EnumTools.StringToDifficulty(InputDifficulty.Text);
        string description = "";
        description = InputDescription.Text;
        Split? split = EnumTools.StringToSplit(InputSplit.Text);
        string videoLink = InputVideoLink.Text;
        Ressource? resource = null;
        try
        {
            Console.WriteLine("name : " + name);
            Console.WriteLine("author : " + author);
            Console.WriteLine("type : " + type);
            Console.WriteLine("description : " + description);
            Console.WriteLine("videoLink : " + videoLink);
            Console.WriteLine("split : " + split);
            Console.WriteLine("difficulty : " + difficulty);
            resource = new Ressource(author, name, type, difficulty, description, null, videoLink, split);
            resource.GetChannelName();
        }
        catch (Exception exception)
        {
            if (name == "")
            {
                ShowErrorMessage("Error ! NAME cannot be null");
            }

            if (type == null)
            {
                ShowErrorMessage("Error ! TYPE cannot be null");
            }

            if (difficulty == null)
            {
                ShowErrorMessage("Error ! DIFFICULTY cannot be null");
            }

            if (videoLink == "")
            {
                MessageBox.Show("Error ! video link cannot be null", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            return;
        }
        
        MyResources.AddResource(resource);
        MyResourcesList.ItemsSource = null; 
        MyResourcesList.ItemsSource = MyResources.Resources;
        MyResources.SaveResources();
    }

    private Ressource? _pendingDelete;
    public void RemoveResource(object sender, RoutedEventArgs e)
    {
        Button button = (Button) sender;
        _pendingDelete = button.DataContext as Ressource;
        DeleteConfirmOverlay.Visibility = Visibility.Visible;
        Storyboard sb = (Storyboard)DeleteConfirmOverlay.Resources["ShowMenuAnim"];
        sb.Begin();
        
    }

    public void ConfirmDelete_Click(object sender, RoutedEventArgs e)
    {
        if (_pendingDelete != null)
        {
           MyResources.RemoveResource(_pendingDelete); 
        }
        CloseDeleteMenu();
    }

    public void CancelDelete_Click(object sender, RoutedEventArgs e)
    {
        CloseDeleteMenu();
    }

    public void CloseDeleteMenu()
    {
        _pendingDelete = null;
        DeleteConfirmOverlay.Visibility = Visibility.Collapsed;
        MenuScale.ScaleX = 0;
        MenuScale.ScaleY = 0;
        
        MyResourcesList.ItemsSource = null; 
        MyResourcesList.ItemsSource = MyResources.Resources;
    }

    public void OnSortSelectionChange(object sender, SelectionChangedEventArgs e)
    {
        if (MyResources == null)
        {
            return;
        }
        ComboBox dropDown = sender as ComboBox;
        
        SortBy? type = EnumTools.StringToSortBy((dropDown.SelectedItem as ComboBoxItem).Content.ToString());

        if (type != null)
        {
            MyResources.SortResourcesBy((SortBy)type);
        }
        else
            MyResources.SortResourcesBy(SortBy.Name);

        MyResourcesList.ItemsSource = null; 
        MyResourcesList.ItemsSource = MyResources.Resources;
    }

    public void CloseMessage_Click(object sender, RoutedEventArgs e)
    {
        MessageOverlay.Visibility = Visibility.Collapsed;
    }

    private void ShowErrorMessage(string message)
    {
        ErrorMessageText.Text = message;
        MessageOverlay.Visibility = Visibility.Visible;
    }


    public void OnResourceClicked(Object sender, RoutedEventArgs e)
    {
        Border border = sender as Border;
        Ressource ressource = border.DataContext as Ressource;

        DetailOverlay.DataContext = ressource; 
        
        DetailTitle.Text = ressource.name;
        
        DetailTitle.Text = ressource.name;
        DetailDescription.Text = ressource.description;
        DetailAuthorName.Text = ressource.author;
        
        BitmapImage bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.UriSource = new Uri(ressource.idVideo, UriKind.Absolute);
        bitmap.EndInit();
        YoutubeImage.Source = bitmap;
        
        Storyboard sb = (Storyboard)FindResource("SlideInMenu");
        sb.Begin();
        
        var listeCoeurs = new List<int>();
        
        for (int i = 0; i < EnumTools.DifficultyToInt(ressource.difficulty); i++) { listeCoeurs.Add(1); }
        
        DifficultyHeartsControl.ItemsSource = listeCoeurs;
        
        
        if (ressource.split == Split.Bastion) 
            SplitIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/Bastion.png"));
        if (ressource.split == Split.Blind) 
            SplitIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/Blind.png"));
        if (ressource.split == Split.End) 
            SplitIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/End.png"));
        if (ressource.split == Split.Fortress) 
            SplitIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/Fortress.png"));
        if (ressource.split == Split.EnterNether) 
            SplitIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/Nether.png"));
        if (ressource.split == Split.Stronghold) 
            SplitIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/Stronghold.png"));
        if (ressource.split == Split.Overworld) 
            SplitIcon.Source = new BitmapImage(new Uri(@"pack://application:,,,/Assets/Overworld.png"));
    }

    private void CloseDetail_Click(object sender, RoutedEventArgs e)
    {
        Storyboard sb = (Storyboard)FindResource("SlideOutMenu");
        sb.Begin();
    }
    private void OnWatchOnYoutubeClicked(object sender, RoutedEventArgs e)
    {
        if (DetailTitle.DataContext is Ressource ressource)
        {
            Console.WriteLine(ressource);
            string url = $"https://www.youtube.com/watch?v={ressource.OnlyIdVideo}";
        
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
    
    //--find part--
    
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        
        if (MyResources == null || ResourcesList == null) 
            return;
        
        string searchText = searchTextBox.Text.Trim().ToLower();

        
        
        if (string.IsNullOrWhiteSpace(searchText))
        {
            FilteredRessources = new ObservableCollection<Ressource>(MyResources.Resources);
        }
        else
        {

            var results = MyResources.Resources.Where(r =>
                r.name.ToLower().Contains(searchText) ||
                r.description.ToLower().Contains(searchText) ||
                r.author.ToLower().Contains(searchText) ||
                r.split.ToString().ToLower().Contains(searchText)
            );
            
            string selectedSort = (SortSelectorFindMenu.SelectedItem as ComboBoxItem)?.Content.ToString();
            results = selectedSort switch
            {
                "Type"       => results.OrderBy(r => r.type),
                "Difficulty" => results.OrderByDescending(r => r.difficulty), // Souvent on veut la diff max en haut
                "Split"      => results.OrderBy(r => r.split),
                "Date"       => results.OrderByDescending(r => r.date),
                "Author"      => results.OrderBy(r => r.author),
                _            => results.OrderBy(r => r.name), // Par défaut : Name
            };
                
                

            FilteredRessources = new ObservableCollection<Ressource>(results);
        }
    
        
        ResourcesList.ItemsSource = FilteredRessources;
    }

    private void OnSortSelectionChangeFindMenu(object sender, RoutedEventArgs e)
    {
        if (searchTextBox == null || MyResources == null || ResourcesList == null) 
            return;
        OnSearchTextChanged(null, null);
    }

}