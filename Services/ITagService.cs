using StundenplanApp.Models;

namespace StundenplanApp.Services
{
    public interface ITagService
    {
        public Task<Days> createDay(Days newDay);
        public Task<Days> getDay(int dayID);
        public Task<Days> deleteDay(int dayID);
        public Task<Days> editDay(Days dayToEdit);
        public Task<List<Subjects>> getSubjectsByDay(int dayID);
        public Task<List<Days>> getDaysByUserID(int userID);
        public Task<List<Subjects>> getSubjectsByStd(int stdNumber);
    }
}
