using System;
using System.Collections.Generic;

namespace Livro{
    class Livro {
        private string titulo;
        private string autor;
        private int numPags;
        private string editora;
        private List<string> generos;

        public Livro(string titulo, string autor, int numPags, string editora){
            this.titulo = titulo;
            this.autor = autor;
            this.numPags = numPags;
            this.editora = editora;
            generos = new List<string>();
        }


        //Gets
        public string getTitulo(){
            return titulo;
        }

        public string getAutor(){
            return autor;
        }
        public int getNumPags(){
            return numPags;
        }
        public string getEditora(){
            return editora;
        }
        public List<string> getGeneros(){
            return generos;
        }

        //Methods
        public void addGenero(string genero){
            generos.Add(genero);
        }

        public override string ToString(){
            string genero = "";
            foreach(string g in generos){
                genero += $"{g}, ";
            }
            return $"{titulo}, actually has {genero}genders, and has been written by {autor}, has {numPags} pages and curently is published by the {editora}.";
        }
    }

    class LivroLivraria : Livro{
        private double preco;

        public LivroLivraria(string titulo, string autor, int numPags, string editora, double preco):base(titulo, autor, numPags, editora){
            this.preco = preco;
        }


        public double getPreco(){
            return preco;
        }

        public override string ToString(){
            string genero = "";
            foreach (string g in getGeneros()){
                genero += $"{g}, ";
            }
            return $"{getTitulo()}, actually has {genero}genders, and has been written by {getAutor()}, has {getNumPags()} pages and curently is published by the {getEditora()}. This book costs {preco}R$.";
        }

    }

    class LivroBiblioteca : Livro{
        private DateTime dataEmprestimo;
        private DateTime dataDevolucao;

        public LivroBiblioteca(string titulo, string autor, int numPags, string editora, DateTime dataEmprestimo, DateTime dataDevolucao) : base(titulo, autor, numPags, editora){
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
        }

        public DateTime getDataEmprestimo(){
            return dataEmprestimo;
        }

        public DateTime getDataDevolucao(){
            return dataDevolucao;
        }

        //Methods
        public TimeSpan diasRestantesDevolucao(){
            TimeSpan restanteDevolucao = dataDevolucao.Subtract(DateTime.Now);
            return restanteDevolucao;
        }

        public double calcMultaPorDiasAtrasados(double multaPorDia){
            TimeSpan diasAtrasados = diasRestantesDevolucao();
            if(diasAtrasados.Days < 0){
                return diasAtrasados.Days * multaPorDia;
            }
            return 0;
        }

    }


    class Program{
        static void Main(string[] args){
            LivroBiblioteca sombra = new LivroBiblioteca("A Sombra do Vento", "Carlos Ruiz Záfon", 320, "Jambo", new DateTime(2022, 9, 10), new DateTime(2022, 9, 30));
            sombra.addGenero("Romance");
            sombra.addGenero("Mistério");
            sombra.addGenero("Investigação");
            Console.WriteLine($"{sombra.diasRestantesDevolucao().Days} dias restantes");
            Console.WriteLine($"Multa de: {sombra.calcMultaPorDiasAtrasados(20.5)} R$");


            Console.ReadKey();
        }
    }
}
