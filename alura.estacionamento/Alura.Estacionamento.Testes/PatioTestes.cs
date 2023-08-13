using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes: IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor invocado");
            veiculo = new Veiculo();
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoCom1Veiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Michael Scott";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "abc-1234";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Jim Halpert", "ASD-1498", "Preto", "Gol")]
        [InlineData("Pam Beesly", "POL-9242", "Cinza", "Fusca")]
        [InlineData("Dwight Schrute", "GDR-0202", "Azul", "Opala")]
        [InlineData("Michael Scott", "BOS-0001", "Vermelho", "Twigo")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario,
                                                       string placa,
                                                       string cor,
                                                       string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            // var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Jim Halpert", "ASD-1498", "Preto", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNaPlaca(string proprietario,
                                                       string placa,
                                                       string cor,
                                                       string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
           // var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesqueisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);

        }

        [Fact(Skip = "Teste com erro de referencia")]
        public void AlterarDadosDoProprioVeiculo()
        {
            //Arrange
            Patio estacionamento = new Patio();
           // var veiculo = new Veiculo();
            veiculo.Proprietario = "Michael Scott";
            veiculo.Placa = "abc-1234";
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Fusca";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Michael Scott";
            veiculo.Placa = "abc-1234";
            veiculo.Cor = "Preto"; //Alterado
            veiculo.Modelo = "Fusca";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose invocado");
        }
    }
}

