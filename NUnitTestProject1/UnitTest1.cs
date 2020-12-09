using NUnit.Framework;

namespace NUnitTestProject1
{
    public class Tests
    {
        [Test]
        public void GanarCon50puntosJuan()
        {

            List<string> a = new List<string>();
            var userMock = new Mock<IUsuarioService>();


            var baraja = new List<Carta>();



            var cartaMock = new Mock<ICartaService>();
            cartaMock.Setup(o => o.AsignarBarajaJugador()).Returns(baraja);
            cartaMock.Setup(o => o.Puntaje(baraja)).Returns(3000);
            List<Usuario> jugadores = new List<Usuario>();
            jugadores.Add(new Usuario(1, "Juan", 500000));
            jugadores.Add(new Usuario(2, "Jorge", 1323123));
            jugadores.Add(new Usuario(3, "Luis", 1323123));
            jugadores.Add(new Usuario(4, "Maria", 1323123));
            jugadores.Add(new Usuario(5, "a", 1323123));

            var cartas = baraja.Where(o => o.Id == 1).ToList();
            cartaMock.Setup(o => o.Puntaje(cartas));
            string Nombre1 = "Juan";
            string Nombre2 = "x";
            string Nombre3 = "y";
            string Nombre4 = "z";
            string Nombre5 = "c";
            List<string> abc = new List<string>();
            List<Usuario> ganador = new List<Usuario>();
            Usuario nuevo = new Usuario();
            nuevo.Id = 1;
            nuevo.Nombre = "maria";
            nuevo.Puntaje = 500000;

            abc.Add(Nombre1); abc.Add(Nombre2); abc.Add(Nombre3); abc.Add(Nombre4); abc.Add(Nombre5);
            userMock.Setup(o => o.JugadorGanador(500000, jugadores)).Returns(ganador);
            userMock.Setup(o => o.JugadoresConPuntaje(baraja, jugadores)).Returns(jugadores);
            userMock.Setup(o => o.Jugadores(abc)).Returns(jugadores);
            cartaMock.Setup(o => o.Puntajemaximo(jugadores)).Returns(500000);


            JuegoDePokerController jugegoPoker = new JuegoDePokerController(cartaMock.Object, userMock.Object);
            var ganadores = jugegoPoker.Ganadores(Nombre1, Nombre2, Nombre3, Nombre4, Nombre5);

            ganador.Add(nuevo);

            var ResultadoEsperado = ganador;
            Assert.AreEqual(ResultadoEsperado, ganadores);
        }


        [Test]
        public void GanarCon500puntosJuan()
        {

            List<string> a = new List<string>();
            var userMock = new Mock<IUsuarioService>();


            var baraja = new List<Carta>();



            var cartaMock = new Mock<ICartaService>();
            cartaMock.Setup(o => o.AsignarBarajaJugador()).Returns(baraja);
            cartaMock.Setup(o => o.Puntaje(baraja)).Returns(3000);
            List<Usuario> jugadores = new List<Usuario>();
            jugadores.Add(new Usuario(1, "Juan", 500));
            jugadores.Add(new Usuario(2, "Jorge", 1));
            jugadores.Add(new Usuario(3, "Luis", 1));
            jugadores.Add(new Usuario(4, "Maria", 1));
            jugadores.Add(new Usuario(5, "a", 1));

            var cartas = baraja.Where(o => o.Id == 1).ToList();
            cartaMock.Setup(o => o.Puntaje(cartas));
            string Nombre1 = "Juan";
            string Nombre2 = "x";
            string Nombre3 = "y";
            string Nombre4 = "z";
            string Nombre5 = "c";
            List<string> abc = new List<string>();
            List<Usuario> ganador = new List<Usuario>();
            Usuario nuevo = new Usuario();
            nuevo.Id = 1;
            nuevo.Nombre = "maria";
            nuevo.Puntaje = 500000;

            abc.Add(Nombre1); abc.Add(Nombre2); abc.Add(Nombre3); abc.Add(Nombre4); abc.Add(Nombre5);
            userMock.Setup(o => o.JugadorGanador(500000, jugadores)).Returns(ganador);
            userMock.Setup(o => o.JugadoresConPuntaje(baraja, jugadores)).Returns(jugadores);
            userMock.Setup(o => o.Jugadores(abc)).Returns(jugadores);
            cartaMock.Setup(o => o.Puntajemaximo(jugadores)).Returns(500000);


            JuegoDePokerController jugegoPoker = new JuegoDePokerController(cartaMock.Object, userMock.Object);
            var ganadores = jugegoPoker.Ganadores(Nombre1, Nombre2, Nombre3, Nombre4, Nombre5);

            ganador.Add(nuevo);

            var ResultadoEsperado = ganador;
            Assert.AreEqual(ResultadoEsperado, ganadores);
        }
    }
}