using ProjectSamVerdoodt.Models;
using ProjectSamVerdoodt.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using ProjectSamVerdoodt.views;

namespace ProjectSamVerdoodt
{
    public partial class MainPage : ContentPage
    {
        public string CurrentCardName { get; set; }
        public MainPage()
        {
            InitializeComponent();


            LoadRandoCard();
        }
        private async Task LoadRandoCard()
        {

            List<YuGiOhCard> cards = await APIRepo.GetRandomCardAsync();
            foreach (YuGiOhCard c in cards)
            {
                MPImg.Source = c.CardImg;
                MPName.Text = c.CardName;
                CurrentCardName = c.CardName;
            }
        }

        private async Task LoadCard(string name)
        {
            List<YuGiOhCard> cards = await APIRepo.GetCardInfo(name);
            foreach (YuGiOhCard c in cards)
            {
                if(c is null)
                {
                    SearchFailed.IsVisible = true;
                }
                else
                {
                    MPImg.Source = c.CardImg;
                    MPName.Text = c.CardName;
                    CurrentCardName = c.CardName;
                }
                
            }
        }

        private void Search_Typed(object sender, EventArgs e)
        {
            BtnSearch.IsEnabled = true;
            SearchFailed.IsVisible = false;
        }

        private void BtnSearch_Clicked(object sender, EventArgs e)
        {
            string CardName = SearchName.Text;
            LoadCard(CardName);
        }

        private void BtnRando_Clicked(object sender, EventArgs e)
        {
            LoadRandoCard();
        }

        private void BtnDetails_Clicked(object sender, EventArgs e) { 
        
            Navigation.PushAsync(new DetailsCard(CurrentCardName));
        }

        private void BtnAddDeck_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeckPage());
        }

        private void BtnPack_Clicked(object sender,EventArgs e)
        {
            Navigation.PushAsync(new PackPage());
        }
        
        private async Task TestRepository()
        {
            List<YuGiOhCard> cards = await APIRepo.GetRandomCardAsync();
            foreach(YuGiOhCard c in cards)
            {
                Debug.WriteLine(c.CardName);
            }
            
        }
    }
}
