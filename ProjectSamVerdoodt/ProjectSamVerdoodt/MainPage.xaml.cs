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

namespace ProjectSamVerdoodt
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            TestRepository();
        }

        private async Task TestRepository()
        {
            YuGiOhCard card = await APIRepo.GetRandomCardAsync();
            Debug.Write($"Id card: {card.CardId}");
        }
    }
}
