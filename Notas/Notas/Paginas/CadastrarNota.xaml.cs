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
	public partial class CadastrarNota : ContentPage
	{
		public CadastrarNota ()
		{
			InitializeComponent ();
		}

        public void SalvarAction(object sender, EventArgs args)
        {
            //TODO - Criar validaçõe
            Nota nota = new Nota();
            nota.Titulo = Titulo.Text;
            nota.Descricao = Descricao.Text;


            if (isValid(nota.Titulo))
            {

                Database database = new Database();
                database.Cadastro(nota);

                App.Current.MainPage = new NavigationPage(new ConsultarNotas());

            }
           
        }

        private bool isValid(string text)
        {
            if(! string.IsNullOrEmpty(text))
            {
                text = text.Trim();
            }
            if(string.IsNullOrEmpty(text))
            {
                DisplayAlert("ERRO","Cadastre um título para a nota", "OK");
                return false;
            }
            return true;
        }
	}
}