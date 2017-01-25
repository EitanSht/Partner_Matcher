using System.Collections.Generic;
using System.Data;

namespace PartnerMatcher.Controller.Commands
{
    internal interface IAdSearch : ICommand
    {
        List<string> getFields();

        List<string> getAreas();

        DataTable searchResultsByField(string fieldName);

        DataTable searchResultsByCriteria(string fieldName, params string[] criterias);
    }
}