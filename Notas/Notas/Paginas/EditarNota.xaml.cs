﻿using Notas.Banco;
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
	public partial class EditarNota : ContentPage
	{
        private Nota nota { get; set; }
		public EditarNota (Nota nota)
		{
			InitializeComponent ();
            this.nota = nota;

            Titulo.Text = nota.Titulo;
            Descricao.Text = nota.Descricao;

		}

        public void SalvarAction(object sender, EventArgs args)
        {

            nota.Titulo = Titulo.Text;
            nota.Descricao = Descricao.Text;

            Database database = new Database();
            database.Atualizacao(nota);

            App.Current.MainPage = new NavigationPage(new MinhasNotasCadastradas());
        }
    }
}