using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsonToTable.Models
{
    public class Item : BaseItem
    {
        public Item()
        {
            Toppings = new List<BaseItem>();
        }

        public string Name { get; set; }

        public string Ppu { get; set; }

        public Batters Batters { get; set; }

        [JsonProperty("topping")]
        public List<BaseItem> Toppings { get; private set; }
    }
}
