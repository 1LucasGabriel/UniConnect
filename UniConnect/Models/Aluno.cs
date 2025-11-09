namespace UniConnect.Models
{
    public class Aluno: Usuario
    {
        public string RA { get; set; }

        public Aluno(int id, string name, string email, string password, string ra)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.RA = ra;
        }
    }
}
