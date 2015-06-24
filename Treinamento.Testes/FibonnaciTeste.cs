using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Treinamento.Testes
{
    [TestClass]
    public class FibonnaciTeste
    {
        [TestMethod]
        public void OPrimeiroElementoDaSequenciaDeveSer0()
        {
            Assert.AreEqual(0, Fibonnaci.Elemento(0));
        }

        [TestMethod]
        public void OSegundoElementoDaSequenciaDeveSer1()
        {
            Assert.AreEqual(1, Fibonnaci.Elemento(2));
        }

        [TestMethod]
        public void OOitavoElementoDaSequenciaDeveSer13()
        {
            Assert.AreEqual(13, Fibonnaci.Elemento(7));
        }

        [TestMethod]
        public void OQuartoElementoDaSequenciaDeveSer2()
        {
            Assert.AreEqual(2, Fibonnaci.Elemento(3));
        }
    }

    public static class Fibonnaci
    {
        public static int Elemento(int posicao)
        {
            if (posicao == 0) return 0;
            if (posicao == 1) return 1;
            return Elemento(posicao - 2) + Elemento(posicao - 1);
        }
    }
}
