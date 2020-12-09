using System;
using System.Collections.Generic;
using System.Linq;
using ExamFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamFinal.Controllers
{
    public class ExamFinalController : Controller

    {



        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Ejecucion(string a, string b, string c, string d, string e)
        {
            List<string> nueva = new List<string>();
            nueva.Add(a); nueva.Add(b); nueva.Add(c); nueva.Add(d); nueva.Add(e);

            List<Jugador> player = new List<Jugador>();
            int conta = 0;
            for (int i = 1; i < 6; i++)
            {
                Jugador Newjugardor = new Jugador();
                Newjugardor.IdJugador = i;
                Newjugardor.NombreJugador = nueva[conta];

                player.Add(Newjugardor);

                conta++;
            }
            List<Card> Casino = new List<Card>();
            List<string> tipoDeCarta = new List<string>();
            tipoDeCarta.Add("corazones");
            tipoDeCarta.Add("cocos");
            tipoDeCarta.Add("espadas");
            tipoDeCarta.Add("flores");

            int variable1 = 1, variable2 = 0;
            for (int i = 1; i < 53; i++)
            {
                Card NewCard = new Card();

                if (variable1 > 13)
                {
                    variable2++;
                    variable1 = 1;
                }

                NewCard.IdJugador = i;
                NewCard.Number = variable1;
                NewCard.Categoria = tipoDeCarta[variable2];
                variable1++;
                Casino.Add(NewCard);
            }


            List<int> indices = new List<int>();
            Random aleatorio = new Random();
            int contador1 = 0;


            for (int i = 1; i < 6; i++)
            {
                do
                {
                    var ale = aleatorio.Next(0, 52);
                    if (!indices.Contains(ale))
                    {
                        indices.Add(ale);
                        Casino[ale].IdJugador = i;
                        contador1++;
                    }
                } while (contador1 < 5);

                contador1 = 0;
            }
            var palyer1 = Casino.Where(o => o.IdJugador == 1).ToList();
            var palyer2 = Casino.Where(o => o.IdJugador == 2).ToList();
            var palyer3 = Casino.Where(o => o.IdJugador == 3).ToList();
            var palyer4 = Casino.Where(o => o.IdJugador == 4).ToList();
            var palyer5 = Casino.Where(o => o.IdJugador == 5).ToList();
            ViewBag.Player1 = palyer1;
            ViewBag.Player2 = palyer2;
            ViewBag.Player3 = palyer3;
            ViewBag.Player4 = palyer4;
            ViewBag.Player5 = palyer5;
            player[0].Score = Score(palyer1);
            player[1].Score = Score(palyer2);
            player[2].Score = Score(palyer3);
            player[3].Score = Score(palyer4);
            player[4].Score = Score(palyer5);
            int contador = 0;
            var varPuntajeAlto = player.Max(o => o.Score);
            var ganador = player.Where(o => o.Score == varPuntajeAlto).ToList();

            @ViewBag.JugadoresGanadores = ganador;

            @ViewBag.Jugadores = player;
            return View();
        }


        public int Score(List<Card> mano)
        {
            int n1 = 0,
           n2 = 0, n3 = 0, n4 = 0, n5 = 0, n6 = 0, n7 = 0, n8 = 0, n9 = 0,
           n10 = 0, n11 = 0, n12 = 0, n13 = 0, corazones = 0, espadas = 0, cocos = 0, flores = 0,
           escalera = 0, score = 0;

            foreach (var item in mano)
            {
                if (1 == item.Number) { n1++; }
                if (2 == item.Number) { n2++; }
                if (3 == item.Number) { n3++; }
                if (4 == item.Number) { n4++; }
                if (5 == item.Number) { n5++; }
                if (6 == item.Number) { n6++; }
                if (7 == item.Number) { n7++; }
                if (8 == item.Number) { n8++; }
                if (9 == item.Number) { n9++; }
                if (10 == item.Number) { n10++; }
                if (11 == item.Number) { n11++; }
                if (12 == item.Number) { n12++; }
                if (13 == item.Number) { n13++; }
                if ("corazones" == item.Categoria) { corazones++; }
                if ("cocos" == item.Categoria) { cocos++; }
                if ("espadas" == item.Categoria) { espadas++; }
                if ("flores" == item.Categoria) { flores++; }
            }
            if ((n1 == 1 && n2 == 1 && n3 == 1 && n4 == 1 && n5 == 1) || (n2 == 1 && n3 == 1 && n4 == 1 && n5 == 1 && n6 == 1)
                || (n3 == 1 && n4 == 1 && n5 == 1 && n6 == 1 && n7 == 1) || (n4 == 1 && n5 == 1 && n6 == 1 && n7 == 1 && n8 == 1)
                || (n5 == 1 && n6 == 1 && n7 == 1 && n8 == 1 && n9 == 1) || (n6 == 1 && n7 == 1 && n8 == 1 && n9 == 1 && n10 == 1)
                || (n7 == 1 && n8 == 1 && n9 == 1 && n10 == 1 && n11 == 1) || (n8 == 1 && n9 == 1 && n10 == 1 && n11 == 1 && n12 == 1)
                || (n9 == 1 && n10 == 1 && n11 == 1 && n12 == 1 && n13 == 1) || (n9 == 1 && n10 == 1 && n11 == 1 && n12 == 1 && n13 == 1)
                || (n10 == 1 && n11 == 1 && n12 == 1 && n13 == 1 && n1 == 1)) { escalera++; }

            List<VariableConteo> cartasCasino = new List<VariableConteo>();
            VariableConteo carta1 = new VariableConteo(1, n1); cartasCasino.Add(carta1);
            VariableConteo carta2 = new VariableConteo(2, n2); cartasCasino.Add(carta2);
            VariableConteo carta3 = new VariableConteo(3, n3); cartasCasino.Add(carta3);
            VariableConteo carta4 = new VariableConteo(4, n4); cartasCasino.Add(carta4);
            VariableConteo carta5 = new VariableConteo(5, n5); cartasCasino.Add(carta5);
            VariableConteo carta6 = new VariableConteo(6, n6); cartasCasino.Add(carta6);
            VariableConteo carta7 = new VariableConteo(7, n7); cartasCasino.Add(carta7);
            VariableConteo carta8 = new VariableConteo(8, n8); cartasCasino.Add(carta8);
            VariableConteo carta9 = new VariableConteo(9, n9); cartasCasino.Add(carta9);
            VariableConteo carta10 = new VariableConteo(10, n10); cartasCasino.Add(carta10);
            VariableConteo carta11 = new VariableConteo(11, n11); cartasCasino.Add(carta11);
            VariableConteo carta12 = new VariableConteo(12, n12); cartasCasino.Add(carta12);
            VariableConteo carta13 = new VariableConteo(13, n13); cartasCasino.Add(carta13);


            List<VariableConteo> MiMano = new List<VariableConteo>();
            foreach (var item in cartasCasino)
            {
                if (item.Cantidad > 0)
                {
                    MiMano.Add(item);
                }
            }

            int Par = 0, Trio = 0, cuadruple = 0, solas = 0;
            foreach (var item in MiMano)
            {
                if (item.Cantidad == 1) { solas++; }
                if (item.Cantidad == 2) { Par++; }
                if (item.Cantidad == 3) { Trio++; }
                if (item.Cantidad == 4) { cuadruple++; }
            }
            if (escalera == 1)
            {
                if (n1 == 1 && n13 == 1)
                {
                    score += 4500 + MiMano.Max(o => o.IdConteo);
                }
                else
                {
                    score += 4000 + MiMano.Max(o => o.IdConteo);
                }
            }
            if (cocos == 5 || corazones == 5 || flores == 5 || espadas == 5)
            { score += 5000 + MiMano.Max(o => o.IdConteo); }
            if (escalera == 1 && (cocos == 5 || corazones == 5 || flores == 5 || espadas == 5))
            {
                if (n1 == 1 && n13 == 1)
                {
                    score += 500000 + MiMano.Max(o => o.IdConteo);
                }
                score += 50000 + MiMano.Max(o => o.IdConteo);
            }
            if (solas == 5) { score += MiMano.Max(o => o.IdConteo); }
            if (Par == 1 && Trio == 0)
            {
                var carta = MiMano.FirstOrDefault(o => o.Cantidad == 2);
                var cartamayor = MiMano.Where(o => o.Cantidad == 1).ToList();
                var Mayor = cartamayor.Max(o => o.IdConteo);
                if (carta.IdConteo == 1) { score += 1000 + (14 * 15) + Mayor; }
                else { score += 1000 + (carta.IdConteo * 15) + Mayor; }
            }
            if (Par == 2)
            {
                var carta = MiMano.Where(o => o.Cantidad == 2).ToList();
                var CartaMayorDelPar = carta.Max(o => o.IdConteo);
                var cartamayor = MiMano.Where(o => o.Cantidad == 1).ToList();
                var Mayor = cartamayor.Max(o => o.IdConteo);
                if (CartaMayorDelPar == 1)
                {
                    score += 2000 + (14 * 15) + Mayor;
                }
                else
                {
                    score += 2000 + (CartaMayorDelPar * 15) + Mayor;
                }
            }
            if (Par == 0 && Trio == 1)
            {
                var carta = MiMano.Where(o => o.Cantidad == 3).ToList();
                var CartaMayorDelPar = carta.Max(o => o.IdConteo);
                var cartamayor = MiMano.Where(o => o.Cantidad == 1).ToList();
                var Mayor = cartamayor.Max(o => o.IdConteo);
                if (CartaMayorDelPar == 1)
                {
                    score += 3000 + (14 * 15) + Mayor;
                }
                else
                {
                    score += 3000 + (CartaMayorDelPar * 15) + Mayor;
                }
            }
            if (Par == 1 && Trio == 1)
            {
                var carta = MiMano.Where(o => o.Cantidad == 3).ToList();
                var CartaMayorDelPar = carta.Max(o => o.IdConteo);
                var cartamayor = MiMano.Where(o => o.Cantidad == 1).ToList();
                var Mayor = cartamayor.Max(o => o.IdConteo);
                if (CartaMayorDelPar == 1)
                {
                    score += 6000 + (14 * 15) + Mayor;
                }
                else
                {
                    score += 6000 + (CartaMayorDelPar * 15) + Mayor;
                }
            }

            if (cuadruple == 1)
            {
                var carta = MiMano.Where(o => o.Cantidad == 4).ToList();
                var CartaMayorDelPar = carta.Max(o => o.IdConteo);
                var cartamayor = MiMano.Where(o => o.Cantidad == 1).ToList();
                var Mayor = cartamayor.Max(o => o.IdConteo);
                if (CartaMayorDelPar == 1)
                {
                    score += 7000 + (14 * 15) + Mayor;
                }
                else
                {
                    score += 7000 + (CartaMayorDelPar * 15) + Mayor;
                }
            }

            return score;

        }

    }
}