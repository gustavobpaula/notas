using Notas.Banco;
using Notas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultarNotas : ContentPage
	{
        List<Nota> Lista { get; set; }

		public ConsultarNotas ()
		{
			InitializeComponent ();

            Database database = new Database();
            Lista = database.Consultar();
            ListaNotas.ItemsSource = Lista;

            lblCount.Text = Lista.Count.ToString();

		}

        public void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastrarNota());
        }

        public void GoGerenciar(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MinhasNotasCadastradas());
        }

        public void MaisDetalheAction(object sender, EventArgs args)
        {
            Label lblDetalhe = (Label)sender;
            Nota nota = ((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]).CommandParameter as Nota;

            Navigation.PushAsync(new DetalharNota(nota));
        }

        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            var listaFiltrada = Lista.Where(a => a.Titulo.ToUpper().Contains(args.NewTextValue.ToUpper())).ToList();
            ListaNotas.ItemsSource = listaFiltrada;
            lblCount.Text = listaFiltrada.Count.ToString();
        }
	}
}