using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace kolosC
{
    public enum EnumDostawcy
    {
        Phillips, Samsung,
        Beko, Sony
    }
    public class BlednyNumerNIPException : Exception
    {
        public BlednyNumerNIPException(string message) : base(message) { }
    }
    public class Dostawca
    {
        EnumDostawcy nazwa;
        string panstwo;
        string numerNip;

        public Dostawca(EnumDostawcy nazwa, string panstwo, string numerNip)
        {
            this.nazwa = nazwa;
            this.panstwo = panstwo;
            this.NumerNip = numerNip;
        }

        public string NumerNip
        {
            get => numerNip;
            set
            {
                string format = @"^\d{11}$";
                if(Regex.IsMatch(value, format))
                {
                    numerNip = value;
                }
                else
                {
                    throw new BlednyNumerNIPException("bledny numer nip");
                }
            }
        }
        public override string ToString()
        {
            return $"\" {this.nazwa.ToString()} \" (NIP: { numerNip: 000-000-00-00} , { panstwo} )";
        }
    }
}
