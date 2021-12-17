using ProjectSamVerdoodt.Models;
using ProjectSamVerdoodt.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ProjectSamVerdoodt.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PackPage : ContentPage
    {
        public string Card0 { get; set; }
        public string Card1 { get; set; }
        public string Card2 { get; set; }
        public string Card3 { get; set; }
        public string Card4 { get; set; }
        public string Card5 { get; set; }

        public PackPage()
        {
            InitializeComponent();
            Card0 = " ";
            Card1 = " ";
            Card2 = " ";
            Card3 = " ";
            Card4 = " ";
            Card5 = " ";

        }



        private async Task<List<string>> LoadRandoCard()
        {

            List<YuGiOhCard> cards = await APIRepo.GetRandomCardAsync();
            List<string> info = new List<string>();
            foreach (YuGiOhCard c in cards)
            {
                info.Add(c.CardImg);
                info.Add(c.CardName);
            }
            return info;
        }


        private void BtnReturn_Clicked(object sender, EventArgs e)
        {

            Navigation.PopAsync();
        }

        private void BtnRefresh_Clicked(object sender, EventArgs e)
        {
            ImgCard0.Source = "https://ygoprodeck.com/pics/back_high.jpg";
            ImgCard1.Source = "https://ygoprodeck.com/pics/back_high.jpg";
            ImgCard2.Source = "https://ygoprodeck.com/pics/back_high.jpg";
            ImgCard3.Source = "https://ygoprodeck.com/pics/back_high.jpg";
            ImgCard4.Source = "https://ygoprodeck.com/pics/back_high.jpg";
            ImgCard5.Source = "https://ygoprodeck.com/pics/back_high.jpg";
            Card0 = " ";
            Card1 = " ";
            Card2 = " ";
            Card3 = " ";
            Card4 = " ";
            Card5 = " ";

        }

        private async void Card0_Tapped(object sender, EventArgs e)
        {  
            string ImgSource = ImgCard0.Source.GetValue(UriImageSource.UriProperty).ToString();
            List<string> Info = new List<string>();
            if (ImgSource == "https://ygoprodeck.com/pics/back_high.jpg") {
                Info = await LoadRandoCard();
                ImgCard0.Source = Info[0];
                Card0 = Info[1];
            }
            else
            {
                Navigation.PushAsync(new DetailsCard(Card0));
            }
            
        }
        private async void Card1_Tapped(object sender, EventArgs e)
        {
            string ImgSource = ImgCard1.Source.GetValue(UriImageSource.UriProperty).ToString();
            List<string> Info = new List<string>();
            if (ImgSource == "https://ygoprodeck.com/pics/back_high.jpg")
            {
                Info = await LoadRandoCard();
                ImgCard1.Source = Info[0];
                Card1 = Info[1];
            }
            else
            {
                Navigation.PushAsync(new DetailsCard(Card1));
            }
        }
        private async void Card2_Tapped(object sender, EventArgs e)
        {
            string ImgSource = ImgCard2.Source.GetValue(UriImageSource.UriProperty).ToString();
            List<string> Info = new List<string>();
            if (ImgSource == "https://ygoprodeck.com/pics/back_high.jpg")
            {
                Info = await LoadRandoCard();
                ImgCard2.Source = Info[0];
                Card2 = Info[1];
            }
            else
            {
                Navigation.PushAsync(new DetailsCard(Card2));
            }
        }
        private async void Card3_Tapped(object sender, EventArgs e)
        {
            string ImgSource = ImgCard3.Source.GetValue(UriImageSource.UriProperty).ToString();
            List<string> Info = new List<string>();
            if (ImgSource == "https://ygoprodeck.com/pics/back_high.jpg")
            {
                Info = await LoadRandoCard();
                ImgCard3.Source = Info[0];
                Card3 = Info[1];
            }
            else
            {
                Navigation.PushAsync(new DetailsCard(Card3));
            }
        }
        private async void Card4_Tapped(object sender, EventArgs e)
        {
            string ImgSource = ImgCard4.Source.GetValue(UriImageSource.UriProperty).ToString();
            List<string> Info = new List<string>();
            if (ImgSource == "https://ygoprodeck.com/pics/back_high.jpg")
            {
                Info = await LoadRandoCard();
                ImgCard4.Source = Info[0];
                Card4 = Info[1];
            }
            else
            {
                Navigation.PushAsync(new DetailsCard(Card4));
            }
        }
        private async void Card5_Tapped(object sender, EventArgs e)
        {
            string ImgSource = ImgCard5.Source.GetValue(UriImageSource.UriProperty).ToString();
            List<string> Info = new List<string>();
            if (ImgSource == "https://ygoprodeck.com/pics/back_high.jpg")
            {
                Info = await LoadRandoCard();
                ImgCard5.Source = Info[0];
                Card5 = Info[1];
            }
            else
            {
                Navigation.PushAsync(new DetailsCard(Card5));
            }
        }
    }
}