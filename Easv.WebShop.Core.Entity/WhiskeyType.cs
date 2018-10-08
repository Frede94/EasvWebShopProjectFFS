using System.Collections.Generic;

namespace Easv.WebShop.Core.Entity
{
    public class WhiskeyType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public List<Whiskey> ListOfWhiskeys { get; set; }
    }
}