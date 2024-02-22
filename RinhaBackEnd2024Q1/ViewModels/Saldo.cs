namespace RinhaBackEnd2024Q1.ViewModels
{
    public class Saldo
    {
        public int total { get; set; }
        public DateTime data_extrato => DateTime.Now;
        public int limite { get; set; }

    }
}
