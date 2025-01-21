namespace Hilos;

    public class MiHilo<T> where T : struct
    {
        private Thread hilo;
        private string text;
        private RefWrapper<T> valor;
        
        // Evento a nivel de instancia en lugar de estático
        public event Action OnComplete;

        public MiHilo(string text, RefWrapper<T> valor)
        {
            this.text = text;
            this.valor = valor;
            hilo = new Thread(_process);
        }

        public void Start()
        {
            hilo.Start();
        }

        private void _process()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(text);
                // Aquí puedes manipular valor.Value según necesites
            }
            
            // Notificar finalización usando el evento de instancia
            OnComplete?.Invoke();
            Console.WriteLine($"Ha terminado: {text}");
        }

        public void Join()
        {
            hilo.Join();
        }
    }
