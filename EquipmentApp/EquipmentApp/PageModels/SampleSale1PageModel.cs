using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EquipmentApp.PageModels
{
    public class SampleSale1PageModel : FreshBasePageModel
    {
        public ObservableCollection<Card> ListDetails { get; set; }
        public SampleSale1PageModel()
        {
            ListDetails = new ObservableCollection<Card>
            {
                new Card
                {
                    ImgIcon= "home.png",
                    Name = "Royal Store"
                },
                 new Card
                {
                    ImgIcon= "home.png",
                    Name = "Oregon store"
                },
                  new Card
                {
                    ImgIcon= "home.png",
                    Name = "Preston Store"
                },
                   new Card
                {
                    ImgIcon= "home.png",
                    Name = "Martin Store"
                },
                     new Card
                {
                    ImgIcon= "home.png",
                    Name = "Ravenclaw Store"
                }
            };
        }
    }

    public class Card
    {
        public string ImgIcon { get; set; }
        public string Name { get; set; }
    }
}
