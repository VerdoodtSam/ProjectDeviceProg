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
    public partial class DetailsCard : ContentPage
    {
        public string CurrentCard { get; set; }
        public DetailsCard(string CurrentCardName)
        {
            InitializeComponent();

            CurrentCard = CurrentCardName;
            LoadInfoCard(CurrentCard);
        }
        private async Task LoadInfoCard(string name)
        {
            List<YuGiOhCard> cardInfo = await APIRepo.GetCardInfo(name);
            foreach (YuGiOhCard c in cardInfo)
            {
                DPImg.Source = c.CardImg;
                DPName.Text = "Name: " + c.CardName;
                DPLevel.Text = "Level: " + c.CardLevel;
                DPType.Text = "Type: " + c.CardType;
                DPId.Text = "Id: " + c.CardId;
                DPDesc.Text = c.CardDesc;
                DPAtk.Text = "Atk: " + c.CardAtk;
                DPDeff.Text = "Deff: " + c.CardDef;
                DPRace.Text = "Race: " + c.CardRace;
                DPAttribute.Text = "Attribute: " + c.CardAttri;
                ;
            }
        }
        private void BtnReturn_Clicked(object sender, EventArgs e)
        {

            Navigation.PopAsync();
        }

        private void BtnAddDeck_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeckPage(CurrentCard));
        }
    }
}