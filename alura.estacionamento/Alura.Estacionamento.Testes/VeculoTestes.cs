using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeculoTestes
    {
        [Fact(DisplayName ="Teste nº 1")]
        [Trait("Funcionalidade","Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange 
            var veiculo = new Veiculo();
           
            //Act
            veiculo.Acelerar(10);
            
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }
        [Fact(DisplayName ="Teste nº 2")]
        [Trait("Funcionalidade","Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();
           
            //Act
            veiculo.Frear(10);
            
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName="Teste Nº 3", Skip = "Teste ainda não implementado")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            var carro = new Veiculo();
            carro.Proprietario = "Michael Scott";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Placa = "BOS-0001";
            carro.Cor = "Vermelho";
            carro.Modelo = "Variante";

            //Act
            string dados = carro.ToString();

            //Assert
            Assert.Contains("Ficha do Veiculo:", dados);
        }
    }
}