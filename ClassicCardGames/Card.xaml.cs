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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ClassicCardGames
{
    public sealed partial class PlayingCards : UserControl
    {
        public PlayingCards()
        {
            this.InitializeComponent();
            HideAllCards();
        }
        private void HideAllCards()
        {
            _DC.Visibility = Visibility.Collapsed;
            _BC.Visibility = Visibility.Collapsed;
            _AC.Visibility = Visibility.Collapsed;
            _2C.Visibility = Visibility.Collapsed;
            _3C.Visibility = Visibility.Collapsed;
            _4C.Visibility = Visibility.Collapsed;
            _5C.Visibility = Visibility.Collapsed;
            _6C.Visibility = Visibility.Collapsed;
            _7C.Visibility = Visibility.Collapsed;
            _8C.Visibility = Visibility.Collapsed;
            _9C.Visibility = Visibility.Collapsed;
            _10C.Visibility = Visibility.Collapsed;
            _JC.Visibility = Visibility.Collapsed;
            _QC.Visibility = Visibility.Collapsed;
            _KC.Visibility = Visibility.Collapsed;

            _AS.Visibility = Visibility.Collapsed;
            _2S.Visibility = Visibility.Collapsed;
            _3S.Visibility = Visibility.Collapsed;
            _4S.Visibility = Visibility.Collapsed;
            _5S.Visibility = Visibility.Collapsed;
            _6S.Visibility = Visibility.Collapsed;
            _7S.Visibility = Visibility.Collapsed;
            _8S.Visibility = Visibility.Collapsed;
            _9S.Visibility = Visibility.Collapsed;
            _10S.Visibility = Visibility.Collapsed;
            _JS.Visibility = Visibility.Collapsed;
            _QS.Visibility = Visibility.Collapsed;
            _KS.Visibility = Visibility.Collapsed;

            _AH.Visibility = Visibility.Collapsed;
            _2H.Visibility = Visibility.Collapsed;
            _3H.Visibility = Visibility.Collapsed;
            _4H.Visibility = Visibility.Collapsed;
            _5H.Visibility = Visibility.Collapsed;
            _6H.Visibility = Visibility.Collapsed;
            _7H.Visibility = Visibility.Collapsed;
            _8H.Visibility = Visibility.Collapsed;
            _9H.Visibility = Visibility.Collapsed;
            _10H.Visibility = Visibility.Collapsed;
            _JH.Visibility = Visibility.Collapsed;
            _QH.Visibility = Visibility.Collapsed;
            _KH.Visibility = Visibility.Collapsed;

            _AD.Visibility = Visibility.Collapsed;
            _2D.Visibility = Visibility.Collapsed;
            _3D.Visibility = Visibility.Collapsed;
            _4D.Visibility = Visibility.Collapsed;
            _5D.Visibility = Visibility.Collapsed;
            _6D.Visibility = Visibility.Collapsed;
            _7D.Visibility = Visibility.Collapsed;
            _8D.Visibility = Visibility.Collapsed;
            _9D.Visibility = Visibility.Collapsed;
            _10D.Visibility = Visibility.Collapsed;
            _JD.Visibility = Visibility.Collapsed;
            _QD.Visibility = Visibility.Collapsed;
            _KD.Visibility = Visibility.Collapsed;



        }
        



        public void DisplayCard(string card)
        {
            HideAllCards();
            switch (card)
            {
                case "BC":
                    _BC.Visibility = Visibility.Visible;
                    break;
                case "1C":
                    _AC.Visibility = Visibility.Visible;
                    break;
                case "2C":
                    _2C.Visibility = Visibility.Visible;
                    break;
                case "3C":
                    _3C.Visibility = Visibility.Visible;
                    break;
                case "4C":
                    _4C.Visibility = Visibility.Visible;
                    break;
                case "5C":
                    _5C.Visibility = Visibility.Visible;
                    break;
                case "6C":
                    _6C.Visibility = Visibility.Visible;
                    break;
                case "7C":
                    _7C.Visibility = Visibility.Visible;
                    break;
                case "8C":
                    _8C.Visibility = Visibility.Visible;
                    break;
                case "9C":
                    _9C.Visibility = Visibility.Visible;
                    break;
                case "10C":
                    _10C.Visibility = Visibility.Visible;
                    break;
                case "11C":
                    _JC.Visibility = Visibility.Visible;
                    break;
                case "12C":
                    _QC.Visibility = Visibility.Visible;
                    break;
                case "13C":
                    _KC.Visibility = Visibility.Visible;
                    break;

                case "1D":
                    _AD.Visibility = Visibility.Visible;
                    break;
                case "2D":
                    _2D.Visibility = Visibility.Visible;
                    break;
                case "3D":
                    _3D.Visibility = Visibility.Visible;
                    break;
                case "4D":
                    _4D.Visibility = Visibility.Visible;
                    break;
                case "5D":
                    _5D.Visibility = Visibility.Visible;
                    break;
                case "6D":
                    _6D.Visibility = Visibility.Visible;
                    break;
                case "7D":
                    _7D.Visibility = Visibility.Visible;
                    break;
                case "8D":
                    _8D.Visibility = Visibility.Visible;
                    break;
                case "9D":
                    _9D.Visibility = Visibility.Visible;
                    break;
                case "10D":
                    _10D.Visibility = Visibility.Visible;
                    break;
                case "11D":
                    _JD.Visibility = Visibility.Visible;
                    break;
                case "12D":
                    _QD.Visibility = Visibility.Visible;
                    break;
                case "13D":
                    _KD.Visibility = Visibility.Visible;
                    break;


                case "1H":
                    _AH.Visibility = Visibility.Visible;
                    break;
                case "2H":
                    _2H.Visibility = Visibility.Visible;
                    break;
                case "3H":
                    _3H.Visibility = Visibility.Visible;
                    break;
                case "4H":
                    _4H.Visibility = Visibility.Visible;
                    break;
                case "5H":
                    _5H.Visibility = Visibility.Visible;
                    break;
                case "6H":
                    _6H.Visibility = Visibility.Visible;
                    break;
                case "7H":
                    _7H.Visibility = Visibility.Visible;
                    break;
                case "8H":
                    _8H.Visibility = Visibility.Visible;
                    break;
                case "9H":
                    _9H.Visibility = Visibility.Visible;
                    break;
                case "10H":
                    _10H.Visibility = Visibility.Visible;
                    break;
                case "11H":
                    _JH.Visibility = Visibility.Visible;
                    break;
                case "12H":
                    _QH.Visibility = Visibility.Visible;
                    break;
                case "13H":
                    _KH.Visibility = Visibility.Visible;
                    break;

                case "1S":
                    _AS.Visibility = Visibility.Visible;
                    break;
                case "2S":
                    _2S.Visibility = Visibility.Visible;
                    break;
                case "3S":
                    _3S.Visibility = Visibility.Visible;
                    break;
                case "4S":
                    _4S.Visibility = Visibility.Visible;
                    break;
                case "5S":
                    _5S.Visibility = Visibility.Visible;
                    break;
                case "6S":
                    _6S.Visibility = Visibility.Visible;
                    break;
                case "7S":
                    _7S.Visibility = Visibility.Visible;
                    break;
                case "8S":
                    _8S.Visibility = Visibility.Visible;
                    break;
                case "9S":
                    _9S.Visibility = Visibility.Visible;
                    break;
                case "10S":
                    _10S.Visibility = Visibility.Visible;
                    break;
                case "11S":
                    _JS.Visibility = Visibility.Visible;
                    break;
                case "12S":
                    _QS.Visibility = Visibility.Visible;
                    break;
                case "13S":
                    _KS.Visibility = Visibility.Visible;
                    break;
                case "DC":
                    _DC.Visibility = Visibility.Visible;
                    break;
                case "Used":
                    break;


            }
        }
    }
}
