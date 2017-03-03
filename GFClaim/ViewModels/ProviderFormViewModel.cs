using GFClaim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GFClaim.ViewModels
{
    // 这class是为了ProvidersController ->ProviderFormView用的，因为Provider class里有ProviderType的List需要在view里显示，
    // 仅仅传去一个Provider还不行，需要把List of ProviderType也传过去，供下拉combobox选择用,
    public class ProviderFormViewModel
    {
        public IEnumerable<ProviderType> ProviderTypes { get; set; }
        public Provider Provider { get; set; }

        // 这方法会在view里调用，以便在New/Edit时显示不同的内容
        public string ProviderFormTitle()
        {
            if (Provider.Name == null)
                return "New Provider";
            return "Edit " + Provider.Name;
        }
    }
}