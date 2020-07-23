using System;

namespace SiteCalculator.Services.Models.ValueObjects
{
    public class Percent
    {
        private decimal _percent;
        public Percent(decimal percent)
        {
            Value = percent;
        }
        
        public decimal Value
        {
            get => _percent;
            private set
            {
                if (value <= 0 || value>100) throw new ArgumentOutOfRangeException(nameof(value));
                _percent = value / 100;
            }
        }

        public override string ToString()
        {
            return $"{Value*100}%";
        }

        public static decimal operator *(Percent a , decimal b) => a.Value * b;
        public static decimal operator *(decimal a , Percent b) => a * b.Value;
        
        public static decimal operator /(Percent a , decimal b) => a.Value / b;
        public static decimal operator /(decimal a , Percent b) => a / b.Value;
       
    }
}