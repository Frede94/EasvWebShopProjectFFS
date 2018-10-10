using System;

namespace Easv.WebShop.Core.Entity
{
    public class Whiskey
    {
        public int Id { get; set; }
        public string WhiskeyName { get; set; }
        public WhiskeyType WhiskeyType  { get; set; }
        public string imgURL { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
