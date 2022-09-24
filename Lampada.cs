using System;

namespace Lampada{

    class Lampada{
        private string marca;
        private int voltagem;
        private string cor;
        private bool estado;

        public Lampada(string marca, int voltagem, string cor){
            this.marca = marca;
            this.voltagem = voltagem;
            this.cor = cor;
            this.estado = false;
        }



        // gets
        public string getMarca(){
            return marca;
        }

        public int getVoltagem(){
            return voltagem;
        }

        public string getCor(){
            return cor;
        }

        public bool isOn(){
            return estado == true ? true : false;
        }

        // Methods
        public void turnOn(){
            estado = true;
        }

        public void turnOff(){
            estado = false;
        }

        public override string ToString(){
            string ligada = estado == true ? $"Ligada" : $"Desligada";
            return $"Marca: {marca}\nVoltagem: {voltagem}W\nCor: {cor}\nEstado atual: {ligada}";
        }

    }

    class LampadaTresEstado : Lampada{
        private string estado;

        public LampadaTresEstado(string marca, int voltagem, string cor):base(marca, voltagem, cor){
            this.estado = "desligado";
        }

        //Gets
        public string getEstado(){
            return estado;
        }

        //Methods
        public void turnOn(){
            estado = "Ligado";
        }

        public void turnOff(){
            estado = "Desligado";
        }

        public void turnHalfLight(){
            estado = "Meia Luz";
        }

        public bool isOn(){
            if(estado == "Ligado" || estado == "Meia Luz"){
                return true;
            }
            return false;
        }

    }



    class Program{

        static void Main(string[] args){
            LampadaTresEstado nova = new LampadaTresEstado("Led", 210, "Red");
            nova.turnOff();
            Console.WriteLine(nova.getEstado());
            Console.WriteLine(nova.isOn());

            Console.ReadLine();
        }
    }
}
