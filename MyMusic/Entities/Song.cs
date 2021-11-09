using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Entities
{
    public class Song
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string singer { get; set; }
        public string author { get; set; }
        public string thumbnail { get; set; }
        public string message { get; set; }
        public string link { get; set; }
        public override string ToString()
        {
            return $"ID{id} ,Name{ name},Description{description} , Singer{singer},Author{author}," +
                $"Thumbnail{thumbnail},Message{message},Link{link}";
        }

    }
}
