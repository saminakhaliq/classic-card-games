using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClassicCardGames
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Instruction : Page
    {
        public Game ChosenGame { get; set; }
        public Instruction()
        {
            this.InitializeComponent(); 
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ChosenGame = (Game)e.Parameter;

            base.OnNavigatedTo(e);
        }

        //Sends player to chosen Game 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ChosenGame.GameName == "TOP CARD")
                this.Frame.Navigate(typeof(TopCardPage), e);
            else if(ChosenGame.GameName == "CRAZY 8'S")
                this.Frame.Navigate(typeof(CrazyEightsPage), e);
            else if(ChosenGame.GameName == "TRIPLES")
                this.Frame.Navigate(typeof(TriplesPage), e);



        }
        //Go  back

        private void BackButton_Click2(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
