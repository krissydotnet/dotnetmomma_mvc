using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetMommaAdmin.ViewModels
{
    public class ResourcesEditViewModel
        : ResourcesBaseViewModel
    {

        public int Id
        {
            get { return Resource.Id; }
            set { Resource.Id = value; }
        }

    }
}