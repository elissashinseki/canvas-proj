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
            _inkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Pen | Windows.UI.Core.CoreInputDeviceTypes.Touch;
            _inkDrawingAttributes = new InkDrawingAttributes();
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

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // https://msdn.microsoft.com/en-us/library/windows/apps/Dn922011(v=win.10).aspx?appId=Dev14IDEF1&l=EN-US&k=k(Windows.UI.Input.Inking.InkPresenter)%3bk(TargetFrameworkMoniker-.NETCore,Version%3dv5.0)%3bk(DevLang-csharp)&rd=true
        //http://stackoverflow.com/questions/6246009/inkcanvas-load-save-operations
        // https://social.msdn.microsoft.com/Forums/en-US/55bd1f52-78df-45b2-b5cc-5cb6fcfc6ea9/uwp-universal-window-app-run-on-windows-10-inkcanvas-strokes-save-to-jpg-file?forum=wpdevelop
        // http://www.scriptscoop.com/t/76446e53245c/c-save-strokes-of-inkmanager-in-localstorage-windows-8-app.html

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //String inkFileName = "drawing";
            //var strokes = _inkPresenter.StrokeContainer.GetStrokes();
            //saveToFile(inkFileName, strokes);
        }

        public async void saveToFile(String inkFileName, byte[] strokes)
        {
            // GET FILENAME
            //StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            var folderName = ApplicationData.Current.LocalFolder;
            var collisionCase = CreationCollisionOption.OpenIfExists;
            var storageFile = await folderName.CreateFileAsync(inkFileName, collisionCase); 
            
            if (storageFile != null)
            {
            //    await Windows.Storage.FileIO.WriteBytesAsync(storageFile);
            }

            //var strokes = _inkPresenter.StrokeContainer.SaveAsync(fileStream);
            //Save(fileStream);

            //(inkFileName)

            // String newFileName = "newDrawing";
            // var fs = new FileStream(newFileName, FileMode.Create);
        }

        //private String getFileName()
        //{
        //Form testDialog = new Form;

        //return getFileName;
        //}

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
          //  var fileStream = new FileInputStream();
        }

        private void web_Check(object sender, RoutedEventArgs e)
        {
            webview.Visibility = Visibility.Visible;
            searchBox.Visibility = Visibility.Visible;
            goButton.Visibility = Visibility.Visible;
            backButton.Visibility = Visibility.Visible;

            inkCanvas.SetValue(Grid.ColumnProperty, 3);
            inkCanvas.SetValue(Grid.ColumnSpanProperty, 1);

            canvasBorder.SetValue(Grid.ColumnProperty, 3);
            canvasBorder.SetValue(Grid.ColumnSpanProperty, 1);
            canvasBorder.SetValue(Grid.ColumnSpanProperty, 1);
        }

        private void web_Uncheck(object sender, RoutedEventArgs e)
        {
            webview.Visibility = Visibility.Collapsed;
            searchBox.Visibility = Visibility.Collapsed;
            goButton.Visibility = Visibility.Collapsed;
            backButton.Visibility = Visibility.Collapsed;

            canvasBorder.SetValue(Grid.ColumnProperty, 0);
            canvasBorder.SetValue(Grid.ColumnSpanProperty, 4);
            canvasBorder.SetValue(Grid.ColumnSpanProperty, 4);
        }

        public void update_size(object sender, RoutedEventArgs e)
        {
            MainPage page = (MainPage)sender;

            if (page.ActualWidth < 800)
            {
                page.webview.Visibility = Visibility.Collapsed;
                page.searchBox.Visibility = Visibility.Collapsed;
                page.goButton.Visibility = Visibility.Collapsed;
                page.backButton.Visibility = Visibility.Collapsed;

                page.inkCanvas.SetValue(Grid.ColumnProperty, 0);
                page.inkCanvas.SetValue(Grid.ColumnSpanProperty, 4);

                page.canvasBorder.SetValue(Grid.ColumnProperty, 0);
                page.canvasBorder.SetValue(Grid.ColumnSpanProperty, 4);
                page.canvasBorder.SetValue(Grid.ColumnSpanProperty, 4);

            }

            else
            {
                page.webview.Visibility = Visibility.Visible;
                page.searchBox.Visibility = Visibility.Visible;
                page.goButton.Visibility = Visibility.Visible;
                page.backButton.Visibility = Visibility.Visible;

                page.inkCanvas.SetValue(Grid.ColumnProperty, 3);
                page.inkCanvas.SetValue(Grid.ColumnSpanProperty, 1);

                page.canvasBorder.SetValue(Grid.ColumnProperty, 3);
                page.canvasBorder.SetValue(Grid.ColumnSpanProperty, 1);
                page.canvasBorder.SetValue(Grid.ColumnSpanProperty, 1);
            }
        }

        // private variables
        private InkCanvas _inkCanvas;
        private InkDrawingAttributes _inkDrawingAttributes;
        private InkPresenter _inkPresenter;

    }
}

