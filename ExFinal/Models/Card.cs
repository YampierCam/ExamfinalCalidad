namespace ExamFinal.Models
{
    public class Card
    {
        public int IdCard { get; set; }
        public int Number { get; set; }
        public string Categoria { get; set; }

        public int IdJugador { get; set; }

        public Card(int idCard, int number, string categoria, int IdJugador)
        {
            IdCard = idCard;
            Number = number;
            this.Categoria = categoria;
            IdJugador = IdJugador;
        }

        public Card()
        {
        }
    }
}