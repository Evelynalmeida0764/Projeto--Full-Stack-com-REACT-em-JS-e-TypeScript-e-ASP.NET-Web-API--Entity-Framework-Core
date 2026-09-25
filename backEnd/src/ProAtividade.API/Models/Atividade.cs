namespace ProAtividade.API.Controllers
{
    public class Atividade
    {
        public Atividade(){}

        public Atividade(int id)
        {
            Id=id;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        
    }

}