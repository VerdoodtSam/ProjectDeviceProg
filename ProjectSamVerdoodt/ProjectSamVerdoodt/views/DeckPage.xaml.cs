using ProjectSamVerdoodt.Models;
using ProjectSamVerdoodt.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectSamVerdoodt.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeckPage : ContentPage
    {
        public string CurrentCard { get; set; }
        public int CurrentId { get; set; }
        public DeckPage(string CurrentCardName)
        {
            InitializeComponent();
            CurrentCard = CurrentCardName;
            UpdateSelectedCard(CurrentCard);
            LoadInfoCard(CurrentCard);
            LoadAllDecks();

        }

        private async Task UpdateSelectedCard(string currentCard)
        {
            SelectedCard.Text = "Current selected card: " + currentCard;
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

        private async Task ShowDecks(List<string> Decks)
        {
            for (int i = Decks.Count; i < 9; i++)
            {
                Decks.Add(" ");
            }
            deck0.Text = Decks[0];
            deck1.Text = Decks[1];
            deck2.Text = Decks[2];
            deck3.Text = Decks[3];
            deck4.Text = Decks[4];
            deck5.Text = Decks[5];
            deck6.Text = Decks[6];
            deck7.Text = Decks[7];
            deck8.Text = Decks[8];
        }

        private async Task LoadInfoCard(string name)
        {
            List<YuGiOhCard> cardInfo = await APIRepo.GetCardInfo(name);
            foreach (YuGiOhCard c in cardInfo)
            {
                CurrentId = c.CardId;
            }
        }
        private void BtnReturn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}