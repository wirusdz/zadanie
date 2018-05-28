using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soneta.Examples.Zadanie1.Extander
{
    public class PolaListyComitow
    {
        public char Aktywny { get; set; }
        public string Merge { get; set; }
        public string Branche { get; set; }
        public string Commit { get; set; }
        public string Autor { get; set; }
        public DateTime Data { get; set; }
        public string Opis { get; set; }
        public int Ilosc { get; set; }
    }
    public class PolaListyBranches
    {
        public char Aktywny { get; set; }
        public string Branche { get; set; }
    }
}
