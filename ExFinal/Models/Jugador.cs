namespace ExamFinal.Models
{
    public class Jugador
    {
        public int IdJugador { get; set; }
        public string NombreJugador { get; set; }
        public int Score { get; set; }



        public Jugador()
        {
        }

        public Jugador(int idJugador, string nombreJugador, int score)
        {
            IdJugador = idJugador;
            NombreJugador = nombreJugador;
            Score = score;
        }
        public Jugador(int idJugador, string nombreJugador)
        {
            IdJugador = idJugador;
            NombreJugador = nombreJugador;

        }
    }
}