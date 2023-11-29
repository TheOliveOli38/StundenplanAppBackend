using Microsoft.EntityFrameworkCore;
using StundenplanApp.Data;
using StundenplanApp.Models;

namespace StundenplanApp.Services
{
    public class FachService : IFachService
    {
        public readonly DataContext dataContext;
        public FachService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<Subjects> createSubject(Subjects newSubject)
        {
            Subjects subject = new Subjects
            {
                Name = newSubject.Name,
                Raum = newSubject.Raum,
                Lehrkraft = newSubject.Lehrkraft,
            };
            await dataContext.Faecher.AddAsync(subject);
            await dataContext.SaveChangesAsync();
            return subject;
        }
        public async Task<Subjects> getSubject(int subjectID)
        {
            Subjects subject = await dataContext.Faecher.FirstOrDefaultAsync(s => s.ID == subjectID);
            return subject;
        }
        public async Task<Subjects> editSubject(Subjects subjectToEdit)
        {
            Subjects subject = await dataContext.Faecher.FirstOrDefaultAsync(s => s.ID == subjectToEdit.ID);
            subject.Name = subjectToEdit.Name;
            subject.Raum = subjectToEdit.Raum;
            subject.Lehrkraft = subjectToEdit.Lehrkraft;
            dataContext.Faecher.Update(subject);
            dataContext.SaveChangesAsync();
            return subject;
        }
        public async Task<Subjects> deleteSubject(int subjectID)
        {
            Subjects subject = await dataContext.Faecher.FirstOrDefaultAsync(s => s.ID == subjectID);
            dataContext.Faecher.Remove(subject);
            dataContext.SaveChangesAsync();
            return subject;
        }
    }
}
