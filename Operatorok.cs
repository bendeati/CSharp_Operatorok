using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdc_Operatorok
{
    class Operatorok
    {
        private int elso;
        private string op;
        private int masodik;

        public int Elso { get => elso; set => elso = value; }
        public string Op { get => op; set => op = value; }
        public int Masodik { get => masodik; set => masodik = value; }

        public Operatorok(string sor)
        {
            String[] d = sor.Split(' ');
            this.elso = Convert.ToInt32(d[0]);
            this.op = d[1];
            this.masodik = Convert.ToInt32(d[2]);
        }

        public string szamol()
        {
            String kiir = "";
            try
            {
                switch (op)
                {
                    case "+": kiir = (elso + masodik).ToString(); break;
                    case "-": kiir = (elso - masodik).ToString(); break;
                    case "*": kiir = (elso * masodik).ToString(); break;
                    case "/": kiir = ((double)elso / masodik).ToString(); break;
                    case "div": kiir = (elso / masodik).ToString(); break;
                    case "mod": kiir = (elso % masodik).ToString(); break;
                    default: kiir = "Hibás operátor!"; break;
                }
            }
            catch (Exception hibacska)
            {
                kiir = "Egyéb hiba: " + hibacska;
            }
            return kiir;
        }
    }
}
