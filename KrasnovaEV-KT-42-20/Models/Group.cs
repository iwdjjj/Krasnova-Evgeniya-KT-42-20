using System.Text.RegularExpressions;

namespace KrasnovaEV_KT_42_20.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public int? StudentQuantity { get; set; }
        public bool IsDeleted { get; set; }

        public bool IsValidGroupName()
        {
            return Regex.Match(GroupName, @"\D*-\d*-\d\d").Success;
        }
    }
}
