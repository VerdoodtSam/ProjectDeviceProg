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

namespace ProjectSamVerdoodt
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            LoadCard();
        }
        private async void LoadCard()
        {

            MPOneCard.ItemsSource = await APIRepo.GetRandomCardAsync();
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
