using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using lab_5.ViewModels;
using System.IO;

namespace lab_5.Views
{
    public partial class MainWindow : Window
    {
            public MainWindow()
            {
                InitializeComponent();
#if DEBUG
                this.AttachDevTools();
#endif

                this.FindControl<Button>("OpenFile").Click += async delegate
                {
                    var TaskGet = new OpenFileDialog()
                    {
                        Title = "Открыть Файл",
                        Filters = null
                    }.ShowAsync((Window)this.VisualRoot);

                    string[]? PathToFile = await TaskGet;
                    var Value = this.DataContext as MainWindowViewModel;
                    if (PathToFile != null)
                    {
                        StreamReader FReader = new StreamReader(string.Join(@"\", PathToFile));
                        Value.Text = FReader.ReadToEnd();
                    }
                };

                this.FindControl<Button>("SaveFile").Click += async delegate
                {
                    SaveFileDialog SaveFileBox = new SaveFileDialog();
                    SaveFileBox.Title = "Сохранить как";
                    SaveFileBox.InitialFileName = "result.txt";

                    var PathToTheFile = await SaveFileBox.ShowAsync((Window)this.VisualRoot);

                    if(PathToTheFile != null)
                    {
                        var temp = this.DataContext as MainWindowViewModel;
                        File.WriteAllText(PathToTheFile, temp.Result);
                    }
                };
                
            }     

            private void InitializeComponent()
            {
                AvaloniaXamlLoader.Load(this);
            }

            private void MyClickEventHandler(object? Sender, RoutedEventArgs e)
            {
                var Value = new SetRegexWindow();
                Value.OkNotification += delegate (string str)
                {
                    var temp = this.DataContext as MainWindowViewModel;
                    temp.Regular = str;
                    temp.Result = temp.FindRegex();
                };
                Value.Show((Window)this.VisualRoot);
            }
    }
}
