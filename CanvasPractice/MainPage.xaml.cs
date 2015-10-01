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
            inkCanvas.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Pen;
           
        }

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
            _inkDrawingAttributes.Color = Windows.UI.Colors.Blue;
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

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            //StrokeCollection newThing = new StrokeCollection();
        }

        //http://stackoverflow.com/questions/6246009/inkcanvas-load-save-operations
        //https://msdn.microsoft.com/en-us/library/system.windows.controls.inkcanvas(v=vs.110).aspx
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            String newFileName = "newDrawing";
            var fs = new FileStream(newFileName, FileMode.Create);
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // private variables
        private InkDrawingAttributes _inkDrawingAttributes = new InkDrawingAttributes();
    }
}

