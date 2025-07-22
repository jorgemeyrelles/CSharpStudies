using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissaoEspacial {
    public class Utils {
        public string CriarId() {
            Random rand = new Random();
            return rand.Next(100000, 1000000).ToString();
        }
    }
}
