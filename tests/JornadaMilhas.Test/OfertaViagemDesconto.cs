using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test
{
    public class OfertaViagemDesconto
    {
        [Fact]
        public void RetornaPrecoAutalizadoQuandoAplicadoDesconto() {

            Rota rota = new Rota("São Paulo", "Rio de Janeiro");
            Periodo periodo = new Periodo(new DateTime(2023, 10, 1), new DateTime(2023, 10, 10));
            double precoOriginal = 100.00;
            double desconto = 20.00;
            double precoComDesconto = precoOriginal - desconto;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            oferta.Desconto = desconto;


            Assert.Equal(precoComDesconto, oferta.Preco);
        }

        [Fact]
        public void RetornaDescontoMaximoQuandoValorDescontoMaiorQuePreco()
        {

            Rota rota = new Rota("São Paulo", "Rio de Janeiro");
            Periodo periodo = new Periodo(new DateTime(2023, 10, 1), new DateTime(2023, 10, 10));
            double precoOriginal = 100.00;
            double desconto = 120.00;
            double precoComDesconto = 30.00;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);

            oferta.Desconto = desconto;


            Assert.Equal(precoComDesconto, oferta.Preco);
        }

        [Fact]
        public void RetornaTresErrosDeValidacaoQuandoRotaPeriodoEPRecoSaoInvalidos()
        {
            //arrange
            int quantidadeEsperada = 3;
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 6, 1), new DateTime(2024, 5, 10));
            double preco = -100;

            //act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //assert
            Assert.Equal(quantidadeEsperada, oferta.Erros.Count());
        }
    }
}
