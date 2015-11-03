using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.Storage.Streams;
using Windows.Storage;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CanvasPractice
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame. 
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            _inkCanvas = inkCanvas;
            _inkPresenter = inkCanvas.InkPresenter;
            _inkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Pen;
            _inkDrawingAttributes = new InkDrawingAttributes();

            webView.Visibility = Visibility.Collapsed;
            searchBox.Visibility = Visibility.Collapsed;
            goButton.Visibility = Visibility.Collapsed;
            backButton.Visibility = Visibility.Collapsed;
            
        }

        private void redButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Red;
            _inkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void orangeButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Orange;
            _inkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void yellowButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Yellow;
            _inkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void greenButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Green;
            _inkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void blueButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Azure;
            _inkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void purpleButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Purple;
            _inkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void blackButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Black;
            _inkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void maxthickButton_Click(object sender, RoutedEventArgs e)
        {
            updateThickness(6);
        }

        private void mediumthickButton_Click(object sender, RoutedEventArgs e)
        {
            updateThickness(4);
        }

        private void normalthickButton_Click(object sender, RoutedEventArgs e)
        {
            updateThickness(2);
        }

        private void updateThickness(int newSize)
        {
            var size = _inkDrawingAttributes.Size;
            size.Width = newSize;
            _inkDrawingAttributes.Size = size;
            _inkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void drawButton_Click(object sender, RoutedEventArgs e)
        {
            _inkPresenter.InputProcessingConfiguration.Mode = Windows.UI.Input.Inking.InkInputProcessingMode.Inking;
        }

        private void eraseButton_Click(object sender, RoutedEventArgs e)
        {
            _inkPresenter.InputProcessingConfiguration.Mode = Windows.UI.Input.Inking.InkInputProcessingMode.Erasing;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            _inkPresenter.StrokeContainer.Clear();
        }

        //http://stackoverflow.com/questions/6246009/inkcanvas-load-save-operations
        //https://msdn.microsoft.com/en-us/library/system.windows.controls.inkcanvas(v=vs.110).aspx
        // https://social.msdn.microsoft.com/Forums/en-US/55bd1f52-78df-45b2-b5cc-5cb6fcfc6ea9/uwp-universal-window-app-run-on-windows-10-inkcanvas-strokes-save-to-jpg-file?forum=wpdevelop

        /*
            Saves strokes as a GIF file
        */
        // https://github.com/Microsoft/Windows-universal-samples/blob/93bdfb92b3da76f2e49c959807fc5643bf0940c9/Samples/SimpleInk/cs/Scenario1.xaml.cs

        async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_inkPresenter.StrokeContainer.GetStrokes().Count > 0)
            {
                var save = new Windows.Storage.Pickers.FileSavePicker();
                save.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
                save.FileTypeChoices.Add("Gif with embedded ISF", new System.Collections.Generic.List<String> { ".gif" });

                Windows.Storage.StorageFile file = await save.PickSaveFileAsync();

                if (null != file)
                {
                    try
                    {
                        using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                        {
                            await inkCanvas.InkPresenter.StrokeContainer.SaveAsync(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Figure out how to notify the user of failure
                    }
                }
            }
        }



        async void loadButton_Click(object sender, RoutedEventArgs e)
        {
            var open = new Windows.Storage.Pickers.FileOpenPicker();
            open.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            open.FileTypeFilter.Add(".gif");
            open.FileTypeFilter.Add(".isf");

            Windows.Storage.StorageFile file = await open.PickSingleFileAsync();

            if (null != file)
            {
                using (var stream = await file.OpenSequentialReadAsync())
                {
                    //try
                    //{
                    //    await inkCanvas.InkPresenter.StrokeContainer.LoadAsync(stream);
                    //}
                    //catch (Exception ex)
                    //{
                    //    // Figure out how to notify user of failure
                    //}
                }
            }
        }

        private void paneExtention_Checked(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = true;
        }
        private void paneExtention_Unchecked(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;
        }

        public void update_size(object sender, RoutedEventArgs e)
        {
            MainPage page = (MainPage)sender;

            if (page.ActualWidth < 800) //SECOND
            {
                page.webView.Visibility = Visibility.Collapsed;
                page.searchBox.Visibility = Visibility.Collapsed;
                page.goButton.Visibility = Visibility.Collapsed;
                page.backButton.Visibility = Visibility.Collapsed;

                page.inkCanvas.SetValue(Grid.ColumnProperty, 1);
                page.inkCanvas.SetValue(Grid.ColumnSpanProperty, 4);


                hideBrowser.Visibility = Visibility.Collapsed;
                webViewSeparator.Visibility = Visibility.Collapsed;

            }

            else if (_isShown == true) // FIRST
            {
                page.webView.Visibility = Visibility.Visible;
                page.searchBox.Visibility = Visibility.Visible;
                page.goButton.Visibility = Visibility.Visible;
                page.backButton.Visibility = Visibility.Visible;

                page.inkCanvas.SetValue(Grid.ColumnProperty, 4);
                page.inkCanvas.SetValue(Grid.ColumnSpanProperty, 1);

                hideBrowser.Visibility = Visibility.Visible;
                webViewSeparator.Visibility = Visibility.Visible;

            }
            else
            {
                page.inkCanvas.SetValue(Grid.ColumnProperty, 1);
                page.inkCanvas.SetValue(Grid.ColumnSpanProperty, 4);

                hideBrowser.Visibility = Visibility.Visible;
                webViewSeparator.Visibility = Visibility.Visible;
            }

            
        }

        //FIRST
        private void hideBrowser_Unchecked(object sender, RoutedEventArgs e)

        {
            webView.Visibility = Visibility.Collapsed;
            searchBox.Visibility = Visibility.Collapsed;
            goButton.Visibility = Visibility.Collapsed;
            backButton.Visibility = Visibility.Collapsed;


            _isShown = false;
        }

        //SECOND
        private void hideBrowser_Checked(object sender, RoutedEventArgs e)

        {
            webView.Visibility = Visibility.Visible;
            searchBox.Visibility = Visibility.Visible;
            goButton.Visibility = Visibility.Visible;
            backButton.Visibility = Visibility.Visible;

            _isShown = true;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) // take passed on data
        {
            var dataPasser = e.Parameter as passData;

            if (dataPasser != null)
            {
                _currerntUserName = dataPasser.username;
               
                    userNameButton.Content = _currerntUserName;
            }
            else
            {
                _currerntUserName = "Fail";
            }


        }

        // private variables
        private InkCanvas _inkCanvas;
        private InkDrawingAttributes _inkDrawingAttributes;
        private InkPresenter _inkPresenter;
        private Boolean _isShown;
        private string _currerntUserName;

       
    }
}

