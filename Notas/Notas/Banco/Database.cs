using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Notas.Modelos;
using Xamarin.Forms;
using System.Linq;

namespace Notas.Banco
{
    class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Nota>();
        }

        public List<Nota> Consultar()
        {
           return  _conexao.Table<Nota>().Reverse().ToList();  
        }

        public List<Nota> Pesquisar(string palavra)
        {
            return _conexao.Table<Nota>().Where(a => a.Titulo == palavra).Reverse().ToList();
        }

        public Nota ObterNotaPorId(int id)
        {
            return _conexao.Table<Nota>().Where(a=>a.Id == id).FirstOrDefault();
        }

        public void Cadastro(Nota nota)
        {
            _conexao.Insert(nota);
        }

        public void Atualizacao(Nota nota)
        {
            _conexao.Update(nota);
        }

        public void Exclusao(Nota nota)
        {
            _conexao.Delete(nota);
        }
    }
}
