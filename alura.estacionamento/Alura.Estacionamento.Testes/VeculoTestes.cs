using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeculoTestes
    {
        [Fact(DisplayName ="Teste n� 1")]
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
        [Fact(DisplayName ="Teste n� 2")]
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

        [Fact(DisplayName="Teste N� 3", Skip = "Teste ainda n�o implementado")]
        public void ValidaNomeProprietario()
        {

        }
    }
}