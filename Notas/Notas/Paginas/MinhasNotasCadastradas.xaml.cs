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
	public partial class MinhasNotasCadastradas : ContentPage
	{
        List<Nota> Lista { get; set; }

		public MinhasNotasCadastradas ()
		{
			InitializeComponent ();

            ConsultarNotas();
            
        }

        private void ConsultarNotas()
        {
            Database database = new Database();
            Lista = database.Consultar();
            ListaNotas.ItemsSource = Lista;

            lblCount.Text = Lista.Count.ToString();
        }

        public void EditarAction(object sender, EventArgs args)
        {
            Label lblEditar = (Label)sender;
            Nota nota = ((TapGestureRecognizer)lblEditar.GestureRecognizers[0]).CommandParameter as Nota;

            Navigation.PushAsync(new EditarNota(nota));
        }

        public void ExcluirAction(object sender, EventArgs args)
        {
            Label lblExcluir = (Label)sender;
            Nota nota = ((TapGestureRecognizer)lblExcluir.GestureRecognizers[0]).CommandParameter as Nota;

            Database database = new Database();
            database.Exclusao(nota);
            ConsultarNotas();
        }

        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            var listaFiltrada = Lista.Where(a => a.Titulo.Contains(args.NewTextValue)).ToList();
            ListaNotas.ItemsSource = listaFiltrada;
            lblCount.Text = listaFiltrada.Count.ToString();
        }
    }
}