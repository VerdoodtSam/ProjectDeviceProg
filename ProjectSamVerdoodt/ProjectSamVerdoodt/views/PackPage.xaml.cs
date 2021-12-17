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
    public partial class PackPage : ContentPage
    {
        public PackPage()
        {
            InitializeComponent();
        }



        private async Task<string> LoadRandoCard()
        {

            List<YuGiOhCard> cards = await APIRepo.GetRandomCardAsync();
            string imgUrl = "";
            foreach (YuGiOhCard c in cards)
            {
                imgUrl = c.CardImg;
            }
            return imgUrl;
        }


        private void BtnReturn_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new MainPage());
        }

        private void BtnRefresh_Clicked(object sender, EventArgs e)
        {
            ImgCard0.Source = "https://ygoprodeck.com/pics/back_high.jpg";
            ImgCard1.Source = "https://ygoprodeck.com/pics/back_high.jpg";
            ImgCard2.Source = "https://ygoprodeck.com/pics/back_high.jpg";
            ImgCard3.Source = "https://ygoprodeck.com/pics/back_high.jpg";
            ImgCard4.Source = "https://ygoprodeck.com/pics/back_high.jpg";
            ImgCard5.Source = "https://ygoprodeck.com/pics/back_high.jpg";

        }

        private async void Card0_Tapped(object sender, EventArgs e)
        {
            ImgCard0.Source = await LoadRandoCard();
        }
        private async void Card1_Tapped(object sender, EventArgs e)
        {
            ImgCard1.Source = await LoadRandoCard();
        }
        private async void Card2_Tapped(object sender, EventArgs e)
        {
            ImgCard2.Source = await LoadRandoCard();
        }
        private async void Card3_Tapped(object sender, EventArgs e)
        {
            ImgCard3.Source = await LoadRandoCard();
        }
        private async void Card4_Tapped(object sender, EventArgs e)
        {
            ImgCard4.Source = await LoadRandoCard();
        }
        private async void Card5_Tapped(object sender, EventArgs e)
        {
            ImgCard5.Source = await LoadRandoCard();

        }
    }
}