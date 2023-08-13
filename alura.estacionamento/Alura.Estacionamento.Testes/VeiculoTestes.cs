using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor invocado");
            veiculo = new Veiculo();
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange 
            //var veiculo = new Veiculo();
           
            //Act
            veiculo.Acelerar(10);
            
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }
        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
           
            //Act
            veiculo.Frear(10);
            
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda não implementado")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Michael Scott";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "BOS-0001";
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Variante";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veiculo:", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(nomeProprietario) 
                );
        }

        [Fact]
        public void TestaMensagemDeExcessaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "ASDF8888";

            //Act
            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
                );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen",mensagem.Message);
        }


        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose invocado");
        }
    }
}