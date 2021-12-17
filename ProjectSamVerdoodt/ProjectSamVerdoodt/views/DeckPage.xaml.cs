using ProjectSamVerdoodt.Models;
using ProjectSamVerdoodt.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectSamVerdoodt.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeckPage : ContentPage
    {
        public DeckPage()
        {
            InitializeComponent();
            LoadAllDecks();
        }
        private async Task LoadAllDecks()
        {
            List<YuGiOhDeckJson> decks = await DeckAPIRepo.GetAllDeckAsync();
            List<string> deckNames = new List<string>();
            foreach (YuGiOhDeckJson d in decks)
            {
                foreach (string deck in d.DeckList)
                {
                    deckNames.Add(deck);
                }
            }
            ShowDecks(deckNames);
        }

        private async Task ShowDecks(List<string>Decks)
        {
            foreach(string name in Decks)
            {
                gridDecks.Children.Add(new Label {Text = name}) ;
            }
        }
    }
}