using System.Collections.Generic;

namespace JsonToTable.Models
{
    public class Batters
    {
        public Batters()
        {
            Batter = new List<BaseItem>();
        }

        public List<BaseItem> Batter { get; private set; }
    }
}
