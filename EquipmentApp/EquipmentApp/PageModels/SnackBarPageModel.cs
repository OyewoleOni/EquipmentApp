using EquipmentApp.Models;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentApp.PageModels
{
    public class SnackBarPageModel : FreshBasePageModel
    {

        public SnackBarPageModel()
        {

        }

        public override void Init(object initData)
        {
            base.Init(initData);
            User = (User)initData;
        }

        private string _name = "test";

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private User _user;

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

    }
}
