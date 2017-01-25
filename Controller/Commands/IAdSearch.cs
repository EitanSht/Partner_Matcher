using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerMatcher.Controller.Commands
{
    interface IAdSearch : ICommand
    {
        List<string> getFields();
        List<string> getAreas();
        DataTable searchResultsByField(string fieldName);
        DataTable searchResultsByCriteria(string fieldName, params string[] criterias);
    }
}
