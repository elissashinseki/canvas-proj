using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            canvas.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Pen;
        }

        private void redButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Red;
            canvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void orangeButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Orange;
            canvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void yellowButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Yellow;
            canvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void greenButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Green;
            canvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void blueButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Blue;
            canvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void purpleButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Purple;
            canvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void blackButton_Click(object sender, RoutedEventArgs e)
        {
            _inkDrawingAttributes.Color = Windows.UI.Colors.Black;
            canvas.InkPresenter.UpdateDefaultDrawingAttributes(_inkDrawingAttributes);
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {

        }


        // private variables
        private InkDrawingAttributes _inkDrawingAttributes = new InkDrawingAttributes();
        private Elissa Hi = new Elissa();
    }
}


