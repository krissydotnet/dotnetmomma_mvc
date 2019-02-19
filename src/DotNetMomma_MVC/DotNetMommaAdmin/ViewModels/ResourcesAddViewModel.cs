using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetMommaShared.Data;

namespace DotNetMommaAdmin.ViewModels
{
    public class ResourcesAddViewModel 
        : ResourcesBaseViewModel
    {
        public ResourcesAddViewModel()
        {

        }

        public override void Init(Repository repository, SectionsRepository sectionsRepository)
        {
            base.Init(repository, sectionsRepository);
            
        }
    }
}