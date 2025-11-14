using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Domain;


namespace Modelo.Application.Interface
{
    public interface IAlunoApplication
    {
        Task<Aluno?> BuscarAluno(int id);
        void AdicionarAluno(Aluno aluno);
    }
}
