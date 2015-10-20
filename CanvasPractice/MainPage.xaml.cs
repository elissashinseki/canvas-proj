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
            _inkPresenter = inkCanvas.InkPresenter;
            _inkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Pen;
        }

        //adf
        private void redButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Red;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void orangeButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Orange;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void yellowButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Yellow;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void greenButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Green;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void blueButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Azure;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void purpleButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Purple;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void blackButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Black;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void maxthickButton_Click(object sender, RoutedEventArgs e)
        {
            var size = _inkDrawingAttributes.Size;
            size.Width = 6;
            _inkDrawingAttributes.Size = size;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void mediumthickButton_Click(object sender, RoutedEventArgs e)
        {
            var size = _inkDrawingAttributes.Size;
            size.Width = 4;
            _inkDrawingAttributes.Size = size;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void normalthickButton_Click(object sender, RoutedEventArgs e)
        {
            var size = _inkDrawingAttributes.Size;
            size.Width = 2;
            _inkDrawingAttributes.Size = size;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void drawButton_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.InkPresenter.InputProcessingConfiguration.Mode = Windows.UI.Input.Inking.InkInputProcessingMode.Inking;
        }

        private void eraseButton_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.InkPresenter.InputProcessingConfiguration.Mode = Windows.UI.Input.Inking.InkInputProcessingMode.Erasing;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            _inkPresenter.StrokeContainer.Clear();
        }

        //http://stackoverflow.com/questions/6246009/inkcanvas-load-save-operations
        //https://msdn.microsoft.com/en-us/library/system.windows.controls.inkcanvas(v=vs.110).aspx

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //FileStream fileStream;
            //String inkFileName = getFileName();

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
            
        }



        public void update_size(object sender, RoutedEventArgs e)
        {
            MainPage page = (MainPage)sender;

            if (page.ActualWidth < 800)
            {
                page.webview.Visibility = Visibility.Collapsed;
                page.searchBox.Visibility = Visibility.Collapsed;
                page.goButton.Visibility = Visibility.Collapsed;

                page.inkCanvas.SetValue(Grid.ColumnProperty, 0);
                page.inkCanvas.SetValue(Grid.ColumnSpanProperty, 3);

                page.canvasBorder.SetValue(Grid.ColumnProperty, 0);
                page.canvasBorder.SetValue(Grid.ColumnSpanProperty, 3);

                page.commandBar.SetValue(Grid.ColumnProperty, 0);
                page.canvasBorder.SetValue(Grid.ColumnSpanProperty, 3);
                commandBar.Width = page.ActualWidth;

            }

            else
            {
                page.webview.Visibility = Visibility.Visible;
                page.searchBox.Visibility = Visibility.Visible;
                page.goButton.Visibility = Visibility.Visible;

                page.inkCanvas.SetValue(Grid.ColumnProperty, 2);
                page.inkCanvas.SetValue(Grid.ColumnSpanProperty, 1);

                page.canvasBorder.SetValue(Grid.ColumnProperty, 2);
                page.canvasBorder.SetValue(Grid.ColumnSpanProperty, 1);

                page.commandBar.SetValue(Grid.ColumnProperty, 2);
                page.canvasBorder.SetValue(Grid.ColumnSpanProperty, 1);
            }
        }

        // private variables
        private InkDrawingAttributes _inkDrawingAttributes = new InkDrawingAttributes();
        private InkPresenter _inkPresenter;
    }
}

