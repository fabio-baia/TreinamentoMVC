using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Treinamento.Testes
{
    [TestClass]
    public class PluralTeste
    {
        [TestMethod]
        public void PluralDeveAcrescentarLetraSNoFinal()
        {
            Assert.AreEqual("palavras", "palavra".ToPlural(5));
        }

        [TestMethod]
        public void PluralExisteDeveRetornarExistem()
        {
            Assert.AreEqual("existem", "existe".ToPlural(4));
        }

        [TestMethod]
        public void DoisTresSeisDezNaoTemPlural()
        {
            Assert.AreEqual("item", "item".ToPlural(2));
        }

        [TestMethod]
        public void PalavraTerminadaEmMDeveTerminarComLetrasNeS()
        {
            Assert.AreEqual("itens", "item".ToPlural(5));
        }

        [TestMethod]
        public void PalavraTerminadaEmRouZDeveTerminarComLetrasES()
        {
            Assert.AreEqual("vezes", "vez".ToPlural(5));
            Assert.AreEqual("pares", "par".ToPlural(5));
        }

        [TestMethod]
        public void PalavraMalRetornaMales()
        {
            Assert.AreEqual("males", "mal".ToPlural(5));
        }

        [TestMethod]
        public void PalavraTerminadaComAlOuUlSubstituiLPorIs()
        {
            Assert.AreEqual("sais", "sal".ToPlural(5));
            Assert.AreEqual("azuis", "azul".ToPlural(5));
        }

        [TestMethod]
        public void PalavraTerminadaComElSubstituiLPorEis()
        {
            Assert.AreEqual("paineis", "painel".ToPlural(5));
        }


        //al ou ul troca L por IS
    }

    public static class StringHelper
    {
        public static string ToPlural(this string input, int count = 2)
        {
            switch (count)
            {
                case 2:
                case 3:
                case 6:
                case 10:
                    return input;
                default:
                {
                    if (input == "existe")
                        return "existem";
                    if (input == "mal")
                        return "males";
                    if (input.EndsWith("m"))
                        return input.Replace("m", "ns");
                    if (input.EndsWith("z"))
                        return input+"es";
                    if (input.EndsWith("r"))
                        return input+"es";
                    if (input.EndsWith("al") || input.EndsWith("ul"))
                        return input.Replace("l", "is");
                    if (input.EndsWith("el"))
                        return input.Replace("l", "is");
                    return input + "s";
                }
            }
        }
    }
}
