using StundenplanApp.Models;

namespace StundenplanApp.Services
{
    public interface IFachService
    {
        public Task<Subjects> createSubject(Subjects newSubject);
        public Task<Subjects> getSubject(int subjectID);
        public Task<Subjects> editSubject(Subjects subjectToEdit);
        public Task<Subjects> deleteSubject(int subjectID);
    }
}
