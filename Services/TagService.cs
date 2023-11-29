using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StundenplanApp.Data;
using StundenplanApp.Models;

namespace StundenplanApp.Services
{
    public class TagService : ITagService
    {
        public readonly DataContext dataContext;
        public TagService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<Days> createDay(Days newDay)
        {
            Days day = new Days
            {
                userID = newDay.userID,
                Tag = newDay.Tag,
                Stunde1 = newDay.Stunde1,
                Stunde2 = newDay.Stunde2,
                Stunde3 = newDay.Stunde3,
                Stunde4 = newDay.Stunde4,
                Stunde5 = newDay.Stunde5,
                Stunde6 = newDay.Stunde6,
                Stunde7 = newDay.Stunde7,
                Stunde8 = newDay.Stunde8,
            };
            if (await dataContext.Tag.FirstOrDefaultAsync(t => t.Tag == newDay.Tag && t.userID == newDay.userID) == null)
            {
                await dataContext.AddAsync(day);
                await dataContext.SaveChangesAsync();
                return day;
            }
            else
            {
                return null;
            }

        }
        public async Task<Days> getDay(int dayID)
        {
            Days day = await dataContext.Tag.FirstOrDefaultAsync(d => d.ID == dayID);
            return day;
        }
        public async Task<Days> deleteDay(int dayID)
        {
            Days day = await dataContext.Tag.FirstOrDefaultAsync(d => d.ID == dayID);
            dataContext.Tag.Remove(day);
            dataContext.SaveChangesAsync();
            return day;
        }
        public async Task<Days> editDay(Days dayToEdit)
        {
            Days day = await dataContext.Tag.FirstOrDefaultAsync(d => d.ID == dayToEdit.ID);
            day.Tag = dayToEdit.Tag;
            day.userID = dayToEdit.userID;
            day.Stunde1 = dayToEdit.Stunde1;
            day.Stunde2 = dayToEdit.Stunde2;
            day.Stunde3 = dayToEdit.Stunde3;
            day.Stunde4 = dayToEdit.Stunde4;
            day.Stunde5 = dayToEdit.Stunde5;
            day.Stunde6 = dayToEdit.Stunde6;
            day.Stunde7 = dayToEdit.Stunde7;
            day.Stunde8 = dayToEdit.Stunde8;
            dataContext.Tag.Update(day);
            await dataContext.SaveChangesAsync();
            return day;
        }
        public async Task<List<Subjects>> getSubjectsByDay(int dayID)
        {
            Days day = await dataContext.Tag.FirstOrDefaultAsync(d => d.ID == dayID);
            List<Subjects> SubjectList = new List<Subjects>();
            SubjectList.Add(await dataContext.Faecher.FirstOrDefaultAsync(s => s.ID == day.Stunde1));
            SubjectList.Add(await dataContext.Faecher.FirstOrDefaultAsync(s => s.ID == day.Stunde2));
            SubjectList.Add(await dataContext.Faecher.FirstOrDefaultAsync(s => s.ID == day.Stunde3));
            SubjectList.Add(await dataContext.Faecher.FirstOrDefaultAsync(s => s.ID == day.Stunde4));
            SubjectList.Add(await dataContext.Faecher.FirstOrDefaultAsync(s => s.ID == day.Stunde5));
            SubjectList.Add(await dataContext.Faecher.FirstOrDefaultAsync(s => s.ID == day.Stunde6));
            if(day.Stunde7 != null)
            {
                SubjectList.Add(await dataContext.Faecher.FirstOrDefaultAsync(s => s.ID == day.Stunde7));
                if(day.Stunde8 != null)
                {
                    SubjectList.Add(await dataContext.Faecher.FirstOrDefaultAsync(s => s.ID == day.Stunde8));
                }
            }
            return SubjectList;
        }
        public async Task<List<Days>> getDaysByUserID(int userID)
        {
            List<Days> DaysList = dataContext.Tag.Where(d => d.userID == userID).ToList();
            DaysList = DaysList.OrderBy(d => d.Tag).ToList();
            return DaysList;
        }
        public async Task<List<Subjects>> getSubjectsByStd(int stdNumber)
        {
            List<int> fachIDs = new List<int>();
            switch(stdNumber) {
                case 1:
                fachIDs = await dataContext.Tag.Select(t => t.Stunde1).ToListAsync();
                    break;
                case 2:
                    fachIDs = await dataContext.Tag.Select(t => t.Stunde2).ToListAsync();
                    break;
                case 3:
                    fachIDs = await dataContext.Tag.Select(t => t.Stunde3).ToListAsync();
                    break;
                case 4:
                    fachIDs = await dataContext.Tag.Select(t => t.Stunde4).ToListAsync();
                    break;
                case 5:
                    fachIDs = await dataContext.Tag.Select(t => t.Stunde5).ToListAsync();
                    break;
                case 6:
                    fachIDs = await dataContext.Tag.Select(t => t.Stunde6).ToListAsync();
                    break;
                case 7:
                    fachIDs = await dataContext.Tag.Select(t => t.Stunde7).ToListAsync();
                    break;
                case 8:
                    fachIDs = await dataContext.Tag.Select(t => t.Stunde8).ToListAsync();
                    break;
            }

            List<Subjects> subjects = new List<Subjects>();

            foreach (int subjectNumber in fachIDs)
            {

                subjects.Add(await dataContext.Faecher.Where(f => f.ID == subjectNumber).FirstOrDefaultAsync());
            }


            //subjects = await dataContext.Faecher.Where(f => fachIDs.Contains(f.ID)).ToListAsync();
            return subjects;
        }
    }
}
